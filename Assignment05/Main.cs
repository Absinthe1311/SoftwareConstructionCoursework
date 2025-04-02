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
        static void Main()
        {
            //创建一些商品
            Product apple = new Product("苹果", 2);
            Product binana = new Product("香蕉", 4);
            Product milk = new Product("牛奶", 5.2);
            Product egg = new Product("鸡蛋", 2.3);

            //创建几位用户
            Customer customer1 = new Customer("A", "123", "A市");
            Customer customer2 = new Customer("B", "456", "B市");
            Customer customer3 = new Customer("C", "678", "C市");

            //创建几个订单
            Order order1 = new Order(1, new DateTime(2015, 10, 10), customer1);
            Order order2 = new Order(2, new DateTime(2020, 10, 20), customer2);
            Order order3 = new Order(3, new DateTime(2021, 12, 12), customer2);

            //为这些订单添加订单明细
            order1.AddOrderDetail(new OrderDetail(apple, 12));
            order1.AddOrderDetail(new OrderDetail(egg, 11));
            order1.AddOrderDetail(new OrderDetail(binana, 14));

            order2.AddOrderDetail(new OrderDetail(apple, 10));
            order2.AddOrderDetail(new OrderDetail(milk, 19));

            order3.AddOrderDetail(new OrderDetail(egg, 19));

            // 创建我的订单服务
            OrderService orderService = new OrderService();

            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            //开始测试我的各种函数
            ////1.测试我的 AddOrderDetail 和 RemoveOrderDetail
            //try
            //{
            //    order1.AddOrderDetail(new OrderDetail(apple, 12)); //不确定是否会报错
            //    order1.RemoveOrderDetail(new OrderDetail(apple, 14));
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            ////2.测试我的 AddOrder 
            //try
            //{
            //    orderService.AddOrder(order1);
            //    orderService.AddOrder(order2);
            //    orderService.AddOrder(order1); //这里要抛出异常
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            ////3.测试我的 RemoveOrder
            //try
            //{
            //    orderService.RemoveOrder(1);
            //    orderService.RemoveOrder(3); //这里也会抛出异常
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e);
            //}
            ////4.测试我的 ModifyOrder
            //try
            //{
            //    orderService.ModifyOrder(new Order(2, new DateTime(), customer3));
            //    orderService.ModifyOrder(new Order(1, new DateTime(), customer1)); //上面删除了，这里要报错
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e);
            //}
            //5. 测试我的 QueryOrder
            try
            {
                orderService.AddOrder(new Order(5, new DateTime(1222, 10, 10), customer1));
                orderService.QueryOrder(order => order.OrderId == 1);
                orderService.QueryOrder(order => order.OrderCustomer == customer1);
                //好像还没有实现根据商品来查询订单
                orderService.QueryOrderByProduct("苹果");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}