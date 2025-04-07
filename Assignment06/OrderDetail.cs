using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*     订单明细
 *     属性：商品：Product 数量：Quantity 价格：Cost
 *     方法： ToString()  
 *     //这个类需要用一个重载的比较函数
 */
namespace Assignment6
{
    public class OrderDetail
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public double Cost => Product.UnitPrice * Quantity;
        public OrderDetail()
        { }
        public OrderDetail(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public override string ToString() => $"商品: {Product.ProductName}, 数量: {Quantity}, 总价：{Cost}";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            OrderDetail other = (OrderDetail)obj;
            return Product == other.Product && Quantity == other.Quantity;
        }
    }
}
