using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

/*   应该提前保存customer和Goods到我的数据库里面，之后只能添加订单，不能修改我的顾客和商品
 *   
*/

namespace Assignment7
{
    public class OrderService
    {
        public OrderService()
        {
            using (var context = new OrderContext())
            {
                if (context.Goods.Count() == 0)
                {
                    context.Goods.Add(new Goods(2.0, "Apple"));
                    context.Goods.Add(new Goods(2.5, "Orange"));
                    context.Goods.Add(new Goods(3, "Banana"));
                    context.SaveChanges();
                }
                if (context.Customers.Count() == 0)
                {
                    context.Customers.Add(new Customer("A"));
                    context.Customers.Add(new Customer("B"));
                    context.SaveChanges();
                }
            }
        }

        private static void FixOrder(Order newOrder) //添加订单，不必要再添加订单客户 添加的Detail不需要添加产品信息
        {
            newOrder.CustomerID = newOrder.Customer.ID;
            newOrder.Customer = null;
            newOrder.OrderDetails.ForEach(d =>
            {
                d.GoodsID = d.GoodsItem.ID;
                d.GoodsItem = null;
            });
        }
        //订单查找功能
        //1.根据商品名称查询
        public List<Order> QueryOrdersByGoodsName(string goodsName) 
        {
            using (var context = new OrderContext())
            {
                return context.Orders
                    .Include(o => o.OrderDetails.Select(d => d.GoodsItem))
                    .Include(o => o.Customer)
                    .Where(order => order.OrderDetails.Any(item => item.GoodsItem.Name == goodsName))
                    .ToList();
            }
        }
        //2.根据总金额查询
        public List<Order> QueryOrdersByTotalCost(double totalCost)
        {
            using (var context = new OrderContext())
            {
                return context.Orders
                    .Include(o => o.OrderDetails.Select(d => d.GoodsItem))
                    .Include(o => o.Customer)
                    .Where(order => order.OrderDetails.Sum(d=>d.Quantity*d.GoodsItem.Price) > totalCost)
                    .ToList();
            }
        }
        //3.根据用户名查询
        public List<Order> QueryOrdersByCustomer(string customerName)
        {
            using (var context = new OrderContext())
            {
                return context.Orders
                    .Include(o => o.OrderDetails.Select(d => d.GoodsItem))
                    .Include(o => o.Customer)
                    .Where(order => order.Customer.Name == customerName)
                    .ToList();
            }
        }
        //4. 根据订单号查询(感觉这个没什么用，就不放在程序里面了)
        public Order QueryOrderByOrderID(int orderID)
        {
            using (var context = new OrderContext())
            {
                return context.Orders.FirstOrDefault(order => order.ID == orderID);
            }
        }

        //修改订单功能
        public void ModifyOrder(Order newOrder)
        {
            RemoveOrder(newOrder.ID);
            AddOrder(newOrder);
        }
        //删除订单功能
        public void RemoveOrder(int OrderID) 
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders
                    .Include("OrderDetails")
                    .SingleOrDefault(o => o.ID == OrderID);
                if (order == null) //没有找到这个ID的时候
                    return;
                context.OrderDetails.RemoveRange(order.OrderDetails);
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        //添加订单
        public void AddOrder(Order order)
        {
            FixOrder(order);
            using (var context = new OrderContext())
            {
                context.Entry(order).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        //用来得到所有的订单
        public List<Order> Orders
        {
            get
            {
                using (var ctx = new OrderContext())
                {
                    return ctx.Orders
                      .Include(o => o.OrderDetails.Select(d => d.GoodsItem))
                      .Include(o => o.Customer)
                      .ToList<Order>();
                }
            }
        }
        //用来得到所有的客户
        public List<Customer> Customers
        {
            get
            {
                using (var context = new OrderContext())
                {
                    return context.Customers.ToList();
                }
            }
        }
    }
}
