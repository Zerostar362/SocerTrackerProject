using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Models
{
    class SignUpModel
    {
        private string savepath = @"C:\Users\Adam\Documents\SocerCounter\Local\Account.json";

        public string SavePath { get { return savepath; } }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
