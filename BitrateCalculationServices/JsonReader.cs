using Bitrate_calculation.Models;
using Newtonsoft.Json.Linq;
namespace BitrateCalculationServices
{
    public class JsonReader
    {
        private readonly string _jsonFilePath;


        public JsonReader(string jsonFilePath )
        {
            _jsonFilePath = jsonFilePath;
        }


        public JObject ReadFromJson()
        {
            if (!File.Exists(_jsonFilePath))
                throw new FileNotFoundException("JSON file not found.", _jsonFilePath);

            string json = File.ReadAllText(_jsonFilePath);
            return JObject.Parse(json);
        }

        public JArray? ReadFromJsonArray(string key)
        {
            JObject jsonData;
            JArray? jsonArray;

            try
            {
                jsonData = ReadFromJson();
            }
            catch (Exception)
            {
                return null;
            }

            if (jsonData.ContainsKey(key))
                jsonArray = jsonData[key] as JArray;

            else
            {
                Console.WriteLine("No property with given key");
                return null;
            }

            return jsonArray;

        }

    }
}
