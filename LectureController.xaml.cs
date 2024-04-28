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

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для LectureController.xaml
    /// </summary>
    public partial class LectureController : UserControl
    {
        public LectureController()
        {
            InitializeComponent();
        }

        private void CshLect_Click(object sender, RoutedEventArgs e)
        {
            User.Lectures = 1;
            LectureGrd.Children.Clear();
            LectureGrd.Children.Add(new CSharpController());
        }
        private void PyLect_Click(object sender, RoutedEventArgs e)
        {
            User.Lectures = 2;
            LectureGrd.Children.Clear();
            LectureGrd.Children.Add(new CSharpController());
        }
        private void JaLect_Click(object sender, RoutedEventArgs e)
        {
            User.Lectures = 3;
            LectureGrd.Children.Clear();
            LectureGrd.Children.Add(new CSharpController());
        }
    }
}
