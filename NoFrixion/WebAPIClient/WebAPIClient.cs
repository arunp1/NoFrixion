using Newtonsoft.Json;
using NoFrixion.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace NoFrixion.WebAPIClient
{
    public class WebAPIClientDetails
    {

        static HttpClient client;
        static string baseURL;
        public WebAPIClientDetails(string url)
        {
            client = new HttpClient();
            baseURL = url;
        }

        static async Task<Root> EuroDetails()
        {
            Root bitcoinDetails = null;
            //var client = new HttpClient();
            string completeURL = string.Empty;

            completeURL = baseURL + "/v1/bpi/currentprice.json";


            var taskResponse = client.GetAsync(completeURL).Result;
            if (taskResponse.IsSuccessStatusCode)
            {
                var jsonString = await taskResponse.Content.ReadAsStringAsync();
                bitcoinDetails = JsonConvert.DeserializeObject<Root>(jsonString);
            }
            return bitcoinDetails;

        }

/// <summary>
/// Get Currency Rate Based on Currency Type
/// </summary>
/// <param name="currency"></param>
/// <returns></returns>
        public string GetCurrentRate(string currency)
        {

            var currencyRoot= EuroDetails().GetAwaiter().GetResult();

            switch (currency.ToLower())
            {
                case "euro":
            return currencyRoot.bpi.EUR.rate;
                case "gbp":
                    return currencyRoot.bpi.GBP.rate;
                case "usd":
                    return currencyRoot.bpi.USD.rate;
                default:
                  return  currencyRoot.bpi.EUR.rate;
            }

           
        }
    }
}
