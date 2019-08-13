using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Data
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cb1.Items.Insert(0, "id");//设置值以及默认项
            cb1.Items.Insert(1, "name");
            cb1.SelectedIndex = 0;
            cb2.Items.Insert(0, "name");
            cb2.Items.Insert(1, "class");
            cb2.Items.Insert(2, "age");
            cb2.SelectedIndex = 0;
            cb3.Items.Insert(0, "id");
            cb3.Items.Insert(1, "name");
            cb3.SelectedIndex = 0;
        }
        string con = "Server=localhost;Uid=root;pwd=19990204;Database=testschema;";  //这里是保存连接数据库的字符串
        string sql = "select * from student";                //SQL查询语句
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(con);                //创建SQL连接对象
                conn.Open(); //打开

                MySqlDataAdapter myda = new MySqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                myda.Fill(ds);//填充
                datagrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(con);                //创建SQL连接对象
                conn.Open(); //打开


                string sql1 = "insert into student(name,class,age) value('" + tb3.Text + "','" + tb4.Text + "','" + tb5.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql1, conn);
                cmd.ExecuteNonQuery();//插入 删除 修改

                MySqlDataAdapter myda = new MySqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                myda.Fill(ds);//填充
                datagrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(con);                //创建SQL连接对象
                conn.Open(); //打开


                string sql1 = "update student set " + cb2.Text + "=" + tb2.Text + " where " + cb1.Text +" = " + tb1.Text;
                MySqlCommand cmd = new MySqlCommand(sql1, conn);
                cmd.ExecuteNonQuery();//插入 删除 修改

                MySqlDataAdapter myda = new MySqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                myda.Fill(ds);//填充
                datagrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(con);                //创建SQL连接对象
                conn.Open(); //打开

                string sql1 = "delete from student where " + cb3.Text + " = " + tb6.Text;
                string msg = "确定需要删除属性 " + cb3.Text + " 的值为 " + tb6.Text + " 的这条数据吗？";
                if (MessageBox.Show(msg, "提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)//得到返回值判断是否继续执行
                {
                    MySqlCommand cmd = new MySqlCommand(sql1, conn);
                    cmd.ExecuteNonQuery();//插入 删除 修改
                }
                MySqlDataAdapter myda = new MySqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                myda.Fill(ds);//填充
                datagrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
