using AutoMoq.Helpers;
using Machine.Specifications;
using MspecTest.Models;
using MspecTest.Repositories;
using MspecTest.Tests.Mocks;

namespace MspecTest.Tests {
    [Subject(typeof(SessionUserRepository))]
    public class When_a_user_is_created : with_automoqer {
        public Establish context = () => {
            mockSessionState = new MockSessionState();
            sessionUserRepository = new SessionUserRepository(mockSessionState);
            user = new User { FirstName = "Tim", Email = "tim.burkhart@ef.com", LastName = "Burkhart" };
        };

        public Because of = () => sessionUserRepository.Create(user);

        public It should_save_the_user_to_the_session = () => mockSessionState["User"].ShouldEqual(user);

        private static SessionUserRepository sessionUserRepository;
        private static User user;
        private static MockSessionState mockSessionState;
    }
}