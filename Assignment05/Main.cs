using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //后面放到我的OrderServiceTest.cs中进行测试了
    class Homework1
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService(); // 创建订单服务对象

            Customer customer1 = new Customer("张三","123","北京市海淀区");// 创建客户对象
            Customer customer2 = new Customer("李四", "456", "北京市朝阳区");// 创建客户对象

            Product product1 = new Product("苹果", 5.0); // 创建商品对象
            Product product2 = new Product("香蕉", 3.0); // 创建商品对象
            Product product3 = new Product("橙子", 4.0); // 创建商品对象

            Order order1 = new Order(1, "2021-10-1", customer1); // 创建订单对象
            Order order2 = new Order(2, "2021-10-2", customer2); // 创建订单对象
            Order order3 = new Order(3, "2021-10-3", customer1); // 创建订单对象

            Order order4 = new Order(4, "2021-10-4", customer2); // 用于测试我的订单删除功能
            Order order5 = new Order(1, "2021-10-5", customer1); // 用于测试我的订单添加功能

            order1.AddOrderDetails(product1, 10); // 添加订单明细
            order2.AddOrderDetails(product3, 20); // 添加订单明细
            order3.AddOrderDetails(product2, 30); // 添加订单明细

            Order order6 = new Order(2, "2001-10-4", customer2);
            order6.AddOrderDetails(product2, 10);
            Order order7 = new Order(5, "1100-10-3", customer1);
            order7.AddOrderDetails(product3 , 10);

            //测试添加订单的功能
            try
            {
                orderService.AddOrder(order1); // 添加订单
                orderService.AddOrder(order2); // 添加订单
                orderService.AddOrder(order3); // 添加订单
                orderService.DisplayOrders();

                orderService.AddOrder(order5); // 添加订单 失败，给出提示信息
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //测试订单显示功能
            orderService.DisplayOrders(); // 显示订单
            //测试订单删除功能
            try
            {
                //orderService.RemoveOrder(4); //删除订单 失败，给出提示信息
                orderService.RemoveOrder(3); //删除订单 成功，给出提示信息
                orderService.DisplayOrders(); // 显示订单
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //测试订单修改功能
            try
            {
                orderService.ModifyOrder(order6);
                orderService.DisplayOrders();
                orderService.ModifyOrder(order7);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
                
        }
    }
}
