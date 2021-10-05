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

        /// <summary>
        ///  Opens everything in text file, closes it aftewards
        /// </summary>
        /// <param name="Path">Path to file</param>
        /// <returns>Content of a text file</returns>
        public string ReadFile(string Path)
        {
            return File.ReadAllText(Path);
        }
        /// <summary>
        ///  Gets all file names from folder
        /// </summary>
        /// <param name="path">Path to folder</param>
        /// <returns>Array of file names</returns>
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
        /// <summary>
        /// Creates a new file with a position number, close it aftewards
        /// </summary>
        /// <param name="path">path to default File from model</param>
        /// <returns>path to newly created file</returns>
        public string CreateFile(string path)
        {
            string FolderPath;
            int i = path.Length - 1;
            int o = path.Length - 1;
            bool status = false;
            bool status2 = false;
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

            while (status2 == false)
            {
                if (path[o].ToString() == @".")
                {
                    status2 = true;
                }
                else
                {
                    o--;
                }
            }

            FolderPath = path.Substring(0, i);
            string[] AllFiles = getAllFilesFromFolder(FolderPath);
            path = path.Substring(0,o);
            string ln = AllFiles.Length.ToString();
            path = path + ln + ".json";
            File.Create(path).Close();
            return path;
        }
        /// <summary>
        /// Appends all text to text file
        /// </summary>
        /// <param name="ToAppend">Text to append into the text file</param>
        /// <param name="path">path to file</param>
        public void AppendToFile(string ToAppend, string path)
        {
            File.AppendAllText(path, ToAppend);
        }
    }
}
