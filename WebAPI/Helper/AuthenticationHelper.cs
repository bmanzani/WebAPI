using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Helper
{
    public class AuthenticationHelper
    {

        public static HttpModel AuthenticationToken(IConfiguration _config)
        {
            var _urlbase = _config.GetSection("API_Access:UrlBase").Value;
            HttpClient http = new HttpClient();
            HttpResponseMessage respToken = http.PostAsync(
                    _urlbase + "login", new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            UserID = _config.GetSection("API_Access:UserID").Value,
                            AccessKey = _config.GetSection("API_Access:AccessKey").Value,
                        }), Encoding.UTF8, "application/json")).Result;
            string conteudo =
                    respToken.Content.ReadAsStringAsync().Result;

            if (respToken.StatusCode == HttpStatusCode.OK)
            {
                Token token = JsonConvert.DeserializeObject<Token>(conteudo);
                if (token.Authenticated)
                {
                    // Associar o token aos headers do objeto
                    // do tipo HttpClient
                    http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.AccessToken);

                }
            }
            HttpModel httpmodel = new HttpModel();
            httpmodel.Http = http;
            httpmodel._urlBase = _urlbase;
            return httpmodel;
        }
    }
}



