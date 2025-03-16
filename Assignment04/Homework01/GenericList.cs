using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

//这个文件定义了GenericList类

namespace Assignment4
{
    public class GenericList<T>
    {
        // 链表的私有属性，首节点和尾节点
        private Node<T> head;
        private Node<T> tail;
        public Node<T> Head { get => head; }
        //链表的默认构造函数
        public GenericList()
        {
            this.tail = this.head = null;
        }
        //链表的添加节点方法
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if(this.tail == null)
            {
                this.tail = this.head = n;
            }
            else
            {
                this.tail.Next = n;
                this.tail = n;
            }
        }
        //ForEach方法
        public void ForEach(Action<T> action)
        {
            Node<T> current = head;
            while(current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }
}
