namespace Assignment4
{
    //此文件定义Node类
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T data)
        {
            Next = null;
            Data = data;
        }
    }
}
