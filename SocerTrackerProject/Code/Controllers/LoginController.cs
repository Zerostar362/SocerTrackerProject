using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocerTrackerProject.Code.Models;
using SocerTrackerProject.Code.Controllers.Shared;

namespace SocerTrackerProject.Code.Controllers
{
    class LoginController
    {
        /// <summary>
        ///  Sends login request
        /// </summary>
        /// <param name="username">Username from window</param>
        /// <param name="password">Hashed password</param>
        /// <returns>true = username and password matches, false = wrong password/username</returns>
        public bool sendLoginForm(string username, string password)
        {
            AccountModel model = new AccountModel();
            model.Username = username;
            model.Password = password;

            List<AccountModel> list = JsonController.getListOfObjects<AccountModel>(model.defaultSavePath);

            bool status = false;

            if(list == null)
            {
                return false;
            }
            else
            {
                int i = 0;
                foreach (var model1 in list)
                {
                    if (model1 == null) { continue; };
                    if (model1.Username == model.Username) { return true; }
                    i++;
                    if (i == list.Count)
                    {
                        status = true;
                    }
                }

                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
