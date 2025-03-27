using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*   订单服务类
 *   1.添加订单
 *   2.删除订单
 *   3.修改订单
 *   4.查询订单
*/

namespace Assignment5
{
    public class OrderService
    {
        List<Order> orders = new List<Order>();

        //添加订单
        //当订单号重复时，抛出异常
        public void AddOrder(Order order)
        {
            if(orders.Any(o => o.OrderId == order.OrderId))
            {
                throw new Exception(string.Format("订单号为{0}的订单已存在",order.OrderId));
            }
            orders.Add(order);
        }

        //删除订单
        //当前仅支持根据订单号删除订单
        //当订单号不存在时，抛出异常
        public void RemoveOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new Exception(string.Format("订单号为{0}的订单不存在", orderId));
            }
            orders.Remove(order);
            Console.WriteLine("订单号为{0}的订单删除成功",orderId);
        }

        //修改订单
        //输入要修改的订单号，先删除这个订单，再添加一个相同订单号的订单
        public void ModifyOrder(Order order)
        {
            //先看有没有这个订单，没有就抛出异常
            var existingOrder = orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if(existingOrder == null)
            {
                throw new Exception(string.Format("订单号为{0}的订单不存在",order.OrderId));
            }
            orders.Remove(existingOrder);
            Console.WriteLine("订单号为{0}的订单修改成功",order.OrderId);
            orders.Add(order);
        }

        //查询订单
        public void QueryOrders(Func<Order, bool> criteria)
        {
            if (criteria == null)
                throw new Exception("请输入查询条件");
            List<Order> queryList = GetQueryOrders(criteria);
            if(queryList.Count == 0)
                Console.WriteLine("未找到相关订单");
            else
            {
                foreach (var order in queryList)
                {
                    Console.WriteLine(order);
                }
            }
        }
        //被订单查询功能使用，返回查询到的排序好的订单列表
        public List<Order> GetQueryOrders(Func<Order,bool> criteria)
        {
            return orders.Where(criteria).OrderByDescending(o=>o.TotalPrice).ToList();
        }
        
        //订单的排序功能
        //默认使用订单的总金额排序，也可以输入订单的其他属性进行排序
        public void SortOrders(Func<Order,object> keySelector = null)
        {
            if (keySelector == null)
                keySelector = o => o.TotalPrice;
            orders = orders.OrderBy(keySelector).ToList();
        }

        //显示订单
        public void DisplayOrders()
        {
            orders.ForEach(order => Console.WriteLine(order));
        }

    }
}
