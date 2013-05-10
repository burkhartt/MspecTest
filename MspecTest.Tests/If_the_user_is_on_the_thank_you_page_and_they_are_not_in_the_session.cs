using System.Web.Mvc;
using AutoMoq.Helpers;
using Machine.Specifications;
using Moq;
using MspecTest.Controllers;
using MspecTest.Repositories;
using MspecTest.Services;
using It = Machine.Specifications.It;

namespace MspecTest.Tests {
    [Subject(typeof(RegistrationController))]
    public class If_the_user_is_on_the_thank_you_page_and_they_are_not_in_the_session : with_automoqer {
        public Establish context = () => {
            var registrationService = new Mock<IRegistrationService>();
            var userRepository = new Mock<IUserRepository>();
            controller = new RegistrationController(registrationService.Object, userRepository.Object);
        };

        public Because of = () => {
            result = controller.ThankYou();
        };

        public It should_return_a_redirect_to_route_result = () => result.ShouldBeOfType(typeof (RedirectToRouteResult));

        public It should_redirect_to_the_index_view = () => result.CastAs<RedirectToRouteResult>().RouteValues["action"].ShouldEqual("Index");

        private static RegistrationController controller;
        private static ActionResult result;
    }
}