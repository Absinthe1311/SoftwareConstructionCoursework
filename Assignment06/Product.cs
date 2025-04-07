using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *  货物类
 *  属性：产品名称 ProductName 产品单价 UnitPrice
 *  方法： ToString() 
 */
namespace Assignment6
{
    public class Product
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public override string ToString() => $"商品: {ProductName}, 单价: {UnitPrice}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Product other = (Product)obj;
            return (ProductName == other.ProductName) && (UnitPrice == other.UnitPrice);
        }

        //商品的构造函数
        public Product(string productName, double unitPrice)
        {
            ProductName = productName;
            UnitPrice = unitPrice;
        }
    }
}
