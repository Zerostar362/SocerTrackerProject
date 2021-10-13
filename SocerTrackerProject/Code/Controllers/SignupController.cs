using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocerTrackerProject.Code.Models;
using SocerTrackerProject.Code.Controllers.Shared;
using SocerTrackerProject.Code.Models.PersonalInformation;
using SocerTrackerProject.Code.Models.PlayerCard;

namespace SocerTrackerProject.Code.Controllers
{
    class SignupController : JsonController
    {
        /// <summary>
        ///  Creates a signup request
        /// </summary>
        /// <param name="username">sends the username fro check</param>
        /// <returns>true means the username is free to use, false means username is already taken by another user</returns>
        public bool sendSignUpForm(string username)
        {
            bool status = false;
            AccountModel model = new AccountModel();
            model.Username = username;
            List<AccountModel> accountModelsList;


            accountModelsList = getListOfObjects<AccountModel>(model.defaultSavePath);
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
                    if(model1 == null) { return true; };
                    if (model1.Username == model.Username) { return false; }
                    i++;
                    if(i == accountModelsList.Count)
                    {
                        status = true;
                    }
                }

                if(status == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// Creates a new user with all the dependecies, that means personalInfo car, player card etc.
        /// </summary>
        /// <param name="username">Username from login window</param>
        /// <param name="password">Password from login window</param>
        public bool CreateUser(string username, string password)
        {
            IOController FileController = new IOController();
            //checking if folderExists
            FileController.CheckDirectories();
            AccountModel model = new AccountModel();
            PersonalInfoModel persModel = new PersonalInfoModel();
            PlayerCardModel cardModel = new PlayerCardModel();

            model.Username = username;
            model.Password = password;

            persModel.AccountName = username;

            cardModel.AccountName = username;

            string newPath = IOController.CreateFile(model.defaultSavePath);
            model.SavePath = newPath;

            string persPath = IOController.CreateFile(persModel.defaultSavePath);
            persModel.SavePath = persPath;

            string carPath = IOController.CreateFile(cardModel.defaultSavePath);
            cardModel.SavePath = carPath;

            IOController.AppendToFile(Serialize<AccountModel>(model), newPath);
            IOController.AppendToFile(Serialize<PersonalInfoModel>(persModel), persPath);
            IOController.AppendToFile(Serialize<PlayerCardModel>(cardModel), carPath);
            return true;
        }
    }
}
