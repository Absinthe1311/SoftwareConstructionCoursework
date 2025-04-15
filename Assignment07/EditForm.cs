using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//对订单进行编辑的页面
// Mode = 0  //增加
// Mode = 1  //修改
namespace Assignment7
{
    public partial class EditForm: Form
    {
        private OrderService orderService;
        private int Mode;
        public EditForm(OrderService orderService, int mode)
        {
            this.orderService = orderService;
            this.Mode = mode;
            InitializeComponent();
            //初始化用户下拉框
            CustomerCBX.DataSource = orderService.Customers;
            ConfirmButton.Click += ConfirmButton_Click;
            CancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //尝试添加订单
            try
            {
                using (var context = new OrderContext())
                {
                    //获取订单的ID
                    int orderID = int.Parse(OrderIDTextBox.Text);

                    //获取订单客户
                    string customerName = CustomerCBX.Text.ToString();
                    Customer customer = context.Customers.FirstOrDefault(c => c.Name == customerName);

                    //创建订单
                    Order order = new Order(orderID, customer);

                    //添加订单明细
                    if((int)AppleQuantity.Value>0)
                    {
                        Goods apple = context.Goods.FirstOrDefault(g => g.Name == "Apple");
                        order.AddOrderDetail(new OrderDetail(apple, (int)AppleQuantity.Value));
                    }
                    if((int)OrangeQuantity.Value>0)
                    {
                        Goods orange = context.Goods.FirstOrDefault(g => g.Name == "Orange");
                        order.AddOrderDetail(new OrderDetail(orange, (int)OrangeQuantity.Value));
                    }
                    if((int)BananaQuantity.Value>0)
                    {
                        Goods banana = context.Goods.FirstOrDefault(g => g.Name == "Banana");
                        order.AddOrderDetail(new OrderDetail(banana, (int)BananaQuantity.Value));
                    }

                    //添加订单到数据库
                    orderService.AddOrder(order);
                    if (this.Mode == 0)
                        MessageBox.Show("添加订单成功");
                    else if (this.Mode == 1)
                        MessageBox.Show("订单修改成功");
                    this.Close();
                }
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
    }
}
