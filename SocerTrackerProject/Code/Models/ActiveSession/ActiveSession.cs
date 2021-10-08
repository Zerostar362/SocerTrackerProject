using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Models.ActiveSession
{
    /// <summary>
    /// Static active session model
    /// Class with global acces
    /// Important information like active logged in account is stored here
    /// !!!IMPORTANT BE CAREFUL WHEN MANIPULATING WITH ACTIVE ACCOUNT, IT'S USED TO
    /// GET THE RIGHT DATA FILES AND IS CURRENTLY THE ONLY THING THAT TIES IT UP!!!
    /// </summary>
    public static class ActiveSession
    {
        public static string Account { get; set; }

        static ActiveSession() 
        {
            
        }
    }
}
