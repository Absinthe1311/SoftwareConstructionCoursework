using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//订单类
/*
 *  里面包含订单的基本信息
 *  属性： 订单号：OrderID 订单时间：OrderTime 订单客户：OrderCustomer 订单明细：List<OrderDetail> details 订单总金额：TotalPrice
 *  方法：添加订单明细:AddOrderDetail 移除订单明细: RemoveOrderDetail    ToString()方法
 */

namespace Assignment5
{
    public class Order 
    {
        //订单号 
        public int OrderId{ get;  set; }

        //订单时间 (修改类型为DataTime)
        public DateTime OrderTime { get; set; }

        //订单客户
        public Customer OrderCustomer { get; set; }

        // 订单明细
        private readonly List<OrderDetail> details = new List<OrderDetail>();

        //对外的接口
        public List<OrderDetail> Details => details;

        //订单总金额
        public double TotalPrice => details.Sum(detail => detail.Cost);

        //添加订单明细的方法
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (details.Contains(orderDetail))
                throw new ApplicationException($"The product ({orderDetail.Product.ProductName}) already exists");
            details.Add(orderDetail);
        }
        //移除订单明细的方法
        public void RemoveOrderDetail(OrderDetail orderDetail)
        {
            if (!details.Contains(orderDetail))
                throw new ApplicationException($"The product ({orderDetail.Product.ProductName}) doesn't exist");
            details.Remove(orderDetail);
        }
        //订单的构造函数
        public Order(int orderId, DateTime orderTime, Customer orderCustomer)
        {
            OrderId = orderId;
            OrderTime = orderTime;
            OrderCustomer = orderCustomer;
        }
        //订单要有ToString方法，后面显示订单
        public override string ToString()
        {
            StringBuilder OrderInfo = new StringBuilder();
            OrderInfo.AppendLine($"订单号: {OrderId},订单总金额：{TotalPrice}");
            OrderInfo.AppendLine(OrderCustomer.ToString());
            details.ForEach(detail => OrderInfo.AppendLine(detail.ToString()));
            return OrderInfo.ToString();
        }
    }
}
