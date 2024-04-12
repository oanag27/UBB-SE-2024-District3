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
            /*var newContent = new MainWindow();

            ConfirmationGrid.Children.Clear();
            ConfirmationGrid.Children.Add(newContent);*/
            Window parentWindow = Window.GetWindow(this);

            // Check if the parent window is MainWindow
            if (parentWindow != null && parentWindow is MainWindow mainWindow)
            {
                // Optional: Debugging output
                Console.WriteLine("Parent window found: " + parentWindow.GetType().Name);

                // Check if CC is a valid ContentControl in MainWindow
                if (mainWindow.CC != null)
                {
                    // Optional: Debugging output
                    Console.WriteLine("ContentControl (CC) found in MainWindow");

                    // Set the content of CC to a new UserControl instance (e.g., UserControl1)
                    mainWindow.CC.Content = new UserControl1();
                }
                else
                {
                    // Optional: Debugging output
                    Console.WriteLine("ContentControl (CC) not found in MainWindow");
                }
            }
            else
            {
                // Optional: Debugging output
                Console.WriteLine("Parent window is not MainWindow or not found");
            }
        }
    }
}
