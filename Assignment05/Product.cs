using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *  货物类
 *  1.货物的名称
 *  2.货物的价格
 */
namespace Assignment5
{
    public class Product
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public override string ToString() => $"商品: {ProductName}, 单价: {UnitPrice}";

        //商品的构造函数
        public Product(string productName, double unitPrice)
        {
            ProductName = productName;
            UnitPrice = unitPrice;
        }
    }
}
