namespace Homework1
{
    //使用形状作为抽象类
    abstract class Shape
    {
        //判断形状是否合法
        public abstract bool IsValid();
        //求图形面积
        public abstract double GetArea();
    }
    //长方形类，继承自Shape
    class Rectangle : Shape
    {   //长方形的私有属性，宽和高
        private double width;
        private double height;
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Height
        {
            get { return height; }
            set { height = value; }
        }
        //带有参数的构造函数
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        //重载判断图形是否合法的函数
        public override bool IsValid()
        {
            return width > 0 && height > 0;
        }
        //重载计算面积的函数
        public override double GetArea()
        {
            return IsValid() ? width * height : 0;
        }
    }

    //正方形类,继承自长方形
    class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
    }

    //三角形类，继承自形状
    class Triangle : Shape
    {
        //私有属性三条边以及它们的set,get方法
        private double a;
        private double b;
        private double c;
        public double A { get { return a; } set { a = value; } }
        public double B { get { return b; } set { b = value; } }
        public double C { get { return c; } set { c = value; } }
        //构造函数
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        //重载判断图形是否合法的函数
        public override bool IsValid()
        {
            return (A > 0) && (B > 0) && (C > 0) && (A + B > C) && (A + C > B) && (B + C > A);
        }
        //重载计算面积的函数
        public override double GetArea()
        {
            if (!IsValid()) return 0;
            double s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
    }

    class TestProgram
    {
        static void Main()
        {
            Shape rect = new Rectangle(5, 10);
            Console.WriteLine($"长方形面积: {rect.GetArea()}");

            Shape square = new Square(4);
            Console.WriteLine($"正方形面积: {square.GetArea()}");

            Shape triangle = new Triangle(3, 4, 5);
            Console.WriteLine($"三角形面积: {triangle.GetArea()}");
        }
    }
}
