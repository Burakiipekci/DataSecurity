using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using XSS.Web.Models;

namespace XSS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HtmlEncoder _htmlEncoder;
        private JavaScriptEncoder _javaScriptEncoder;

        public HomeController(ILogger<HomeController> logger, JavaScriptEncoder javaScriptEncoder, HtmlEncoder htmlEncoder)
        {
            _logger = logger;
            _javaScriptEncoder = javaScriptEncoder;
            _htmlEncoder = htmlEncoder;
        }
        public IActionResult CommentAdd()
        {
            if (System.IO.File.Exists("comment.txt"))
            {
                ViewBag.comments = System.IO.File.ReadAllLines("comment.txt");
            }



            return View();
        }
        [HttpPost]
        public IActionResult CommentAdd(string name, string email,string comment)
        {
            _htmlEncoder.Encode(name); // Encode işlemini yapmamızı sağlıyor 
            ViewBag.name = name;
            ViewBag.email = email;
            ViewBag.comment = comment;

            System.IO.File.AppendAllText("comment.txt", $"{name}-{comment}\n");
            //   return RedirectToAction(CommentAdd);
            return View();
        }

        public IActionResult Index()
        {
            return View();
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
