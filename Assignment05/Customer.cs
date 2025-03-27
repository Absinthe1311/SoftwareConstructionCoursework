using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  客户类 
 * 1.客户的名字
 * 2.客户的电话
 * 3.客户的地址
 * 4.ToString方法，用于显示客户信息
 */

namespace Assignment5
{
    public class Customer
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public override string ToString() => $"客户: {Name}, 电话: {Phone}, 地址: {Address}";

        //客户的构造函数
        public Customer(string name, string phone, string address)
        {
            Name = name;
            Phone = phone;
            Address = address;
        }
    }
}
