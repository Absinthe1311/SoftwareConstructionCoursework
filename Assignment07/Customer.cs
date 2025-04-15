using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment7
{
    //ID+姓名
    //不确定这个是否还需要一个外键关联到订单上去
    public class Customer
    {
        public int ID { get; set; } //用户的ID

        public string Name { get; set; } //用户的姓名 

        public Customer(string name) : this()
        {
            Name = name;
        }

        public Customer()
        {
            using (var context = new OrderContext())
            {
                ID = context.Customers.Count() + 1;
            }
        }
        public override string ToString()
        {
            return $"CustomerID{ID},CustomerName:{Name}";
        }

        public override bool Equals(object obj)
        {
            var cus = obj as Customer;
            return cus != null && ID == cus.ID; //ID相等就是同一个人
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
