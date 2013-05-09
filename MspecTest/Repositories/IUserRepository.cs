using MspecTest.Models;

namespace MspecTest.Repositories {
    public interface IUserRepository {
        void Create(RegistrationForm form);
    }
}