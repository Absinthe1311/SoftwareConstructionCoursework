using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    abstract class Shape //抽象类
    {
        public double x, y;
        public Shape(double x,double y) 
        {
            this.x = x;
            this.y = y;
        }
        public abstract double GetArea();
    }
    class Rectangle : Shape //矩形
    {
        public Rectangle(double width, double height) : base(width, height) { }
        public override double GetArea()
        {
            return x * y;
        }
    }
    class Circle : Shape //圆形
    {
        public Circle(double radius) : base(radius, 0.0) { }
        public override double GetArea() { return Math.PI * x * x; }
    }
    class Square : Shape //正方形
    {
        public Square(double side) : base(side, side) { }
        public override double GetArea()
        {
            return x * x;
        }
    }
    class RandomShapes
    {
        public static void Main()
        {
            Shape[] shapes = new Shape[10]; //随机创建10个对象
            Random rnd = new Random();
            for(int i = 0; i<shapes.Length; i++)
            {
                int type = rnd.Next(0, 3); //产生随机数0，1，2
                double x = rnd.NextDouble() * 10 + 1; //产生1-11的随机数
                double y = rnd.NextDouble() * 10 + 1; //产生1-11的随机数
                switch(type)
                {
                    case 0:
                        shapes[i] = new Rectangle(x, y); break;
                    case 1:
                        shapes[i] = new Circle(x); break;
                    case 2:
                        shapes[i] = new Square(x); break;
                }
            }
            double area_sum = 0.0; //计算各个形状面积之和
            for(int i = 0; i<shapes.Length; i++)
            {
                if (shapes[i] is Rectangle)
                {
                    Console.WriteLine("第{0}号形状:矩形({1:0.00},{2:0.00}),面积={3:0.00}",
                        i + 1, shapes[i].x, shapes[i].y, shapes[i].GetArea());
                }
                else if (shapes[i] is Circle)
                {
                    Console.WriteLine("第{0}号形状:圆形({1:0.00}),面积={2:0.00}",
                        i + 1, shapes[i].x, shapes[i].GetArea());
                }
                else
                {
                    Console.WriteLine("第{0}号形状:正方形({1:0.00}),面积={2:0.00}",
                        i + 1, shapes[i].x, shapes[i].GetArea());
                }
                area_sum += shapes[i].GetArea();
            }
            Console.WriteLine("面积之和：{0:0.00}", area_sum);
        }
    }
}
