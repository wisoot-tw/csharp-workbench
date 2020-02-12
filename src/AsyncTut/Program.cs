using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace AsyncTut
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            await RunDownloadAsync();
        }

        static async Task RunDownloadAsync()
        {
            var sites = PrepData();

            foreach (var site in sites) 
            {
                WebsiteDataModel result = await Task.Run(() => DownloadWebsite(site));
                ReportWebsiteInfo(result);
            }
        }

        static List<string> PrepData()
        {
            var sites = new List<string>();

            sites.Add("https://www.yahoo.com");
            sites.Add("https://www.google.com");
            sites.Add("https://www.microsoft.com");
            sites.Add("https://www.cnn.com");
            sites.Add("https://www.codeproject.com");
            sites.Add("https://www.stackoverflow.com");

            return sites;
        }

        static WebsiteDataModel DownloadWebsite(string site)
        {
            var output = new WebsiteDataModel();
            var client = new WebClient();

            output.WebsiteUrl = site;
            output.WebsiteData = client.DownloadString(site);

            return output;
        }

        static void ReportWebsiteInfo(WebsiteDataModel data)
        {
            Console.WriteLine($"{data.WebsiteUrl} downloaded: {data.WebsiteData.Length} characters long.");
        }
    }
}
