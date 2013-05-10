using System.Web;
using MspecTest.Models;

namespace MspecTest.Repositories {
    public class SessionUserRepository : IUserRepository {
        private readonly HttpSessionStateBase session;

        public SessionUserRepository(HttpSessionStateBase session) {
            this.session = session;
        }

        public void Create(User form) {
            session["User"] = form;
        }

        public User Get() {
            return (User)session["User"];
        }
    }
}