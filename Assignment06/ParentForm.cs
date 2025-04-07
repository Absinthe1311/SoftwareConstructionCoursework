using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class ParentForm : System.Windows.Forms.Form
    {
        private OrderService orderService;
        private bool isModifying = false; //标志是否为修改操作
        public ParentForm()
        {
            InitializeComponent();

            //创建订单对象并添加到BindingSource
            //商品
            Product apple = new Product("苹果", 2.0);
            Product orange = new Product("橘子", 2.5);
            Product binana = new Product("香蕉", 3.0);
            //客户
            Customer customerA = new Customer("A", "123", "A City");
            Customer customerB = new Customer("B", "456", "B City");
            Customer customerC = new Customer("C", "789", "C City");
            //订单
            Order order1 = new Order(1, new DateTime(1222, 10, 10), customerA);
            Order order2 = new Order(2, new DateTime(2010, 12, 12), customerB);
            Order order3 = new Order(3, new DateTime(2019, 11, 11), customerC);
            //订单明细
            order1.AddOrderDetail(new OrderDetail(orange, 2));
            order1.AddOrderDetail(new OrderDetail(binana, 3));
            order2.AddOrderDetail(new OrderDetail(apple, 6));
            order3.AddOrderDetail(new OrderDetail(orange, 4));
            //初始化OrderService
            orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            // 现在第一个OrderGridView的显示就是这个orderService.orders了
            orderBindingSource.DataSource = orderService.orders;
            OrderGridView.DataSource = orderBindingSource.DataSource;

            //绑定订单选择事件
            OrderGridView.SelectionChanged += OrderGridView_SelectionChanged;

            //下拉框的选择项
            SearchComboBox.DataSource = new List<string> { "订单号", "顾客姓名", "总金额", "商品名" };

            //搜索按钮点击事件
            SearchButton.Click += SearchButton_Click;

            //增加按钮点击事件
            AddButton.Click += AddButton_Click;

            //删除按钮点击事件
            RemoveButton.Click += RemoveButton_Click;

            //修改按钮点击事件
           // ModifyButton.Click += RemoveButton_Click; //先删除
            ModifyButton.Click += ModifyButton_Click;
        }
        //修改按钮点击事件处理函数
        private void ModifyButton_Click(object sender, EventArgs e)
        {
            Form modifyForm = new Form(orderService);
            RemoveButton_Click(sender, e); //先删除
            modifyForm.FormClosed += Form_FormClosed;
            modifyForm.Show();
        }
        //处理订单的选择的变化，显示订单明细
        private void OrderGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (OrderGridView.SelectedRows.Count > 0)
            {
                // 获取当前选中的订单
                Order selectedOrder = OrderGridView.SelectedRows[0].DataBoundItem as Order;
                if (selectedOrder != null)
                {
                    // 显示订单明细
                    orderDetailBindingSource.DataSource = selectedOrder.Details;
                    OrderDetailGridView.DataSource = orderDetailBindingSource.DataSource;
                }
            }
        }

        //处理搜索按钮的点击事件，根据下拉框的选择用不同的搜索模式搜索订单
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //获取当前选择框里面的值
            string selectedSearchMethod = SearchComboBox.SelectedItem.ToString();
            List<Order> searchResults = new List<Order>();

            switch (selectedSearchMethod)
            {
                case "订单号":
                    int orderId = int.Parse(SearchTextBox.Text);
                    searchResults = orderService.SearchByOrderId(orderId);
                    break;
                case "顾客姓名":
                    string customerName = SearchTextBox.Text;
                    searchResults = orderService.SearchByCustomerName(customerName);
                    break;
                case "总金额":
                    double totalPrice = double.Parse(SearchTextBox.Text);
                    searchResults = orderService.SearchByTotalPrice(totalPrice);
                    break;
                case "商品名":
                    string productName = SearchTextBox.Text;
                    searchResults = orderService.SearchByProductName(productName);
                    break;
                default: //这里应该报错
                    break;
            }
            orderBindingSource.DataSource = searchResults;
            OrderGridView.DataSource = orderBindingSource.DataSource;
        }

        //处理增加按钮的点击事件，新建一个增加订单的页面
        private void AddButton_Click(object sender, EventArgs e)
        {
            //新建一个增加订单的页面
            Form addForm = new Form(orderService);

            ////刷新绑定数据
            //orderBindingSource.DataSource = null;
            //orderBindingSource.DataSource = orderService.orders;
            //OrderGridView.DataSource = orderBindingSource;
            addForm.FormClosed += Form_FormClosed;
            addForm.Show();
            ////刷新绑定数据
            //orderBindingSource.DataSource = null;
            //orderBindingSource.DataSource = orderService.orders;
            //OrderGridView.DataSource = orderBindingSource;
        }
        // 处理增加订单页面关闭的事件
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //刷新绑定数据
            orderBindingSource.DataSource = null;
            orderBindingSource.DataSource = orderService.orders;
            OrderGridView.DataSource = orderBindingSource;
        }


        //处理删除按钮的点击事件，出现一个是否确定的对话框
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (OrderGridView.SelectedRows.Count > 0)
            {
                Order selectedOrder = OrderGridView.SelectedRows[0].DataBoundItem as Order;
                if (selectedOrder != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"确定要删除订单 {selectedOrder.OrderId} 吗？",
                        "删除确认",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // 删除订单
                        orderService.RemoveOrder(selectedOrder.OrderId);

                        // 清空选择，清空明细显示，避免触发 SelectionChanged 中的越界访问
                        OrderGridView.ClearSelection();
                        orderDetailBindingSource.DataSource = null;
                        OrderDetailGridView.DataSource = orderDetailBindingSource.DataSource;

                        // 刷新绑定数据
                        orderBindingSource.DataSource = null;
                        orderBindingSource.DataSource = orderService.orders;
                        OrderGridView.DataSource = orderBindingSource;
                    }
                }
            }
            else //当没有选择项时
            {
                MessageBox.Show("请先选择一个要删除的订单！");
            }
        }


    }
}
