using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework2
{
    public partial class WindowsFormCalculator : Form
    {
        // 两个操作数
        double Num1 = 0;
        double Num2 = 1;
        char op = ' ';
        double Result = 0;
        bool num1Flag = false; //判断是否输入了第一个操作数
        bool num2Flag = false; //判断是否输入了第二个操作数
        bool operatorFlag = false; //判断是否输入了操作符
        public WindowsFormCalculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 0)
            {
                operatorFlag = true;
                op = Convert.ToChar(comboBox1.Text);
            }
            else
                operatorFlag = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (num1.Text.Length > 0)
            {
                num1Flag = true;
                Num1 = Convert.ToDouble(num1.Text);
            }
            else
                num1Flag = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (num2.Text.Length > 0)
            {
                Num2 = Convert.ToDouble(num2.Text);
                num2Flag = true;
            }
            else
                num2Flag = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (num1Flag == false || num2Flag == false)
            {
                MessageBox.Show("Please input the number!");
            }
            if(operatorFlag == false)
                {
                MessageBox.Show("Please select the operator!");
            }
            else
            {
                switch (op)
                {
                    case '+':
                        op = '+';
                        Result = Num1 + Num2;
                        break;
                    case '-':
                        op = '-';
                        Result = Num1 - Num2;
                        break;
                    case '*':
                        op = '*';
                        Result = Num1 * Num2;
                        break;
                    case '/':
                        op = '/';
                        if (Num2 == 0)
                        {
                            MessageBox.Show("The second number can't be zero!");
                        }
                        else
                        {
                            Result = Num1 / Num2;
                        }
                        break;
                    default:
                        MessageBox.Show("Please select the operator!");
                        break;
                }
                if(num1Flag && num2Flag && operatorFlag)
                    MessageBox.Show(Num1 + " " + op + " " + Num2 + " = " + Result);
            }
        }
    }
}
