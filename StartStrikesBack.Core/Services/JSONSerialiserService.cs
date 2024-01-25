using Newtonsoft.Json;
using StartStrikesBack.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartStrikesBack.Core.Services
{
    public class JSONSerialiserService : ISerialiserService
    {
        public async Task<T> DeserialiseAsync<T>(string data) => await Task.Run(() => JsonConvert.DeserializeObject<T>(TrimInvalidJson(data), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));

        public async Task<string> SerialiseAsync<T>(T data) => await Task.Run(() => JsonConvert.SerializeObject(data, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto }));

        private string TrimInvalidJson(string json)
        {
            int openBrackets = json.Split("[{").Length - 1;
            int closeBrackets = json.Split("}]").Length - 1;

            int minBrackets = Math.Min(openBrackets, closeBrackets);

            int index = -1;
            for (int i = 0; i < minBrackets; i++)
            {
                index = json.IndexOf("}]", index + 1);
            }

            if (index > -1)
            {
                // Add 2 to include the characters at "}]"
                json = json.Substring(0, index + 2);
            }

            return json;
        }
    }
}
