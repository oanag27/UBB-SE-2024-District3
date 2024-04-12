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

namespace District_3_App
{
    /// <summary>
    /// Interaction logic for FancierProfilePage.xaml
    /// </summary>
    public partial class FancierProfilePage : UserControl
    {
        public FancierProfilePage()
        {
            InitializeComponent();
        }
        private void AddMottoButton_Click(object sender, RoutedEventArgs e)
        {
            MottoPopUp.IsOpen = !MottoPopUp.IsOpen;
        }

        private void closePopUpButton_Click(object sender, RoutedEventArgs e)
        {
            MottoPopUp.IsOpen = false;
        }

        private void SaveMottoButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = textInputBox.Text;
            MottoPopUp.IsOpen = false;
        }

        private void AddExtraLinksButton_Click(object sender, RoutedEventArgs e)
        {
            LinksPopUp.IsOpen = !LinksPopUp.IsOpen;
        }

        private void closeLinksPopUpButton_Click(object sender, RoutedEventArgs e)
        {
            LinksPopUp.IsOpen = false;
        }

        private void SaveLinksButton_Click(object sender, RoutedEventArgs e)
        {
            string link1 = link1Text.Text;
            string link2 = link2Text.Text;
            LinksPopUp.IsOpen = false;
        }

        private void cancelLinksButton_Click(object sender, RoutedEventArgs e)
        {
            LinksPopUp.IsOpen = false;
        }
    }
}
