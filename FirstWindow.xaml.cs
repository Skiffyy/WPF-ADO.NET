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
using System.Windows.Shapes;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        public static string dataProvider = "System.Data.SqlClient";
        public static string connectionString = "Data Source=DESKTOP-612CHUJ;Integrated Security=true;Initial Catalog=Diploma";
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);


        public FirstWindow()
        {
            InitializeComponent();

        }



        private void Login_Click(object sender, RoutedEventArgs e)
        {

            // User user = new User();
            User.Login = LoginLog.Text;
            User.Password = LoginPass.Password;
            //using (DbConnection connection = factory.CreateConnection())
            //{
            //    connection.ConnectionString = connectionString;

            //    connection.Open();

            //    DbCommand command = factory.CreateCommand();
            //    DbDataAdapter adapter = factory.CreateDataAdapter();
            //    DataTable table = new DataTable();

            //    command.Connection = connection;
            //    command.CommandText = $"SELECT * FROM Coders WHERE Login = '{User.Login}' AND Password='{User.Password}'";
            //    command.CommandType = CommandType.Text;

            //    adapter.SelectCommand = command;
            //    adapter.Fill(table);

            //    if (table.Rows.Count > 0)
            //    {
            //        DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //        while (dataReader.Read())
            //        {
            //            User.CoderID = (int)dataReader["CoderId"];
            //            User.Email = (string)dataReader["Email"];


            //        }

            //        MainWindow content = new MainWindow();
            //        content.Show();
            //        this.Hide();
            //    }
            //    else { MessageBox.Show("Sorry, there's no such user. Please register first"); }
            //    connection.Close();
            //}
            MainWindow content = new MainWindow();
            content.Show();
            this.Hide();

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                if (RegEmail.Text != "")
                {
                    if (RegLog.Text != "")
                    {
                        string pswrd = RegPass.Text;
                        int length = pswrd.Length;
                        if (RegPass.Text == RegRepeatPass.Text && RegRepeatPass.Text != "" && length >= 8)
                        {
                            DbCommand command = factory.CreateCommand();

                            command.Connection = connection;
                            command.CommandText = $"INSERT INTO Coders (Email,Login,Password) VALUES ('{RegEmail.Text}','{RegLog.Text}', '{RegPass.Text}')";
                            command.CommandType = CommandType.Text;
                            try  // описать в дипломме,что хотел сделать проверку ифами но вілетало всегда исключение от програмы что логин уже есть
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("You,ve successfully registered. Please sign in with your new data");

                                //сделать переменную и в датарид записать в неё создавшийся кодерИД. После командой вписать три строки с именами предметов и кодерИД
                                //  $"INSERT INTO Subject (CoderID, Subject) VALUES ('{}')"
                            }
                            catch
                            {
                                MessageBox.Show("There is such user");
                            }
                            finally
                            {
                                DbCommand command2 = factory.CreateCommand();
                                command2.Connection = connection;
                                command2.CommandText = $"SELECT * FROM Coders WHERE Login = '{RegLog.Text}'";
                                command2.CommandType = CommandType.Text;
                                DbDataReader dataReader = command2.ExecuteReader(CommandBehavior.CloseConnection);
                                while (dataReader.Read())
                                {
                                    User.RegCoderID = (int)dataReader["CoderId"];
                                    Insert_Subject();
                                }
                                dataReader.Close();

                            }
                        }
                        else MessageBox.Show("Check your password info( 1. At least 8 characters. 2. Repeated password must be the same.)");
                    }
                    else MessageBox.Show("Enter Login");
                }
                else MessageBox.Show("Enter email");
                connection.Close();
            }
        }
        public void Insert_Subject()
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command3 = factory.CreateCommand();
                command3.Connection = connection;
                command3.CommandText = $"INSERT INTO Subject (CoderID, Subject,Lect_Count,TestOne) VALUES ('{User.RegCoderID}','C#','{0}','{0}'),('{User.RegCoderID}','Python','{0}','{0}'),('{User.RegCoderID}','Java','{0}','{0}')";
                command3.CommandType = CommandType.Text;
                command3.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}