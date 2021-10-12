using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SocerTrackerProject.Code.Models.PersonalInformation;
using SocerTrackerProject.Code.Models.PlayerCard;

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
        public static string IPaddress { get; set; }
        public static string SerializedInfoModel { get; set; }
        public static string SerializedCardModel { get; set; }
        /// <summary>
        ///   Frame content to switch View content to any page we need is globaly accessible withing this
        ///static object.
        /// </summary>
        /// <example>
        /// ActiveSession.subFrame.Content = new HomePage();
        /// </example>
        public static Frame subFrame { get; set; }

        static ActiveSession()
        { 

        }
    }
}
