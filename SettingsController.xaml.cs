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
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для SettingsController.xaml
    /// </summary>
    public partial class SettingsController : UserControl
    {
        public static string dataProvider = "System.Data.SqlClient";
        public static string connectionString = "Data Source=DESKTOP-612CHUJ;Integrated Security=true;Initial Catalog=Diploma";
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

        public SettingsController()
        {
           
            InitializeComponent();
            Setngemail.Content = User.Email;
            SetLog.Content = User.Login;
            SetPass.Content = "**********";
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
               
                DbCommand command = factory.CreateCommand();
                command.Connection = connection;
                if (EditEmail.Text != null)
                {
                    command.CommandText = $"Update Coders Set Email = '{EditEmail.Text}' Where CoderId = '{User.CoderID}'";
                   
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    User.Email = EditEmail.Text;
                }
                if (EditLogin.Text != null)
                {
                    command.CommandText = $"Update Coders Set Login = '{EditLogin.Text}' Where CoderId = '{User.CoderID}'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    User.Login = EditLogin.Text;
                }
               if (EditPassword.Text != null)
                {
                    command.CommandText = $"Update Coders Set Password = '{EditPassword.Text}' Where CoderId = '{User.CoderID}'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                    User.Password = EditPassword.Text;
                }
               
                connection.Close();
            }
        }
    }
}
