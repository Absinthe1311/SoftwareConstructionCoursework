using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment8.Models;
using Mysqlx.Crud;

namespace Assignment8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderContext _context;

        public OrdersController(OrderContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.GoodsItem)
                .ToListAsync();
            var response = orders.Select(
                order => new OrderResponseDTO
                {
                    ID = order.ID,
                    CustomerName = order.Customer.Name,
                    Time = order.Time,
                    TotalPrice = order.TotalPrice,
                    Details = order.OrderDetails.Select(
                        od => new OrderDetailResponseDTO
                        {
                            GoodsName = od.GoodsItem.Name,
                            GoodsPrice = od.GoodsItem.Price,
                            Quantity = od.Quantity
                        }).ToList()
                });
            return Ok(response); //不知道这个Ok()是干什么用的
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseDTO>> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.GoodsItem)
                .FirstOrDefaultAsync(o => o.ID == id);
            if(order == null)
            {
                return NotFound();
            }
            var response = new OrderResponseDTO
            {
                ID = order.ID,
                CustomerName = order.Customer?.Name,
                Time = order.Time,
                TotalPrice = order.TotalPrice,
                Details = order.OrderDetails.Select(od => new OrderDetailResponseDTO
                {
                    GoodsName = od.GoodsName,
                    GoodsPrice = od.GoodsItem.Price,
                    Quantity = od.Quantity
                }).ToList()
            };
            return response;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderDTO orderDto)
        {
            //先检查订单是否存在
            var existingOrder = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.ID == id);
            if(existingOrder == null)
            {
                return NotFound("Order Not Found");
            }

            //检查更新后的CustomerID
            var customer = await _context.Customers.FindAsync(orderDto.CustomerID);
            if(customer == null)
            {
                return BadRequest("Invalid CustomerID.");
            }

            //更新订单的基本信息
            existingOrder.CustomerID = orderDto.CustomerID;
            existingOrder.Customer = customer;

            //更新订单明细
            //首先删除原有的（这里不知道是否要RemoveOrderDetails)
            _context.OrderDetails.RemoveRange(existingOrder.OrderDetails);
            //再往里面添加新的
            foreach (var detailDto in orderDto.OrderDetails)
            {
                var goods = await _context.Goods.FindAsync(detailDto.GoodsID);
                if (goods == null)
                {
                    return BadRequest("Invalid GoodsID");
                }

                var orderDetail = new OrderDetail
                {
                    GoodsID = goods.ID,
                    GoodsItem = goods,
                    Quantity = detailDto.Quantity
                };
                existingOrder.OrderDetails.Add(orderDetail);
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PostOrder(OrderDTO orderDto)
        {
            //获取对应的Customer
            var customer = await _context.Customers.FindAsync(orderDto.CustomerID); 
            if(customer==null)
            {
                return BadRequest("Invalid CustomerID");
            }

            //创建Order对象
            var order = new Assignment8.Models.Order(customer);

            //遍历orderDto中的明细，添加到订单里面
            foreach(var detailDto in orderDto.OrderDetails)
            {
                var goods = await _context.Goods.FindAsync(detailDto.GoodsID);
                if(goods == null)
                {
                    return BadRequest("Invalid GoodsID");
                }

                var orderDetail = new OrderDetail
                {
                    GoodsID = goods.ID,
                    GoodsItem = goods,
                    Quantity = detailDto.Quantity
                };
                order.OrderDetails.Add(orderDetail);
            }
            //保存订单到数据库
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.ID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.ID == id);
            if(existingOrder == null)
            {
                return NotFound("Order not found");
            }

            //删除关联的订单明细
            _context.OrderDetails.RemoveRange(existingOrder.OrderDetails);

            //删除订单
            _context.Orders.Remove(existingOrder);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
