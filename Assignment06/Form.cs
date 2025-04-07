using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class Form: System.Windows.Forms.Form
    {

        private OrderService orderService;
        public Form(OrderService orderService)
        {
            InitializeComponent();
            this.orderService = orderService;
            //绑定确认和取消按钮事件
            Confirm.Click += Confirm_Click;
            Cancel.Click += Cancel_Click;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                //获取订单号
                int orderId = int.Parse(OrderIdTextBox.Text);

                //获取顾客信息
                string customerName = NameTextBox.Text;
                string customerPhone = PhoneTextBox.Text;
                string customerAddress = AddressTextBox.Text;
                Customer customer = new Customer(customerName, customerPhone, customerAddress); //新建客户

                Order newOrder = new Order(orderId, DateTime.Now, customer);

                //添加订单明细
                if((int)AppleQuantity.Value >0)
                {
                    newOrder.AddOrderDetail(new OrderDetail(new Product("苹果", 2),(int)AppleQuantity.Value ));
                }
                if((int)OrangeQuantity.Value >0)
                {
                    newOrder.AddOrderDetail(new OrderDetail(new Product("橘子", 2.5), (int)OrangeQuantity.Value));
                }
                if((int)BinanaQuantity.Value>0)
                {
                    newOrder.AddOrderDetail(new OrderDetail(new Product("香蕉", 3), (int)BinanaQuantity.Value));
                }

                orderService.AddOrder(newOrder);
                MessageBox.Show("订单添加成功");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
