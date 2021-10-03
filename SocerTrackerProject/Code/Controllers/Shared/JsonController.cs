using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocerTrackerProject.Code.Controllers
{
    class JsonController 
    {
        public JsonController() 
        {
            
        }
        
        public string Serialize<Tvalue>(object SerObj)
        {
            string jsonString = JsonSerializer.Serialize(SerObj);
            return jsonString;
        }

        protected object Deserialize<Tvalue>(string Path)
        {
            var type = typeof(Tvalue);
            object model1 = (Tvalue)Activator.CreateInstance(type);
            object DSObject = JsonSerializer.Deserialize<Tvalue>(Path);
            return DSObject;
        }

    }
}
