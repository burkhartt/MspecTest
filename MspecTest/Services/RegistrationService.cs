using MspecTest.Email;
using MspecTest.Models;
using MspecTest.Repositories;

namespace MspecTest.Services {
    public class RegistrationService : IRegistrationService {
        private readonly IUserRepository userRepository;
        private readonly IEmailSender emailSender;

        public RegistrationService(IUserRepository userRepository, IEmailSender emailSender) {
            this.userRepository = userRepository;
            this.emailSender = emailSender;
        }

        public void Register(User form) {
            userRepository.Create(form);
            emailSender.Send(form);
        }
    }
}