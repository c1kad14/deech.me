using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace deech.me.import.models
{
    public class Configuration
    {
        private static Configuration _instance;
        public string ImportFolder { get; private set; }
        public string ProcessedFolder { get; private set; }
        public string ConnectionString { get; private set; }

        private Configuration()
        {
            using var reader = new StreamReader(Constants.CONFIG_FILE);
            var configJson = JsonConvert.DeserializeObject<JObject>(reader.ReadToEnd());

            ImportFolder = configJson.GetValue(Constants.IMPORT_FOLDER_FIELD).ToString();
            ProcessedFolder = configJson.GetValue(Constants.PROCESSED_FOLDER_FIELD).ToString();
            ConnectionString = configJson.GetValue(Constants.CONNECTION_STRING_FIELD).ToString();
        }

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }

                return _instance;
            }
        }
    }
}