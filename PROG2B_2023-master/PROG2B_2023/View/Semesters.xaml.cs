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
using PROG2B_2023.ViewModel;

namespace PROG2B_2023.View
{
    /// <summary>
    /// Interaction logic for Semesters.xaml
    /// </summary>
    public partial class Semesters : UserControl
    {
        public Semesters()
        {
            InitializeComponent();
            // sets the data context of the view to the correct viewmodel
            SemesterViewModel vm = new SemesterViewModel();
            DataContext = vm;
        }
    }
}