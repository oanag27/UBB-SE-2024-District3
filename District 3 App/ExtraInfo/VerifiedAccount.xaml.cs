using District_3_App.Statistics;
using Statistics;
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

namespace District_3_App.ExtraInfo
{
    /// <summary>
    /// Interaction logic for VerifiedAccount.xaml
    /// </summary>
    public partial class VerifiedAccount : UserControl
    {
        public VerifiedAccount()
        {
            InitializeComponent();
        }

        private void ChooseFreeButton_Click(object sender, RoutedEventArgs e)
        {
            //FreeAccountControl.Content = new VerifiedAccount();
            var newContent = new VerifiedAccount();
            Grid.SetColumn(newContent, 2);
            Grid.SetRow(newContent, 0);
            Grid.SetRowSpan(newContent, 4);
            VerifiedAccountGrid.Children.Clear();
            VerifiedAccountGrid.Children.Add(newContent);
        }

        private void ChooseBusinessButton_Click(object sender, RoutedEventArgs e)
        {
            var paymentForm = new PaymentForm();
            Grid.SetColumn(paymentForm, 2);
            Grid.SetRow(paymentForm, 0);
            Grid.SetRowSpan(paymentForm, 4);
            VerifiedAccountGrid.Children.Clear();
            VerifiedAccountGrid.Children.Add(paymentForm);
        }
    }
}
