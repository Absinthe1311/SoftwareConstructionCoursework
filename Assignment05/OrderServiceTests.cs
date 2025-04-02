using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        //订单服务实例化
        OrderService orderService = new OrderService();
        //商品实例化
        Product apple = new Product("苹果", 2.0);
        Product binana = new Product("香蕉", 3.2);
        Product egg = new Product("鸡蛋", 4.2);
        Product milk = new Product("牛奶", 2.3);
        //用户实例化
        Customer customer1 = new Customer("张", "123", "A市");
        Customer customer2 = new Customer("李", "456", "B市");

        //进行测试之前的初始化
        [TestInitialize]
        public void Init()
        {
            // 订单1的初始化
            Order order1 = new Order(1, new DateTime(2023, 3, 12), customer1);
            order1.AddOrderDetail(new OrderDetail(apple,80));
            order1.AddOrderDetail(new OrderDetail(egg, 30));
            order1.AddOrderDetail(new OrderDetail(milk, 70));

            // 订单2的初始化
            Order order2 = new Order(2, new DateTime(2024, 1, 28), customer2);
            order2.AddOrderDetail(new OrderDetail(binana, 20));
            order2.AddOrderDetail(new OrderDetail(milk, 30));

            //订单3的初始化
            Order order3 = new Order(3, new DateTime(1023, 2, 8), customer2);
            order3.AddOrderDetail(new OrderDetail(egg, 15));
            order3.AddOrderDetail(new OrderDetail(milk, 30));

            //添加订单
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);

        }

        [TestMethod]
        public void AddOrderTest()
        {
            Order order4 = new Order(4, new DateTime(1222, 10, 9), customer2);
            order4.AddOrderDetail(new OrderDetail(milk, 20));
            Order order5 = new Order(1, new DateTime(2312, 10, 8), customer1);
            try
            {
                orderService.AddOrder(order4);
                orderService.AddOrder(order5);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void RemoveOrderTest()
        {
            try
            {
                orderService.RemoveOrder(1);
                orderService.RemoveOrder(2);
                orderService.RemoveOrder(2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [TestMethod]
        public void ModifyOrderTest()
        {
            Order order4 = new Order(4,new DateTime(1122,10,9), customer1);
            Assert.ThrowsException<Exception>(() => orderService.ModifyOrder(order4));
        }

        [TestMethod]
        public void QueryOrderTest()
        {
            Assert.ThrowsException<Exception>(() => orderService.QueryOrder(null));
        }
    }
}