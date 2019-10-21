﻿using CrudWpfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrudWpfCore
{
    /// <summary>
    /// Lógica interna para SongWindown.xaml
    /// </summary>
    public partial class SongWindow : Window
    {
        public SongWindow()
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));

        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
