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
using System.Windows.Shapes;


namespace Log_In
{
    public partial class SignIn : Window

    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void ForgotPasswordLink_Click(object sender, RoutedEventArgs e)
        {
            ForgotPasswordPage resetPasswordWindow = new ForgotPasswordPage();
            resetPasswordWindow.Show();
            this.Close();
        }

        private void BackToSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage signUpWindow = new SignUpPage();
            signUpWindow.Show();
            this.Close();
        }

        private void TogglePasswordVisibility_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordVisibilityIcon.Source.ToString().Contains("hidePasswordIcon") && txtVisiblePassword.Visibility== Visibility.Collapsed)
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
    }
}
