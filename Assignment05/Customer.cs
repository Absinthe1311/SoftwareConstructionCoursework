using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  客户类 被用于Order类
 *  属性：姓名：Name 电话：Phone 地址：Address
 */

namespace Assignment5
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public override string ToString() => $"客户: {Name}, 电话: {Phone}, 地址: {Address}";
        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != typeof(Customer)) return false;
            Customer other = (Customer)obj;
            return (Name == other.Name && Phone == other.Phone && Address == other.Address);
        }

        //客户的构造函数
        public Customer(string name, string phone, string address)
        {
            Name = name;
            Phone = phone;
            Address = address;
        }
        public Customer(Customer customer)
        {
            this.Name = customer.Name;
            this.Phone = customer.Phone;
            this.Address = customer.Address;
        }
    }
}
