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
    public class When_the_user_views_the_registration_thank_you_page : with_automoqer {
        public Establish context = () => {
            var registrationService = new Mock<IRegistrationService>();
            var userRepository = new Mock<IUserRepository>();
            user = new User {Email = "michael.jordan@nbabulls.com", FirstName = "Michael", LastName = "Jordan"};
            userRepository.Setup(x => x.Get()).Returns(user);

            controller = new RegistrationController(registrationService.Object, userRepository.Object);
        };

        public Because of = () => {
            result = controller.ThankYou();
        };

        public It should_return_a_view_result = () => result.ShouldBeOfType(typeof (ViewResult));

        public It should_return_the_thank_you_view = () => result.CastAs<ViewResult>().ViewName.ShouldEqual("ThankYou");

        public It should_return_the_registered_user = () => result.CastAs<ViewResult>().Model.ShouldEqual(user);

        private static RegistrationController controller; 
        private static ActionResult result;
        private static User user;
    }
}