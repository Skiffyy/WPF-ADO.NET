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
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для CsharpTestController.xaml
    /// </summary>
    public partial class CsharpTestController : UserControl
    {
        public static string dataProvider = "System.Data.SqlClient";
        public static string connectionString = "Data Source=DESKTOP-612CHUJ;Integrated Security=true;Initial Catalog=Diploma";
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

        public CsharpTestController()
        {
            InitializeComponent();
            string[] q1 = { "(some && a != 2) || b > 5", "(b <= 5 || a == 3) && some", "(b > 5 && a <= 3) || (!some || a < 1)", "some || a == 4 || b < 3" };

            ComboTest11.Content = q1[0];
            ComboTest12.Content = q1[1];
            ComboTest13.Content = q1[2];
            ComboTest14.Content = q1[3];



        }

        private void TestMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListTestCsh.SelectedIndex;
            switch (index)
            {
                case 0:
                   
                    break;
                case 1:
                    Scrolling(46);
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
        private void Scrolling(int lines)
        {
            for (int i = 0; i < lines; i++)
                ScrollTest.LineDown();
        }

        private void CsharpTestOne(object sender, RoutedEventArgs e)
        {
            int count = 0;
            if (ComboBox1.SelectedIndex == 2)
            {
                count++;
            }
            if (ComboBox2.SelectedIndex == 2)
            {
                count++;
            }
            if (ComboBox3.SelectedIndex == 3)
            {
                count++;
            }
            if (ComboBox4.SelectedIndex == 3)
            {
                count++;
            }
            if (ComboBox5.SelectedIndex == 2)
            {
                count++;
            }
            if (ComboBox6.SelectedIndex == 2)
            {
                count++;
            }
            if (ComboBox7.SelectedIndex == 3)
            {
                count++;
            }
            if (ComboBox8.SelectedIndex == 3)
            {
                count++;
            }
            if (ComboBox9.SelectedIndex == 2)
            {
                count++;
            }
            if (ComboBox10.SelectedIndex == 1)
            {
                count++;
            }
            if (count >= 6)
            {
                MessageBox.Show($"You have {count} correct answers");
                using (DbConnection connection = factory.CreateConnection())
                {
                    User.CshTestOne = count;
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    DbCommand command = factory.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = $"UPDATE Subject Set TestOne = '{count}' WHERE Subject ='C#' AND CoderID ='{User.CoderID}'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else { MessageBox.Show("You didn't have enough right answers"); }
        }

    }
}
