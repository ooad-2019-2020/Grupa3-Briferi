using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MigrantControlSystem.Models;
using Newtonsoft.Json;

namespace MigrantControlSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            string apiUrl = "https://migrantcontrolsystemapi.azurewebsites.net/";
            PSViewModel ps = new PSViewModel();
            using (var client = new HttpClient())
            {
                //Postavljanje adrese URL od web api servisa
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                //definisanje formata koji želimo prihvatiti
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                //Asinhrono slanje zahtjeva za podacima o studentima
                HttpResponseMessage Res = await client.GetAsync("api/policijskastanica/");
                //Provjera da li je rezultat uspješan
                if (Res.IsSuccessStatusCode)
                {
                    //spremanje podataka dobijenih iz responsa
                    var response = Res.Content.ReadAsStringAsync().Result;

                    ps.stanice=JsonConvert.DeserializeObject<List<PolicijskaStanica>>(response);
                }
                Res = await client.GetAsync("api/migrantskicentar/");
                if (Res.IsSuccessStatusCode)
                {
                    //spremanje podataka dobijenih iz responsa
                    var response = Res.Content.ReadAsStringAsync().Result;

                    ps.otvoreni = JsonConvert.DeserializeObject<List<MCOtvoreniTip>>(response);
                    ps.zatvoreni = JsonConvert.DeserializeObject<List<MCZatvoreniTip>>(response);
                }
                return View(ps);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
