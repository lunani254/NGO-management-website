using System.Diagnostics;
using ESSMaterWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESSMaterWebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        //---------------------------------------------------------------------//
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Get the home page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Get the privacy page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Get the about page.
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Get the contact us page.
        /// </summary>
        /// <returns></returns>
        public IActionResult ContactUs()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Get the gallery page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Gallery()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Get the comming soon page.
        /// </summary>
        /// <returns></returns>
        public IActionResult CommingSoon()
        {
            return View();
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Get the error page.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //---------------------------------------------------------------------//
        /// <summary>
        /// Submit the contact form.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SubmitContactForm(string name, string email, string message)
        {
            // Handle the submitted data (e.g., send an email or save to the database)
            TempData["SuccessMessage"] = "Thank you for contacting us! We will get back to you soon.";
            return RedirectToAction("ContactUs");
        }
    }
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 