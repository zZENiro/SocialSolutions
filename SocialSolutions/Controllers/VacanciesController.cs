using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using SocialSolutions.Models.ViewModels;
using System.Threading.Tasks;

namespace SocialSolutions.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class VacanciesController : Controller
    {
        private StringBuilder _sb = new StringBuilder();
        private readonly IConfiguration _configuration;

        public VacanciesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetCatalogs([FromQuery] string param)
        {
            WebRequest request = WebRequest.Create("https://api.superjob.ru/2.20/catalogues/");
            request.Method = "POST";
            request.Headers.Add("Authorization", "Bearer v3.r.133137306.828a4769efb4c265bea28292018a50911e8556a4.aa70c99a48ea6c51d7109f379b400eac5cc8c7f9");
            request.Headers.Add("X-Api-App-Id", _configuration["superJob_ApiKey"]);
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Accept", "*/*");
            var result = request.GetResponse();

            string response = string.Empty;

            using (var rs = result.GetResponseStream())
            using (var sr = new StreamReader(rs))
            {
                response = await sr.ReadToEndAsync();
            }

            return new ContentResult() { Content = response, ContentType = "application/json" };
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> LoadRegions()
        {
            var request = (HttpWebRequest)WebRequest.Create("https://api.superjob.ru/2.20/regions/?");
            request.Method = "POST";
            request.Headers.Add("Authorization", "Bearer v3.r.133137306.828a4769efb4c265bea28292018a50911e8556a4.aa70c99a48ea6c51d7109f379b400eac5cc8c7f9");
            request.Headers.Add("X-Api-App-Id", _configuration["superJob_ApiKey"]);
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Accept", "*/*");

            var result = string.Empty;

            var httpResponse = (HttpWebResponse)await request.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> LoadTowns([FromQuery]string region_id)
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://api.superjob.ru/2.20/towns/?id_region={int.Parse(region_id)}");
            request.Method = "POST";
            request.Headers.Add("Authorization", "Bearer v3.r.133137306.828a4769efb4c265bea28292018a50911e8556a4.aa70c99a48ea6c51d7109f379b400eac5cc8c7f9");
            request.Headers.Add("X-Api-App-Id", _configuration["superJob_ApiKey"]);
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Accept", "*/*");

            var result = string.Empty;

            var httpResponse = (HttpWebResponse)await request.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> FindVacancy([FromBody] VacancyParameters parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create($"https://api.superjob.ru/2.20/vacancies/?keyword={parameters.keyword}&town={parameters.town}&experience={parameters.experience}&payment_from={parameters.payment_from}&payment_to={parameters.payment_to}");
            request.Method = "GET";
            request.Headers.Add("Authorization", "Bearer v3.r.133137306.828a4769efb4c265bea28292018a50911e8556a4.aa70c99a48ea6c51d7109f379b400eac5cc8c7f9");
            request.Headers.Add("X-Api-App-Id", "v3.r.133137306.68a93c968533e6928209b1a8db43a1a5479bc1fa.b2d2d31eb305aaa014aaabff6e60d7e1b12809db");
            request.Headers.Add("Connection", "keep-alive");
            request.Headers.Add("Accept", "*/*");

            string result = string.Empty;

            var httpResponse = (HttpWebResponse)await request.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return new ContentResult() { Content = result, ContentType = "application/json" };
        }
    }
}
