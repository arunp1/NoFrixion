using NoFrixion.WebAPIClient;
using System;
using System.Configuration;

namespace NoFrixion
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var baseURL = ConfigurationManager.AppSettings["WebAPIBaseURL"];
            var apiClient = new WebAPIClientDetails(baseURL);

            Console.WriteLine("BTC Price EUR : " + apiClient.GetCurrentRate("EURO"));
            Console.ReadKey();

        }
    }
}
