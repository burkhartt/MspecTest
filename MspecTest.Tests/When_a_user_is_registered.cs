using AutoMoq.Helpers;
using Machine.Specifications;
using Moq;
using MspecTest.Email;
using MspecTest.Models;
using MspecTest.Repositories;
using MspecTest.Services;
using It = Machine.Specifications.It;

namespace MspecTest.Tests {
    [Subject(typeof(RegistrationService))]
    public class When_a_user_is_registered : with_automoqer {
        public Establish context = () => {
            userRepository = new Mock<IUserRepository>();
            emailSender = new Mock<IEmailSender>();
            registrationService = new RegistrationService(userRepository.Object, emailSender.Object);
            form = new RegistrationForm();
        };

        public Because of = () => registrationService.Register(form);

        public It should_create_a_user = () => userRepository.Verify(x => x.Create(form), Times.Once());

        public It should_send_an_email_to_the_user = () => emailSender.Verify(x => x.Send(form), Times.Once());

        private static RegistrationService registrationService;
        private static RegistrationForm form;
        private static Mock<IUserRepository> userRepository;
        private static Mock<IEmailSender> emailSender;
    }
}