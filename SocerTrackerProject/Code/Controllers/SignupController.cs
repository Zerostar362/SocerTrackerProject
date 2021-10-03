using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocerTrackerProject.Code.Models;

namespace SocerTrackerProject.Code.Controllers
{
    class SignupController : JsonController
    {
        public bool sendSignUpForm(string username ,string Password)
        {
            SignUpModel model = new SignUpModel();
            //SignUpModel model1 = new SignUpModel();
            var type = typeof(SignUpModel);
            object model1 = (SignUpModel)Activator.CreateInstance(type);
            model.Username = username;
            model.Password = Password;
            model1 = Deserialize<SignUpModel>(model.SavePath);
            
        }
    }
}
