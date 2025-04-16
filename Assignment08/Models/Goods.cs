namespace Assignment8.Models
{
    public class Goods
    {
        public int ID { get; set; } // 商品的ID，自动生成
        public double Price { get; set; } //商品的价格
        public string Name { get; set; } //商品的名称

        public Goods()
        {
            //using (var context = new OrderContext())
            //{
            //    ID = context.Goods.Count() + 1;
            //}
        }

        public Goods(double price, string name) : this()
        {
            if (price < 0)
                throw new ArgumentException("The price must be > 0");
            this.Price = price;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"商品名称:{Name},商品单价：{Price}";
        }
        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null && ID == goods.ID;
        }
        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + ID;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
