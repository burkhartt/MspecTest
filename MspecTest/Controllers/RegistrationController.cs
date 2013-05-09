using System.Web.Mvc;
using MspecTest.Models;
using MspecTest.Services;

namespace MspecTest.Controllers {
    public class RegistrationController : Controller {
        private readonly IRegistrationService registrationService;

        public RegistrationController(IRegistrationService registrationService) {
            this.registrationService = registrationService;
        }

        [HttpGet]
        public ViewResult Index() {
            return View("Index", new RegistrationForm());
        }

        [HttpPost]
        public ActionResult Index(RegistrationForm registrationForm) {
            registrationService.Register(registrationForm);
            return RedirectToAction("ThankYou");
        }

        public ViewResult ThankYou() {
            return View();
        }
    }
}