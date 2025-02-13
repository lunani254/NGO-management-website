using ESSMaterWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;

namespace ESSMaterWebApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly StripeSettings _stripeSettings;

        public PaymentController(IOptions<StripeSettings> stripeSettings)
        {
            _stripeSettings = stripeSettings.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey; // Initialize Stripe
        }

        // GET: Payment/Checkout
        public IActionResult Checkout()
        {
            return View();
        }

        // POST: Payment/CreateCheckoutSession
        [HttpPost]
        public IActionResult CreateCheckoutSession()
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = 1000, // R10.00 (ZAR)
                            Currency = "zar",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Sample Product",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme),
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url); // Redirect to Stripe Checkout
        }

        // GET: Payment/Success
        public IActionResult Success()
        {
            return View();
        }

        // GET: Payment/Cancel
        public IActionResult Cancel()
        {
            return View();
        }
    }
}