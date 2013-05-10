using System.Collections.Generic;
using System.Web;

namespace MspecTest.Tests.Mocks {
    public class MockSessionState : HttpSessionStateBase {
        private Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public override object this[string name]
        {
            get { return dictionary[name]; }
            set { dictionary[name] = value; }
        }
    }
}