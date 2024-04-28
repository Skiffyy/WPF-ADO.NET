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
    /// Логика взаимодействия для TasksController.xaml
    /// </summary>
    public partial class TasksController : UserControl
    {
        public TasksController()
        {
            InitializeComponent();
        }

        private void CSharpTestBtn_Click(object sender, RoutedEventArgs e)
        {
            TestGrid.Children.Clear();
            TestGrid.Children.Add(new CsharpTestController());
        }

        private void PyTestBtn_Click(object sender, RoutedEventArgs e)
        {
            TestGrid.Children.Clear();
            TestGrid.Children.Add(new PyTestController());
        }
        private void JaTestBtn_Click(object sender, RoutedEventArgs e)
        {
            TestGrid.Children.Clear();
            TestGrid.Children.Add(new JaTestController());
        }
    }
}
