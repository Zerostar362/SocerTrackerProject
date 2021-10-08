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
using SocerTrackerProject.Code.Models.ActiveSession;
using SocerTrackerProject.WindowContent;

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

       /* private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if(PasswordTextBox.Text == "Password")
            {
                PasswordTextBox.Text = "";
            }
            
        }*/

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
                if(controller.CreateUser(UsernameTextBox.Text, Encryption.encrypt(PasswordTextBox.Password)) == true)
                {
                    ErrorTextBlock.Text = "User created succesfully, proceed to login";
                }
            }
            else
            {
                ErrorTextBlock.Text = "Username is already in use";
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginController controller = new LoginController();
            if(controller.sendLoginForm(UsernameTextBox.Text, Encryption.encrypt(PasswordTextBox.Password)) == true)
            {
                ErrorTextBlock.Text = "Logging in";
                session.Account = UsernameTextBox.Text;
                this.Content = new MainView(session);
            }
            else
            {
                ErrorTextBlock.Text = "Wrong password or username";
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
