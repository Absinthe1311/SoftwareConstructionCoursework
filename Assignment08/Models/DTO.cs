namespace Assignment8.Models
{
    //用于Post
    public class OrderDTO
    {
        public int CustomerID { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }

    public class OrderDetailDTO
    {
        public int GoodsID { get; set; }
        public int Quantity { get; set; }
    }
    //用于Get
    public class OrderResponseDTO
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime Time { get; set; }
        public List<OrderDetailResponseDTO> Details { get; set; }
        public double TotalPrice { get; set; }
    }
    public class OrderDetailResponseDTO
    {
        public string GoodsName { get; set; }
        public double GoodsPrice { get; set; }
        public int Quantity { get; set; }
        public double Cost => GoodsPrice * Quantity;
    }
}
