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
            bool status = false;
            AccountModel model = new AccountModel();
            model.Username = username;
            //model.Password = Password;
            List<AccountModel> accountModelsList;


            accountModelsList = getListOfObjects<AccountModel>(model.SavePath);
            //(List<AccountModel>)Deserialize<AccountModel>(model.SavePath);
            if (accountModelsList == null)
            {
                return true;
            }
            else
            {
                int i = 0;
                foreach(var model1 in accountModelsList)
                {
                    if (model1.Username == model.Username) { return false; }
                    i++;
                    if(i == accountModelsList.Count)
                    {
                        status = true;
                    }
                }

                if(status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

            FileController.CreateFile(Serialize<AccountModel>(model, model.SavePath),model.SavePath);
        }
    }
}
