using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyWaters.Tools
{
    /// <summary>
    /// Class that provides methods to help handle API calls. A common return type here is JSON Dynamics
    /// </summary>
    public class HTTPCall
    {
        /// <summary>
        /// This method is designed in order to fetch JSON data from a simple URL datasource
        /// Use this when making calls to sites that have a guarenteed return of JSON
        /// </summary>
        /// <param name="url"> The Datasource address </param>
        /// <returns> JSON Dynamic </returns>
        async Task<dynamic> FetchURLJson(string url)
        {
            // Instantiate New HTTP Client
            HttpClient client = new HttpClient();
            // Request Headers to define who we are, and what we want
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            client.DefaultRequestHeaders.Add("User-Agent", "WaterReady");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            // Fetch Data from Site
            HttpResponseMessage response = await client.GetAsync(url);
            // Recieve Data from Site
            string content = await response.Content.ReadAsStringAsync();
            // Return Data as Dynamic
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
    }
}
