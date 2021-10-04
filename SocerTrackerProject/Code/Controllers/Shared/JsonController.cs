using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SocerTrackerProject.Code.Controllers.Shared;

namespace SocerTrackerProject.Code.Controllers
{
    class JsonController : IOController
    {
        public JsonController() 
        {
            
        }
        /// <summary>
        ///   Serialize object data to json
        /// </summary>
        /// <typeparam name="Tvalue">type of object that were trying to serialize</typeparam>
        /// <param name="SerObj">model object with inserted data</param>
        /// <param name="Path">SavePath to the File</param>
        /// <returns></returns>
        protected string Serialize<Tvalue>(object SerObj, string Path)
        {
            string jsonString = JsonSerializer.Serialize<Tvalue>((Tvalue)SerObj);
            return jsonString;
        }

        /// <summary>
        ///   Deserialize json data and parse them to object
        /// </summary>
        /// <typeparam name="Tvalue">type of object</typeparam>
        /// <param name="Path">path to the file</param>
        /// <returns>returns object of a specified type</returns>
        protected object Deserialize<Tvalue>(string Path)
        {
            try
            {
                object DSObject = JsonSerializer.Deserialize<Tvalue>(ReadFile(Path));
                return DSObject;
            }
            catch
            {
                object DSObject = null;
                return DSObject;
            }
        }

    }
}
