using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Models.ActiveSession
{
    public class ForeignSessions
    {
        public string Account { get; set; }
        public string IPaddress { get; set; }
        public string SerializedInfoModel { get; set; }
        public string SerializedCardModel { get; set; }
    }
}
