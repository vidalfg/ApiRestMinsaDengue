using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WebApiDengue.Resources.Utility
{
    public class Funciones
    {
        // Validate if a string is a valid JSON
        public bool IsValidJson(string input)
        {
            try
            {
                JToken.Parse(input);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}
