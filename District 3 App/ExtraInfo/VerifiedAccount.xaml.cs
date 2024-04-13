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

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsPrivacyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FancierProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var paymentForm = new FancierProfilePage();
            Grid.SetColumn(paymentForm, 2);
            Grid.SetRow(paymentForm, 0);
            Grid.SetRowSpan(paymentForm, 4);
            VerifiedAccountGrid.Children.Clear();
            VerifiedAccountGrid.Children.Add(paymentForm);
        }

        private void SavedPostsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseFriendsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VerifiedAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var newContent = new VerifiedAccount();
            Grid.SetColumn(newContent, 2);
            Grid.SetRow(newContent, 0);
            Grid.SetRowSpan(newContent, 4);
            VerifiedAccountGrid.Children.Clear();
            VerifiedAccountGrid.Children.Add(newContent);
        }

        private void FriendsSettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LikedPostsButton_Click(object sender, RoutedEventArgs e)
        {
            var likedPosts = new LikedPosts();
            Grid.SetColumn(likedPosts, 0);
            Grid.SetRowSpan(likedPosts, 4);
            VerifiedAccountGrid.Children.Clear();
            VerifiedAccountGrid.Children.Add(likedPosts);
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            var statistics = new Statistics.Statistics();
            Grid.SetColumn(statistics, 2);
            Grid.SetRowSpan(statistics, 4);
            VerifiedAccountGrid.Children.Clear();
            VerifiedAccountGrid.Children.Add(statistics);
        }
    }
}
