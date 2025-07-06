using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{

    public class ApiExchangeController : Controller
    {
        [Area("Admin")]
        [AllowAnonymous]


        public async Task<IActionResult> Index()
        {
            List<ApiExchangeViewModel2> apiExchange = new List<ApiExchangeViewModel2>();



            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=USD"),
                Headers =
    {
        { "x-rapidapi-key", "99da434af4msh85ba59a0f7a9c54p18c394jsnb146429c0f53" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ApiExchangeViewModel2>(body);
               

                return View(values.exchange_rates);
            }
        }
    }
            }
            


                // Eğer null değilse View'e gönder

            
        
    
