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
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для CheckControl.xaml
    /// </summary>
    public partial class CheckControl : UserControl
    {
        public CheckControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", FrameTbox.Text } });
            CompilerParameters parameters = new CompilerParameters(new string[] { "mscorlib.dll", "System.Core.dll" }, FName.Text, true);
            parameters.GenerateExecutable = true;
            string richText = new TextRange(CodeBox.Document.ContentStart, CodeBox.Document.ContentEnd).Text;
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, richText);

            if (results.Errors.HasErrors)
            {
                foreach (CompilerError error in results.Errors.Cast<CompilerError>())
                {
                    statusBox.AppendText($"Строка {error.Line}:   {error.ErrorText}");
                }
            }
            else
            {
                statusBox.AppendText("---assembly compiled---");
                Process.Start($"{System.AppDomain.CurrentDomain.BaseDirectory}/{FName.Text}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            statusBox.Document.Blocks.Clear();
        }
    }
}
