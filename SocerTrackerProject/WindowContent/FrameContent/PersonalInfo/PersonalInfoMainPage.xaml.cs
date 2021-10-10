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
using SocerTrackerProject.Code.Models.PersonalInformation;
using SocerTrackerProject.Code.Controllers.Shared;
using SocerTrackerProject.Code.Models.ActiveSession;

namespace SocerTrackerProject.WindowContent.FrameContent.PersonalInfo
{
    /// <summary>
    /// Interaction logic for PersonalInfoMainPage.xaml
    /// </summary>
    public partial class PersonalInfoMainPage : Page
    {
        private PersonalInfoModel model = new PersonalInfoModel();
        /// <summary>
        /// Creates a PersonalInfoView based on active session
        /// </summary>
        public PersonalInfoMainPage()
        {
            InitializeComponent();

            Update();
            PopulateBoxes();
        }

        private void Update()
        {
            List<PersonalInfoModel> modelList = JsonController.getListOfObjects<PersonalInfoModel>(model.defaultSavePath);
            foreach (var profile in modelList)
            {
                if (profile == null) { continue; }
                if (profile.AccountName == ActiveSession.Account)
                {
                    model = profile;
                    break;
                }
            }
        }
        /// <summary>
        /// Adds values to the View
        /// </summary>
        public void PopulateBoxes()
        {
            this.NickName.Text = model.NickName;
            this.Number.Text   = model.Number.ToString();
            this.ForeName.Text = model.ForeName;
            this.Name.Text     = model.Name;
            this.Strong.Text   = model.BiggestWeapon;
            this.Weak.Text     = model.BiggestFear;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.subFrame.Content = new PersonalInfoEditPage();
        }
    }
}
