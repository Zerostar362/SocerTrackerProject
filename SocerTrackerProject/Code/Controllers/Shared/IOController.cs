using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SocerTrackerProject.Code.Controllers.Shared
{
    class IOController
    {
        public IOController()
        {

        }

        /// <summary>
        /// Checks all directories, if not found, they are created
        /// </summary>
        public void CheckDirectories()
        {
            string WindowsUser = Environment.UserName;

            if(Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp") == false)
            {
                Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp");
                this.CheckDirectories();
            }
            else
            {
                bool LocalExists = false;
                bool PublicExists = false;

                if(Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local") == true)
                {
                    LocalExists = true;
                }
                else
                {
                    Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local");
                }

                if(Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public") == true)
                {
                    PublicExists = true;
                }
                else
                {
                    Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public");
                }

                if(PublicExists == true && LocalExists == true)
                {
                    this.CheckAllFiles();
                }
                else
                {
                    this.CheckDirectories();
                }

            }
        }


        /// <summary>
        /// Checks all files, if not found, they are created
        /// </summary>
        public void CheckAllFiles()
        {
            string WindowsUser = Environment.UserName;
            if (File.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\PersonalInfo.json") == false)
            {
                File.Create(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\PersonalInfo.json");
            }
            if(File.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\Account.json") == false)
            {
                File.Create(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\Account.json");
            }
            if(File.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public\PlayerCard.json") == false)
            {
                File.Create(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public\PlayerCard.json.json");
            }
        }

        public void AddToExistingFile(string ToAdd, string Path)
        {
            File.AppendAllText(Path, ToAdd);
        }

        public string ReadFile(string Path)
        {
            return File.ReadAllText(Path);
        }
    }
}
