using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*     订单明细
 *  1.订单的商品
 *  2.商品的数量
 *  2.计算出这个订单的总金额
 */
namespace Assignment5
{
    public class OrderDetails
    {
        public Product Products { get; set; }
        public int ProductNum { get; set; }

        public OrderDetails()
        { }
        public OrderDetails(Product product,int productNum)
        {
            Products = product;
            ProductNum = productNum;
        }
        public override string ToString() => $"商品: {Products.ProductName}, 数量: {ProductNum}";
    }
}
