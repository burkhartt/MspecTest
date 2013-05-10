using MspecTest.Models;

namespace MspecTest.Email {
    public interface IEmailSender {
        void Send(User form);
    }
}