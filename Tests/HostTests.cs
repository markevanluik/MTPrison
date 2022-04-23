using System.Net.Http;

namespace MTPrison.Tests {
    public class HostTests : TestAsserts {
        internal static TestHost<Program> host;
        internal static readonly HttpClient client;
        static HostTests() {
            host = new TestHost<Program>();
            client = host.CreateClient();
        }
    }
}
