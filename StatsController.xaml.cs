﻿using System;
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
using LiveCharts;
using LiveCharts.Wpf;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Diploma
{
    /// <summary>
    /// Логика взаимодействия для StatsController.xaml
    /// </summary>
    public partial class StatsController : UserControl
    {
        public StatsController()
        {
            InitializeComponent();
            CshLectRes.Value = User.CshCount;
            PyLectRes.Value = User.PyCount;
            JaLectRes.Value = User.JaCount;
            CshTestRes.Value = User.CshTestOne;
            PyTestRes.Value = User.PyTestOne;
            JaTestRes.Value = User.JaTestOne;
        }
    }
}
