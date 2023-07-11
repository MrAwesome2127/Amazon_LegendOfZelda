using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_LegendOfZelda.Utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }

        public string URL_extractJson(string url)
        {
            var testDataJSON = File.ReadAllText("appsettings.json");
            var parseTDJson = JToken.Parse(testDataJSON);
            return parseTDJson.SelectToken(url).Value<string>();
        }

        public string TestData_extractJson(string url)
        {
            var testDataJSON = File.ReadAllText("TestData.json");
            var parseTDJson = JToken.Parse(testDataJSON);
            return parseTDJson.SelectToken(url).Value<string>();
        }

        public string[] TestData_extractJsonArray(string tokenName)
        {
            var testDataJSON = File.ReadAllText("TestData.json");
            var parseTDJson = JToken.Parse(testDataJSON);
            List<string> productList = parseTDJson.SelectTokens(tokenName).Values<string>().ToList();
            return productList.ToArray();
        }
    }
}
