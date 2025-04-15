using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment7
{
    public partial class MainForm: Form
    {
        OrderService orderService;
        public MainForm() //主窗口
        {
            InitializeComponent();
            //创建订单服务对象
            orderService = new OrderService();
            //初始化订单的显示
            OrderBD.DataSource = orderService.Orders;
            //订单明细显示功能
            OrderGridView.SelectionChanged += OrderGridView_SelectionChanged;

            //订单搜索功能实现
            SearchCBX.DataSource = new List<string> { "显示所有订单", "客户姓名", "总金额", "商品名称" };
            SearchButton.Click += SearchButton_Click;

            //订单添加功能实现
            AddButton.Click += AddButton_Click;

            //订单删除功能实现
            RemoveButton.Click += RemoveButton_Click;

            //订单的修改功能
            ModifyButton.Click += ModifyButton_Click;

        }
        private void ModifyButton_Click(object sender, EventArgs e)
        {
            EditForm ModifyForm = new EditForm(orderService,1); //修改订单模式
            RemoveButton_Click(sender, e); //先发出一个信号，删除现在选中的订单
            ModifyForm.FormClosed += EditForm_FormClosed;
            ModifyForm.Show();
        }
        public void QueryAll() //相当于重新刷新显示
        {
            OrderBD.DataSource = orderService.Orders;
            OrderBD.ResetBindings(false);
        }
        //用于实现订单的删除功能
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(OrderGridView.SelectedRows.Count >0)
            {
                //获取当前选中的订单
                Order SelectedOrder = OrderBD.Current as Order;
                if(SelectedOrder != null)
                {
                    orderService.RemoveOrder(SelectedOrder.ID);
                    QueryAll();
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的订单");
            }
        }

        //用于显示订单的明细
        private void OrderGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(OrderGridView.SelectedRows.Count > 0)
            {
                //获取当前选中的订单
                Order SelectedOrder = OrderGridView.CurrentRow.DataBoundItem as Order;
                if (SelectedOrder != null)
                {
                    DetailBD.DataSource = SelectedOrder.OrderDetails;
                    DetailGridView.DataSource = DetailBD;
                }
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            EditForm AddForm = new EditForm(orderService, 0); //添加模式
            AddForm.FormClosed += EditForm_FormClosed;
            AddForm.Show();
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OrderBD.DataSource = null; //清空数据源
            OrderBD.DataSource = orderService.Orders; //重新绑定数据
            OrderGridView.DataSource = OrderBD;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //获取当前搜索框里面的值
            string selectedSearchMode = SearchCBX.SelectedItem.ToString();
            List<Order> searchResults = new List<Order>();
            switch (selectedSearchMode)
            {
                case "显示所有订单":
                    OrderBD.DataSource = orderService.Orders;
                    break;
                case "总金额":
                    double totalPrice = double.Parse(SearchTextBox.Text);
                    OrderBD.DataSource = orderService.QueryOrdersByTotalCost(totalPrice);
                    break;
                case "客户姓名":
                    string customerName = SearchTextBox.Text;
                    OrderBD.DataSource = orderService.QueryOrdersByCustomer(customerName);
                    break;
                case "商品名":
                    string goodsName = SearchTextBox.Text;
                    OrderBD.DataSource = orderService.QueryOrdersByGoodsName(goodsName);
                    break;
                default:
                    OrderBD.DataSource = null;
                    MessageBox.Show("查询条件有误");
                    break;
            }
        }
    }
}
