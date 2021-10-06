using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Controllers.Shared
{
    public class Encryption
    {
        public static string encrypt(string str)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
