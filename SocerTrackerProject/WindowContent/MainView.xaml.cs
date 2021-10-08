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
using SocerTrackerProject.Code.Models.ActiveSession;
using SocerTrackerProject.WindowContent.FrameContent;
using SocerTrackerProject.WindowContent.FrameContent.PersonalInfo;

namespace SocerTrackerProject.WindowContent
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        /// <summary>
        /// Main after login View
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            subFrame.Content = new HomePage();
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            CurrentPlayerNickName.Text = version.Major.ToString() + "." + version.Minor.ToString() +"."+ version.Build.ToString();
        }
        /// <summary>
        /// Turns off the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Opens the My Profile view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            subFrame.Content = new PersonalInfoMainPage();
        }
    }
}
