using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Models
{
    class AccountModel
    {
        private readonly string savepath = @"C:\Users\" + Environment.UserName+ @"\Documents\TrackerApp\Local\Account.json";

        public string SavePath { get { return savepath; } }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
