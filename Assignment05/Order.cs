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
 *  1.订单号
 *  2.订单客户
 *  3.订单的日期
 *  5.订单的总金额
 *  6.订单明细
 *  
 *  基本操作
 *  1.添加订单明细 AddOrderDetails
 *  
 */

namespace Assignment5
{
    public class Order 
    {
        //订单号 
        public int OrderId{ get;  set; }

        //订单时间
        public string OrderTime { get; set; }

        //订单客户
        public Customer OrderCustomer;

        // 订单明细
        public OrderDetails OrderDetails;

        // 商品名称（方便后面的查询)
        public string OrderProductName => OrderDetails.Products.ProductName;

        //订单总金额
        public double TotalPrice => OrderDetails.Products.UnitPrice * OrderDetails.ProductNum;

        //添加订单明细的方法
        public void AddOrderDetails(Product product,int productNum)
        {
            OrderDetails.ProductNum = productNum;
            OrderDetails.Products = product;
        }
        //订单的构造函数
        public Order(int orderId, string orderTime, Customer orderCustomer)
        {
            OrderId = orderId;
            OrderTime = orderTime;
            OrderCustomer = orderCustomer;
            OrderDetails = new OrderDetails();
        }
        //订单要有ToString方法，后面显示订单
        public override string ToString()
        {
            StringBuilder OrderInfo = new StringBuilder();
            OrderInfo.AppendLine($"订单号: {OrderId},订单时间：{OrderTime},订单总金额：{TotalPrice}");
            OrderInfo.AppendLine(OrderCustomer.ToString());
            OrderInfo.AppendLine(OrderDetails.ToString());
            return OrderInfo.ToString();
        }
    }
}
