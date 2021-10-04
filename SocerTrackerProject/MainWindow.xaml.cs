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
using SocerTrackerProject.Code.Controllers;
using SocerTrackerProject.Code.Controllers.Shared;

namespace SocerTrackerProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IOController FileControler = new IOController();
            FileControler.CheckDirectories();
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if(PasswordTextBox.Text == "Password")
            {
                PasswordTextBox.Text = "";
            }
            
        }

        private void Username_GotFocus(object sender, RoutedEventArgs e)
        {
            if(UsernameTextBox.Text == "Username")
            {
                UsernameTextBox.Text = "";
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = false;
            SignupController controller = new SignupController();
            isValid = controller.sendSignUpForm(UsernameTextBox.Text);
            if(isValid == true)
            {
                controller.CreateUser(UsernameTextBox.Text, PasswordTextBox.Text);
            }
            else
            {
                ErrorTextBlock.Text = "Username is already in use";
            }
        }
    }
}
