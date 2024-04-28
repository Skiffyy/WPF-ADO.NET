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
using System.Windows.Threading;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string dataProvider = "System.Data.SqlClient";
        public static string connectionString = "Data Source=DESKTOP-612CHUJ;Integrated Security=true;Initial Catalog=Diploma";
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
       
        public MainWindow()
        {
            InitializeComponent();

          Greeting.Content = "Welcome, " + User.Login;
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM Subject WHERE CoderID = '{User.CoderID}' AND Subject ='C#'";
                command.CommandType = CommandType.Text;
                DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                        User.CshCount = (int)dataReader["Lect_Count"];
                        User.CshTestOne = (int)dataReader["TestOne"];
                   
                }
                dataReader.Close();
                connection.Close();
            }
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM Subject WHERE CoderID = '{User.CoderID}' AND Subject ='Python'";
                command.CommandType = CommandType.Text;
                DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    
                        User.PyCount = (int)dataReader["Lect_Count"];
                        User.PyTestOne = (int)dataReader["TestOne"];
                   
                }
                dataReader.Close();
                connection.Close();
            }
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM Subject WHERE CoderID = '{User.CoderID}' AND Subject ='Java'";
                command.CommandType = CommandType.Text;
                DbDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    
                        User.JaCount = (int)dataReader["Lect_Count"];
                        User.JaTestOne = (int)dataReader["TestOne"];
                   
                }
                dataReader.Close();
                connection.Close();
            }
        }
        int backcount;
        private void ListMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new HomeController());
                    backcount = 0;
                    break;
                case 1:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new LectureController());
                    StackBack.Visibility = Visibility.Visible;
                    backcount = 1;
                    break;
                case 2:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new TasksController());
                    StackBack.Visibility = Visibility.Visible;
                    backcount = 2;
                    break;
                case 3:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new StatsController());
                    backcount = 0;
                    break;
                case 4:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new CheckControl());
                    backcount = 0;
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            Slider.OnApplyTemplate();
            gridslider.Margin = new Thickness(0, (0 + (60 * index)), 0, 0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Opfunct;
            timer.Start();
        }
        private double op = 0;
        private void Opfunct(object sender, EventArgs e) {
            op += 0.05;
            Greeting.Foreground = new SolidColorBrush
            {
                Color = Colors.Gray,
                Opacity = op
            };
        }

        private void ExitFunc(object sender, RoutedEventArgs e)
        {
            FirstWindow back = new FirstWindow();
            back.Show();
            this.Hide();
        }

        private void SettingsFunc(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new SettingsController());
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            if (backcount == 1)
            {
                GridContent.Children.Clear();
                GridContent.Children.Add(new LectureController());
                
            }
            else if (backcount == 2)
            {
                GridContent.Children.Clear();
                GridContent.Children.Add(new TasksController());

            }
            else
            {
                GridContent.Children.Clear();
                GridContent.Children.Add(new HomeController());
            }

        }
        
    }
}
