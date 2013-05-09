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

        public void Register(RegistrationForm form) {
            userRepository.Create(form);
            emailSender.Send(form);
        }
    }
}