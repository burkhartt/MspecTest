using System.Web.Mvc;
using AutoMoq.Helpers;
using Machine.Specifications;
using Moq;
using MspecTest.Controllers;
using MspecTest.Models;
using MspecTest.Repositories;
using MspecTest.Services;
using It = Machine.Specifications.It;

namespace MspecTest.Tests {
    [Subject(typeof(RegistrationController))]
    public class When_the_user_submits_the_registration_form : with_automoqer {
        public Establish context = () => {
            registrationService = new Mock<IRegistrationService>();
            var userRepository = new Mock<IUserRepository>();

            controller = new RegistrationController(registrationService.Object, userRepository.Object);
            form = new User {
                FirstName = "Tim",
                LastName = "Burkhart",
                Email = "tim.burkhart@ef.com"
            };
        };

        public Because of = () => { result = controller.Index(form); };

        public It should_register_the_user = () => registrationService.Verify(x => x.Register(form), Times.Once());

        public It should_redirect_the_user = () => result.ShouldBeOfType(typeof(RedirectToRouteResult));

        public It should_redirect_the_user_to_the_thank_you_page = () => result.CastAs<RedirectToRouteResult>().RouteValues["action"].ShouldEqual("ThankYou");

        private static RegistrationController controller;
        private static User form;
        private static ActionResult result;
        private static Mock<IRegistrationService> registrationService;
    }
}