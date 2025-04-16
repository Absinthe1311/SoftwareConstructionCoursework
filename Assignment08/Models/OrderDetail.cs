namespace Assignment8.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public Goods GoodsItem { get; set; } //订单里面的具体的商品
        public int GoodsID { get; set; }  //订单里面商品的ID
        public int Quantity { get; set; } //购买的商品的数量
        public double Cost => GoodsItem.Price * Quantity;
        //public Order Order { get; set; }
        //public int OrderID { get; set; }

        public string GoodsName { get => GoodsItem != null ? this.GoodsItem.Name : ""; }

        public OrderDetail() //初始化ID
        {
            //using (var context = new OrderContext())
            //{
            //    ID = context.OrderDetails.Count() + 1;
            //}
            //this.ID = ++Count;
        }

        public OrderDetail(Goods goods, int quantity) : this()
        {
            GoodsItem = goods;
            Quantity = quantity;
        }
        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null && GoodsName == detail.GoodsName;
        }
        public override string ToString()
        {
            return $"OrderDetail:{GoodsItem},{Quantity}";
        }
        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsItem.Name);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }
}
