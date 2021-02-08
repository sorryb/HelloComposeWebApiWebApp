using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            ViewData["Message"] = "Hello from MyFronEnd";

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri("http://webapi/WeatherForecast"); //


                //// ViewData["Message"] += " and " + await response.Content.ReadAsStringAsync();
                //// var jsonString = "[{'date':'2020 - 10 - 09T21: 11:53.0449475 + 00:00','temperatureC':17,'temperatureF':62,'summary':'Scorching'},{'date':'2020 - 10 - 10T21: 11:53.0449984 + 00:00','temperatureC':10,'temperatureF':49,'summary':'Hot'},{'date':'2020 - 10 - 11T21: 11:53.0449995 + 00:00','temperatureC':-11,'temperatureF':13,'summary':'Mild'},{'date':'2020 - 10 - 12T21: 11:53.0450001 + 00:00','temperatureC':29,'temperatureF':84,'summary':'Balmy'},{'date':'2020 - 10 - 13T21: 11:53.0450007 + 00:00','temperatureC':37,'temperatureF':98,'summary':'Cool'}]";

                var response = await client.SendAsync(request);
                var jsonString = await response.Content.ReadAsStringAsync();
                var weather =  JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonString);
                ViewData["Message"] = weather;// JsonConvert.SerializeObject(weather);
            }
        }
    }
}
