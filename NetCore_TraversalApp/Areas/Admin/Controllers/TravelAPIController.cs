using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore_TraversalApp.Areas.Admin.Models;
using Newtonsoft.Json;

namespace NetCore_TraversalApp.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/TravelAPI")]
    public class TravelAPIController : Controller
    {
        private string APIKEY = "d5c4dd521bmsh20c374a4db162adp175c05jsn689f7750723a";
        private readonly IHttpClientFactory _httpClient;

        public TravelAPIController(IHttpClientFactory httpClient)
        {
                _httpClient = httpClient;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://apidojo-booking-v1.p.rapidapi.com/currency/get-exchange-rates?base_currency=USD&languagecode=en-us"),
                Headers =
                {
                    { "X-RapidAPI-Key", "fb43b32018msh4d70c6d3880c58ap16de10jsnbaa648974092" },
                    { "X-RapidAPI-Host", "apidojo-booking-v1.p.rapidapi.com" },
                },
            };

            var http = _httpClient.CreateClient();
            var response =  await http.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BookingCurrencyRateViewModel>(body);
                return View(data);    
            }

            return View();
        }
    }

  
}
