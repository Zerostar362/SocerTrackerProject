using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SocerTrackerProject.Code.Controllers.Shared;

namespace SocerTrackerProject.Code.Controllers.Shared
{
    class JsonController
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
        public static string Serialize<Tvalue>(object SerObj, string Path)
        {
            string jsonString = JsonSerializer.Serialize(SerObj);
            return jsonString;
        }

        /// <summary>
        ///   Deserialize json data and parse them to object
        /// </summary>
        /// <typeparam name="Tvalue">type of object</typeparam>
        /// <param name="Path">path to the file</param>
        /// <returns>returns object of a specified type</returns>
        public static Tvalue Deserialize<Tvalue>(string Path)
        {
            try
            {
                Tvalue DSObject = JsonSerializer.Deserialize<Tvalue>(IOController.ReadFile(Path));
                return DSObject;
            }
            catch
            {
                Tvalue DSObject = default;
                return DSObject;
            }
        }

        /// <summary>
        ///  Return object list of type Tvalue
        /// </summary>
        /// <typeparam name="Tvalue">Defines the type of object</typeparam>
        /// <param name="Path">Sets path to folder, where are all the json files stored(of the same type(Tvalue))</param>
        /// <returns></returns>
        public static List<Tvalue> getListOfObjects<Tvalue>(string Path)
        {
            string[] FilesArr = IOController.getAllFilesFromFolder(Path);
            int length = FilesArr.Length;

            List<Tvalue> list = new List<Tvalue>();
            var type = typeof(Tvalue);

            for(int i = 0; i <= (length - 1); i++)
            {
                Tvalue obj = (Tvalue)Activator.CreateInstance(type);
                obj = Deserialize<Tvalue>(FilesArr[i]);
                list.Add(obj);
            }
            
            return list;
        }
    }
}
