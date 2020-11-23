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
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace SocialSolutions.Controllers
{
    public class OpenEnvParams
    {
        public double[]? bbox { get; set; }
        public int? z { get; set; }
        public string[]? categories { get; set; }
        public string[]? subcategories { get; set; }
        public int[]? elements { get; set; }
        public bool callback { get; set; }
    }

    [Controller]
    [Route("api/[controller]")]
    public class OpenEnvController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly NumberFormatInfo _nfi;

        public OpenEnvController(IConfiguration configuration)
        {
            this._configuration = configuration;
            _nfi = new CultureInfo("en-US", false).NumberFormat;
            _nfi.NumberDecimalSeparator = ".";
            _nfi.NumberDecimalDigits = 20;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetResult([FromBody] OpenEnvParams inputs)
        {
            var categories = inputs.categories is null       ? string.Empty       : "&categories=" + string.Join(',', inputs.categories);
            var subcategories = inputs.subcategories is null ? string.Empty       : "&subcategories=" + string.Join(',', inputs.subcategories);
            var elements = inputs.elements is null           ? string.Empty       : "&elements=" + string.Join(',', inputs.elements.Select(el => el.ToString()));
            var z  = inputs.z is null                        ? string.Empty       : "&z=" + inputs.z.ToString();

            var url = $"http://www.kartadostupnosti.ru/api/map/frontend/v1/json/objects.php?" +
                                                $"bbox={inputs.bbox[0].ToString(_nfi)},{inputs.bbox[1].ToString(_nfi)},{inputs.bbox[2].ToString(_nfi)},{inputs.bbox[3].ToString(_nfi)}" +
                                                $"&callback={inputs.callback}" +
                                                $"{z}" +
                                                $"{categories}" +
                                                $"{subcategories}" +
                                                $"{elements}";


            var request = WebRequest.CreateHttp(url);
            request.Method = "POST";
            request.KeepAlive = true;

            try
            {
                var resp = await request.GetResponseAsync();
                var result = string.Empty;

                using (var rs = resp.GetResponseStream())
                using (var sr = new StreamReader(rs))
                {
                    result = await sr.ReadToEndAsync();
                }

                return new JsonResult(result) { ContentType = "application/json", StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}

