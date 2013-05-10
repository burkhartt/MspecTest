using System.Web.Mvc;
using AutoMoq.Helpers;
using Machine.Specifications;
using MspecTest.Controllers;
using MspecTest.Models;
using It = Machine.Specifications.It;

namespace MspecTest.Tests {
    [Subject(typeof(RegistrationController))]
    public class When_the_user_sees_the_registration_page : with_automoqer {
        public Establish context = () => { controller = Create<RegistrationController>(); };

        public Because of = () => {
            result = controller.Index();
        };

        public It should_return_a_view_result = () => result.ShouldBeOfType(typeof(ViewResult));

        public It should_return_the_index_view = () => result.CastAs<ViewResult>().ViewName.ShouldEqual("Index");

        public It should_return_a_registration_model = () => result.CastAs<ViewResult>().Model.ShouldBeOfType(typeof (User));
        
        private static RegistrationController controller;
        private static object result;
    }
}