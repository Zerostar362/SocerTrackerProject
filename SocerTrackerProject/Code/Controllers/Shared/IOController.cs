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

            if (Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp") == false)
            {
                Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp");
                this.CheckDirectories();
            }
            bool LocalExists = false;
            bool PublicExists = false;
            bool Account = false;
            bool personal = false;
            bool playercard = false;

            if (Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local") == true)
            {
                LocalExists = true;
            }
            else
            {
                Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local");
            }

            if (Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\Account") == true)
            {
                Account = true;
            }
            else
            {
                Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\Account");
            }

            if (Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\PersonalInfo") == true)
            {
                personal = true;
            }
            else
            {
                Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\PersonalInfo");
            }


            if (Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public") == true)
            {
                PublicExists = true;
            }
            else
            {
                Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public");
            }

            if (Directory.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public\PlayerCard") == true)
            {
                playercard = true;
            }
            else
            {
                Directory.CreateDirectory(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public\PlayerCard");
            }

                if (PublicExists == true && LocalExists == true && Account == true && personal == true && playercard == true)
            {
                this.CheckAllFiles();
            }
            else
            {
                this.CheckDirectories();
            }

        }
     


        /// <summary>
        /// Checks all files, if not found, they are created
        /// </summary>
        public void CheckAllFiles()
        {
            string WindowsUser = Environment.UserName;
            if (File.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\PersonalInfo\PersonalInfo.json") == false)
            {
                File.Create(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\PersonalInfo\PersonalInfo.json");
            }
            if(File.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\Account\Account.json") == false)
            {
                File.Create(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Local\Account\Account.json");
            }
            if(File.Exists(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public\PlayerCard\PlayerCard.json") == false)
            {
                File.Create(@"C:\Users\" + WindowsUser + @"\Documents\TrackerApp\Public\PlayerCard\PlayerCard.json");
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

        public string[] getAllFilesFromFolder(string path)
        {
            if (path.Contains(".json") == true)
            {
                int i = path.Length - 1;
                bool status = false;
                while (status == false)
                {
                    if (path[i].ToString() == @"\")
                    {
                        status = true;
                    }
                    else
                    {
                        i--;
                    }
                }

                path = path.Substring(0, i);
            }

            string[] AllFiles = Directory.GetFiles(path);
            return AllFiles;
        }

        public void CreateFile(string strToSave, string path)
        {
            if (path.Contains(".json") == true)
            {
                int i = path.Length - 1;
                bool status = false;
                while (status == false)
                {
                    if (path[i].ToString() == @"\")
                    {
                        status = true;
                    }
                    else
                    {
                        i--;
                    }
                }

                path = path.Substring(0, i);
            }
            string[] AllFiles = getAllFilesFromFolder(path);
            string ln = AllFiles.Length.ToString();
            strToSave = strToSave + ln;
            File.Create(path + @"\" + strToSave);
        }
    }
}
