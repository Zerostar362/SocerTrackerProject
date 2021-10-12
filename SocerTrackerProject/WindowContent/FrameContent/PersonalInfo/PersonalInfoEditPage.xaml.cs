using SocerTrackerProject.Code.Controllers.Shared;
using SocerTrackerProject.Code.Models.ActiveSession;
using SocerTrackerProject.Code.Models.PersonalInformation;
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

namespace SocerTrackerProject.WindowContent.FrameContent.PersonalInfo
{
    /// <summary>
    /// Interaction logic for PersonalInfoEditPage.xaml
    /// </summary>
    public partial class PersonalInfoEditPage : Page
    {
        public PersonalInfoEditPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ActiveSession.subFrame.GoBack();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if(NickName.Text != "" 
                && Name.Text != "" 
                && ForeName.Text != "" 
                && Int32.TryParse(Number.Text,out num) != false  
                && Strong.Text != "" 
                && Weak.Text != "")
            {
                if(!NickName.Text.Contains(" ")
                    || !Name.Text.Contains(" ")
                    || !ForeName.Text.Contains(" "))
                {
                    PersonalInfoModel model = new PersonalInfoModel();
                    model.NickName = NickName.Text;
                    model.Name = Name.Text;
                    model.ForeName = ForeName.Text;
                    model.Number = num;
                    model.BiggestWeapon = Strong.Text;
                    model.BiggestFear = Weak.Text;
                    model.AccountName = ActiveSession.Account;
                    List<PersonalInfoModel> list = JsonController.getListOfObjects<PersonalInfoModel>(model.defaultSavePath);
                    foreach (var item in list)
                    {
                        if (item == null) continue;
                        if(item.AccountName == ActiveSession.Account)
                        {
                            model.SavePath = item.SavePath;
                            IOController.DeleteTextFromFile(item.SavePath);
                            
                            IOController.AppendToFile(JsonController.Serialize<PersonalInfoModel>(model, item.SavePath),item.SavePath);
                            ActiveSession.SerializedInfoModel = JsonController.Serialize<PersonalInfoModel>(model, item.SavePath);
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No spaces allow in Nickname, name and forename.");
                }
            }
            else
            {
                MessageBox.Show("All the fields has to be filled!");
            }
            ActiveSession.subFrame.GoBack();
        }
    }
}
