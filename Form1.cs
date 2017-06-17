using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CalcTest
{
    public partial class Form1 : Form
    {
        private double? value;
        private String operation;
        bool operationPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Clik(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((Screen.Text == "0") && (b.Text!=",") || operationPressed == true)
            {
                if (b.Text == ",")
                {
                    Screen.Text = "0" + b.Text;
                }
                else
                    Screen.Clear();
            }
            operationPressed = false;

            if (b.Text == ",")
            {
                if (!Screen.Text.Contains(","))
                {
                    Screen.Text += b.Text;
                }
            }
            else
                Screen.Text += b.Text;

        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operationPressed = true;
            value = double.Parse(Screen.Text);
            operation = (b.Text).ToString();
        }

        private void equel_Click(object sender, EventArgs e)
        {
            if (value != null)
            {
                switch (operation)
                {
                    case "+":
                        Screen.Text = (value + double.Parse(Screen.Text)).ToString();
                        break;
                    case "-":
                        Screen.Text = (value - double.Parse(Screen.Text)).ToString();
                        break;
                    case "*":
                        Screen.Text = (value * double.Parse(Screen.Text)).ToString();
                        break;
                    case "/":
                        if (Screen.Text != "0")
                        {
                            Screen.Text = (value / double.Parse(Screen.Text)).ToString();
                        }
                        else
                        {
                            //Screen.Text = "FUCK YOU!";
                            //Thread.Sleep(500);
                            btnClearAll.PerformClick();
                            MessageBox.Show("Nice try!");
                        }
                        break;
                    default:
                        break;
                }

                value = null;
            }
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            Screen.Text = "0";
            value = null;
            operationPressed = false;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Screen.Text = "0";
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            Screen.Text = (Math.Sqrt(double.Parse(Screen.Text))).ToString();
        }

        private void pow_Click(object sender, EventArgs e)
        {
            Screen.Text = Math.Pow(double.Parse(Screen.Text), 2).ToString();
        }
    }
}
