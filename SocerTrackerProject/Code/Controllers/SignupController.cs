using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocerTrackerProject.Code.Models;
using SocerTrackerProject.Code.Controllers.Shared;

namespace SocerTrackerProject.Code.Controllers
{
    class SignupController : JsonController
    {
        public bool sendSignUpForm(string username)
        {
            AccountModel model = new AccountModel();
            model.Username = username;
            //model.Password = Password;
            AccountModel model1 = (AccountModel)Deserialize<AccountModel>(model.SavePath);
            if (model1 == null)
            {
                return true;
            }
            else
            {
                if (model1.Username == model.Username) { return false; }
                else { return true; };
            }
        }

        public void CreateUser(string username, string password)
        {
            IOController FileController = new IOController();
            //checking if folderExists
            FileController.CheckDirectories();
            AccountModel model = new AccountModel();

            model.Username = username;
            model.Password = password;

            FileController.AddToExistingFile(Serialize<AccountModel>(model, model.SavePath),model.SavePath);
        }
    }
}
