using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Models.PersonalInformation
{
    class PersonalInfoModel
    {
        private readonly string savepath = @"C:\Users\" + Environment.UserName + @"\Documents\TrackerApp\Local\PersonalInfo\PersonalInfo.json";

        public string SavePath { get { return savepath; } }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string ForeName { get; set; }
        public int Number { get; set; }
        public string BiggestWeapon { get; set; }
        public string BiggestFear { get; set; }
    }
}
