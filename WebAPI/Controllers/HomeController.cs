using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebAPI.Entity;
using WebAPI.Helper;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration _config { get; set; }

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CallAPI(IFormCollection form)
        {
            var nome = Request.Form["nome"];
            var sobrenome = Request.Form["sobrenome"];
            var cargo = Request.Form["cargo"];
            var salario = Request.Form["salario"];

            TableApi table = new TableApi()
            {
                Nome = nome,
                Sobrenome = sobrenome,
                Cargo = cargo,
                Salario = Convert.ToDouble(salario)
            };

            var httpmodel = AuthenticationHelper.AuthenticationToken(_config);
            var http = httpmodel.Http;
            var urlBase = httpmodel._urlBase;

            var resp = http.PostAsJsonAsync(urlBase, table);
            var a = resp.Result;
            return RedirectToAction("Index");
        }
    }
}
