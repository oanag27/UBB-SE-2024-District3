using District_3_App.ExtraInfo;
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
    public partial class SignInPage : UserControl
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            SignInGrid.Children.Clear();
            var newContent = new ForgotPassword();
            Grid.SetColumn(newContent, 2);
            Grid.SetRow(newContent, 0);
            Grid.SetRowSpan(newContent, 4);
            SignInGrid.Children.Add(newContent);
        }

        private void BackToSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignInGrid.Children.Clear();
            var newContent = new SignUp();
            Grid.SetColumn(newContent, 2);
            Grid.SetRow(newContent, 0);
            Grid.SetRowSpan(newContent, 4);
            SignInGrid.Children.Add(newContent);
        }

        private void TogglePasswordVisibility_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordVisibilityIcon.Source.ToString().Contains("hidePasswordIcon") && txtVisiblePassword.Visibility == Visibility.Collapsed)
            {
                txtPassword.Visibility = Visibility.Collapsed;
                txtVisiblePassword.Visibility = Visibility.Visible;
                PasswordVisibilityIcon.Source = new BitmapImage(new Uri("pack://application:,,,/images/showPasswordIcon.png"));
                txtVisiblePassword.Text = txtPassword.Password;
            }
            else
            {
                txtPassword.Visibility = Visibility.Visible;
                txtVisiblePassword.Visibility = Visibility.Collapsed;
                PasswordVisibilityIcon.Source = new BitmapImage(new Uri("pack://application:,,,/images/hidePasswordIcon.png"));
                txtPassword.Password = txtVisiblePassword.Text;
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            if(!ValidateUsernameOrEmail(txtUsernameAndEmail.Text)) 
            {
                MessageBox.Show("Invalid usernsme or email.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            if (!ValidatePassword(txtPassword.Password))
            {
                MessageBox.Show("Invalid password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            if (isValid)
            {
                var newContent = new MainWindow();
                newContent.Show();
                Window.GetWindow(this).Close();
            }
                
           
        }

        private bool ValidateUsernameOrEmail(string usernameOrEmail)
        {
            var hasMiniMaxCharsUsername = new Regex(@".{5,11}");
            var hasNumericChar = new Regex(@"[0-9]+");
            var hasAlphabeticChar = new Regex(@"[A-Za-z]");
            var hasSpecialChar = new Regex(@"[_.]");

            if(hasMiniMaxCharsUsername.IsMatch(usernameOrEmail) && hasNumericChar.IsMatch(usernameOrEmail) && hasAlphabeticChar.IsMatch(usernameOrEmail) && hasSpecialChar.IsMatch(usernameOrEmail))
            {
                return true;
            }
            else if (Regex.IsMatch(usernameOrEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private bool ValidatePassword(string password)
        {
            var hasNumericChar = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSpecialChar = new Regex(@"[/\-_.]+");
            var hasMiniMaxChars = new Regex(@".{5,10}");

            bool isPasswordValid = hasNumericChar.IsMatch(password) && hasUpperChar.IsMatch(password) && hasLowerChar.IsMatch(password) && hasSpecialChar.IsMatch(password) && hasMiniMaxChars.IsMatch(password);
            return isPasswordValid;
        }
    }
}
