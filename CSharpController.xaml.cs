using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для CSharpController.xaml
    /// </summary>
    public partial class CSharpController : System.Windows.Controls.UserControl
    {
        public static string dataProvider = "System.Data.SqlClient";
        public static string connectionString = "Data Source=DESKTOP-612CHUJ;Integrated Security=true;Initial Catalog=Diploma";
        DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
        public CSharpController()
        {
            InitializeComponent();
            switch (User.Lectures)
            {

                case 1:
                    LectCard.Background = Brushes.LightGreen;
                    break;
                case 2:
                    LectCard.Background = Brushes.Plum;
                    break;
                case 3:
                    LectCard.Background = Brushes.DarkOrange;
                    break;
            }
        }
        int count = 0;
        private void LectMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int index = ListLectCsh.SelectedIndex;
            count = index+1;
            switch (index)
            {
                case 0:

                    FileStream LONE;
                    if (User.Lectures == 1)
                    {
                        LONE = new FileStream("Lectures/C#Lecture0.rtf", FileMode.Open);
                        richLecturesCsharp.Selection.Load(LONE, System.Windows.DataFormats.Rtf);
                        LONE.Close();
                    }
                    else if (User.Lectures == 2)
                    {
                        LONE = new FileStream("Lectures/PyLecture0.rtf", FileMode.Open);
                        richLecturesCsharp.Selection.Load(LONE, System.Windows.DataFormats.Rtf);
                        LONE.Close();
                    }
                    else if(User.Lectures == 3)
                    {
                        LONE = new FileStream("Lectures/JavaLecture0.rtf", FileMode.Open);
                        richLecturesCsharp.Selection.Load(LONE, System.Windows.DataFormats.Rtf);
                        LONE.Close();
                    }
                    break;

                case 1:
                    FileStream LTWO = new FileStream("Lectures/C#Lecture1.rtf", FileMode.Open);
                    richLecturesCsharp.Selection.Load(LTWO, System.Windows.DataFormats.Rtf);
                    LTWO.Close();
                    break;
                case 2:
                    FileStream LTHREE = new FileStream("Lectures/C#Lecture2.rtf", FileMode.Open);
                    richLecturesCsharp.Selection.Load(LTHREE, System.Windows.DataFormats.Rtf);
                    LTHREE.Close();
                    break;
                case 3:
                   
                    break;
                case 4:
                    
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                DbCommand command = factory.CreateCommand();
                command.Connection = connection;
                if (User.Lectures == 1)
                {
                    if (User.CshCount <= count)
                    {
                        User.CshCount = count;
                        command.CommandText = $"Update Subject Set Lect_Count = '{count}' Where CoderId = '{User.CoderID}' AND Subject ='C#'";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                    else System.Windows.MessageBox.Show("You've already read this lecture");
                }
                else if (User.Lectures == 2)
                {
                    if (User.PyCount <= count)
                    {
                        User.PyCount = count;
                        command.CommandText = $"Update Subject Set Lect_Count = '{count}' Where CoderId = '{User.CoderID}' AND Subject ='Python'";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                    else System.Windows.MessageBox.Show("You've already read this lecture");
                }
                else if (User.Lectures == 3)
                {
                    if (User.JaCount <= count)
                    {
                        User.JaCount = count;
                        command.CommandText = $"Update Subject Set Lect_Count = '{count}' Where CoderId = '{User.CoderID}' AND Subject ='Java'";
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                    else System.Windows.MessageBox.Show("You've already read this lecture");
                }
                
                connection.Close();
            }
        }
    }
}
