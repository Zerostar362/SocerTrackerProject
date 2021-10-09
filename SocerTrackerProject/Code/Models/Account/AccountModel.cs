using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Models
{
    class AccountModel
    {
        private readonly string savepath = @"C:\Users\" + Environment.UserName+ @"\Documents\TrackerApp\Local\Account\Account.json";

        public string defaultSavePath { get { return savepath; } }
        public string SavePath { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
