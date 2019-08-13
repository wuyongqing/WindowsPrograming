using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using calculator;
namespace FinalProject
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        calculator.Calculator myCalculator = new Calculator();//引用
        //分类别计算
        double num_1, num_2;
        int num_3, num_4;

        private void add_Click(object sender, RoutedEventArgs e)
        {
            op.Content = "+";
            if (ifLegal(num1.Text,num2.Text))
            {
                if (ifAllInt(num_1,num_2))
                {
                    result.Content = "=  " + myCalculator.addInt(num_3, num_4).ToString();
                }
                else
                {
                    result.Content = "=  " + myCalculator.addDouble(num_1, num_2).ToString();
                }
            }
            
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            op.Content = "-";
            if (ifLegal(num1.Text, num2.Text))
            {
                if (ifAllInt(num_1, num_2))
                {
                    result.Content = "=  " + myCalculator.minusInt(num_3, num_4).ToString();
                }
                else
                {
                    result.Content = "=  " + myCalculator.minusDouble(num_1, num_2).ToString();
                }
            }
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            op.Content = "*";
            if (ifLegal(num1.Text, num2.Text))
            {
                if (ifAllInt(num_1, num_2))
                {
                    result.Content = "=  " + myCalculator.multiplyInt(num_3, num_4).ToString();
                }
                else
                {
                    result.Content = "=  " + myCalculator.multiplyDouble(num_1, num_2).ToString();
                }
            }
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            op.Content = "/";
            if (ifLegal(num1.Text, num2.Text))
            {
                if (ifAllInt(num_1, num_2))
                {
                    result.Content = "=  " + myCalculator.divideInt(num_3, num_4).ToString();
                }
                else
                {
                    result.Content = "=  " + myCalculator.divideDouble(num_1, num_2).ToString();
                }
            }
        }

        public bool ifAllInt(double a, double b)//判断是否都为整型
        {
            double eps = 1e-10;  // 精度范围  
            return (a - Math.Floor(a) < eps) && (b - Math.Floor(b) < eps);
        }

        public bool ifLegal(string a,string b)//判断输入的字符是否合法
        {
            bool temp = false;
            try
            {
                num_1 = Convert.ToDouble(num1.Text);
                num_2 = Convert.ToDouble(num2.Text);
                if (ifAllInt(num_1,num_2))
                {
                    num_3 = Convert.ToInt32(num1.Text);
                    num_4 = Convert.ToInt32(num2.Text);
                }
                temp = true;
            }
            catch
            {
                MessageBox.Show("请输入数字");
                num1.Clear();
                num2.Clear();
            }
            return temp;
        }
    }
}
