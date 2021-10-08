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

namespace SocerTrackerProject.WindowContent.FrameContent.PersonalInfo
{
    /// <summary>
    /// Interaction logic for PersonalInfoMainPage.xaml
    /// </summary>
    public partial class PersonalInfoMainPage : Page
    {
        List<PersonalInfoModel> modelList;
        public PersonalInfoMainPage()
        {
            InitializeComponent();
            PersonalInfoModel model = new PersonalInfoModel();
            List<PersonalInfoModel> modelList = JsonController.getListOfObjects<PersonalInfoModel>(model.SavePath);
            foreach(var profile in modelList)
            {
               // if(profile.AccountName == )
            }
        }

        public void PopulateBoxes()
        {
            //NickName.Text = 
        }
    }
}
