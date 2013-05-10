using System.ComponentModel;

namespace MspecTest.Models {
    public class User {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}