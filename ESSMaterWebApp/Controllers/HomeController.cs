using System.Diagnostics;
using ESSMaterWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESSMaterWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult CommingSoon()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SubmitContactForm(string name, string email, string message)
        {
            // Handle the submitted data (e.g., send an email or save to the database)
            TempData["SuccessMessage"] = "Thank you for contacting us! We will get back to you soon.";
            return RedirectToAction("ContactUs");
        }

    }
}
