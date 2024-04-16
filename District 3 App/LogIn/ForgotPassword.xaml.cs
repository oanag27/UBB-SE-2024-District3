using Log_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace District_3_App.LogIn
{
    public partial class ForgotPassword : UserControl
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void BackToSignIn_Click(object sender, RoutedEventArgs e)
        {
            ResetPasswordGrid.Children.Clear();
            var newContent = new SignInPage();
            Grid.SetColumn(newContent, 2);
            Grid.SetRow(newContent, 0);
            Grid.SetRowSpan(newContent, 6);
            ResetPasswordGrid.Children.Add(newContent);
        }

        private void TogglePasswordVisibility_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordVisibilityIcon.Source.ToString().Contains("hidePasswordIcon") && txtVisiblePassword.Visibility == Visibility.Collapsed)
            {
                txtNewPassword.Visibility = Visibility.Collapsed;
                txtVisiblePassword.Visibility = Visibility.Visible;
                PasswordVisibilityIcon.Source = new BitmapImage(new Uri("pack://application:,,,/images/showPasswordIcon.png"));
                txtVisiblePassword.Text = txtNewPassword.Password;
            }
            else
            {
                txtNewPassword.Visibility = Visibility.Visible;
                txtVisiblePassword.Visibility = Visibility.Collapsed;
                PasswordVisibilityIcon.Source = new BitmapImage(new Uri("pack://application:,,,/images/hidePasswordIcon.png"));
                txtNewPassword.Password = txtVisiblePassword.Text;
            }
        }

        private void ResetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            if (!ValidateNewPassword(txtNewPassword.Password))
            {
                MessageBox.Show("Invalid password. The password's length must be between 5 and 10 characters and must contain at least one uppercase letter, one lowercase letter, one number, and one special character(/_-.)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            if (isValid)
            {
                var newContent = new SignInPage();
                ResetPasswordGrid.Children.Clear();
                ResetPasswordGrid.Children.Add(newContent);
            }
        }


        private bool ValidateNewPassword(string newPassword)
        {
            var hasNumericChar = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSpecialChar = new Regex(@"[/\-_.]+");
            var hasMiniMaxChars = new Regex(@".{5,10}");

            if (hasNumericChar.IsMatch(newPassword) && hasUpperChar.IsMatch(newPassword) && hasLowerChar.IsMatch(newPassword) && hasSpecialChar.IsMatch(newPassword) && hasMiniMaxChars.IsMatch(newPassword))
            {
                return true;
            }
            return false;
        }
    }
}

