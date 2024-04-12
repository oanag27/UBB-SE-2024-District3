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

namespace District_3_App.ExtraInfo
{
    /// <summary>
    /// Interaction logic for PaymentConfirmed.xaml
    /// </summary>
    public partial class PaymentConfirmed : UserControl
    {
        public PaymentConfirmed()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newContent = new VerifiedAccount();

            ConfirmationGrid.Children.Clear();
            ConfirmationGrid.Children.Add(newContent);
        }
    }
}
