using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace SocialSolutions.Controllers
{
    public class Filter
    {
        public string regnId { get; set; }
        public string regnText { get; set; }
        public object sferaId { get; set; }
        public object sferaText { get; set; }
        public object vidId { get; set; }
        public object vidText { get; set; }
        public object captionId { get; set; }
        public object captionText { get; set; }
        public object captionOsiId { get; set; }
        public object captionOsiText { get; set; }
    }

    public class Response
    {
        public bool HasError { get; set; }
        public Result[] Result { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Caption_small { get; set; }
        public string Captionosi { get; set; }
        public string Id_region_obj { get; set; }
        public string Caption_region_obj { get; set; }
        public string Caption_obj { get; set; }
        public string Nomerreg { get; set; }
        public string Datreestr { get; set; }
        public string Datizmtek { get; set; }
        public Contact Contact { get; set; }
        public Dostup Dostup { get; set; }
    }

    public class Contact
    {
        public int Id_org { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }

    public class Dostup
    {
        public int Dost_Kolyas { get; set; }
        public int Dost_ODA { get; set; }
        public int Dost_Zren { get; set; }
        public int Dost_Sluh { get; set; }
        public int Dost_Um { get; set; }
    }

    public class OutputData
    {
        public string d { get; set; }
    }

    [Controller]
    [Route("api/[controller]")]
    [Authorize()]
    public class FreeEnv : Controller
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetResult()
        {
            string message;

            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                message = await reader.ReadToEndAsync();

            var client = new HttpClient();

            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, 
                                                                "https://slk.msp.midural.ru/ds/WebServiceAss.asmx/GetOrganizationCollection");
            request.Content = new StringContent(message,
                                                Encoding.UTF8,
                                                "application/json");

            OutputData output = null;

            using (var resp = await client.PostAsync(request.RequestUri, request.Content))
            {
                if (resp.StatusCode != HttpStatusCode.OK)
                    return new JsonResult(new { Error = "Запрос не дошёл" });

                var stream = await resp.Content.ReadAsStreamAsync();
                using (StreamReader sr = new StreamReader(stream))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    do
                    {
                        output = serializer.Deserialize<OutputData>(reader);
                    }
                    while (reader.Read());
                }
            }

            if (output != null) return new JsonResult(output);
            return new JsonResult(new { Error = "Данные с ДС плохие" });
        }
    }
}
