using System.Web.Mvc;
using AutoMoq.Helpers;
using Machine.Specifications;
using Moq;
using MspecTest.Controllers;
using MspecTest.Models;
using MspecTest.Services;
using It = Machine.Specifications.It;

namespace MspecTest.Tests {
    [Subject(typeof(RegistrationController))]
    public class When_the_user_submits_the_registration_form : with_automoqer {
        public Establish context = () => {
            registrationService = new Mock<IRegistrationService>();

            controller = new RegistrationController(registrationService.Object);
            form = new RegistrationForm {
                FirstName = "Tim",
                LastName = "Burkhart",
                Email = "tim.burkhart@ef.com"
            };
        };

        public Because of = () => { result = controller.Index(form); };

        public It should_register_the_user = () => registrationService.Verify(x => x.Register(Moq.It.IsAny<RegistrationForm>()), Times.Once());

        public It should_redirect_the_user = () => result.ShouldBeOfType(typeof(RedirectToRouteResult));

        private static RegistrationController controller;
        private static RegistrationForm form;
        private static ActionResult result;
        private static Mock<IRegistrationService> registrationService;
    }
}