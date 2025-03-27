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
    public class OrderServiceTests
    {
        private OrderService _orderService;
        [TestInitialize()]
        public void Initialize()
        {
             _orderService = new OrderService(); //创建订单服务对象

            Customer customer1 = new Customer("张三", "123", "北京市海淀区");// 创建客户对象
            Customer customer2 = new Customer("李四", "456", "北京市朝阳区");// 创建客户对象

            Product product1 = new Product("苹果", 5.0); // 创建商品对象
            Product product2 = new Product("香蕉", 3.0); // 创建商品对象
            Product product3 = new Product("橙子", 4.0); // 创建商品对象

            Order order1 = new Order(1, "2021-10-1", customer1); // 创建订单对象
            Order order2 = new Order(2, "2021-10-2", customer2); // 创建订单对象
            Order order3 = new Order(3, "2021-10-3", customer1); // 创建订单对象

            order1.AddOrderDetails(product1, 10);
            order2.AddOrderDetails(product2, 20);
            order3.AddOrderDetails(product1, 5);

            _orderService.AddOrder(order1);
            _orderService.AddOrder(order2);
            _orderService.AddOrder(order3);
        }
        [TestMethod()]
        public void AddOrderTest()
        {
            Customer customer = new Customer("王五", "123", "城市1");
            Product product = new Product("菠萝", 9.0);
            Order order = new Order(1, "2022-10-2", customer);
            order.AddOrderDetails(product, 10);
            Order order2 = new Order(4, "2023-10-4", new Customer("Name", "Phone", "Address"));
            Assert.ThrowsException<Exception>(() => _orderService.AddOrder(order));
            _orderService.AddOrder(order2);
        }
        [TestMethod()]
        public void RemoveOrderTest()
        {
            Assert.ThrowsException<Exception>(() => _orderService.RemoveOrder(4));
            _orderService.RemoveOrder(1);
        }
        [TestMethod()]
        public void ModifyOrderTest()
        {
            Order order = new Order(8, "2023-10-3", new Customer("1", "2", "3"));
            Assert.ThrowsException<Exception>(() => _orderService.ModifyOrder(order));
        }
        [TestMethod()]
        public void QueryOrderTest()
        {
            Assert.ThrowsException<Exception>(()=>_orderService.QueryOrders(null));
            _orderService.QueryOrders(order => order.OrderId == 1);
            _orderService.QueryOrders(order => order.OrderCustomer.Name == "张三");
        }
    }
}