using System.Text;

namespace Assignment8.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public DateTime Time { get; set; }
        public string CustomerName => Customer?.Name;
        public double TotalPrice
        {
            get => OrderDetails.Sum(od => od.Cost);
        }
        public Order()
        {
            //using (var context = new OrderContext())
            //{
            //    ID = context.Orders.Count() + 1; //订单ID从1开始自动增加
            //}
            Time = DateTime.Now;
        }
        public Order(Customer customer) : this()
        {
            this.Customer = customer;
        }

        //public Order(int id, Customer customer)
        //{
        //    this.ID = id;
        //    this.Customer = customer;
        //    this.Time = DateTime.Now;
        //}
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (OrderDetails.Contains(orderDetail))
            {
                throw new ApplicationException($"The goods {orderDetail.GoodsItem.Name} exists in order {ID}");
            }
            OrderDetails.Add(orderDetail);
        }

        //没用到，懒得写错误检测什么的了
        public void RemoveOrderDetail(int index)
        {
            OrderDetails.RemoveAt(index);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"orderId{ID},Customer{Customer}");
            OrderDetails.ForEach(detail => result.AppendLine("\n\t" + detail));
            return result.ToString();
        }
    }
}
