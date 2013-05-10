using System.Web.Mvc;
using MspecTest.Models;
using MspecTest.Repositories;
using MspecTest.Services;

namespace MspecTest.Controllers {
    public class RegistrationController : Controller {
        private readonly IRegistrationService registrationService;
        private readonly IUserRepository userRepository;

        public RegistrationController(IRegistrationService registrationService, IUserRepository userRepository) {
            this.registrationService = registrationService;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ViewResult Index() {
            return View("Index", new User()); 
        }

        [HttpPost]
        public ActionResult Index(User user) {
            registrationService.Register(user);
            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou() {
            var user = userRepository.Get();
            if (user == null) {
                return RedirectToAction("Index");
            }

            return View("ThankYou", user);
        }
    }
}