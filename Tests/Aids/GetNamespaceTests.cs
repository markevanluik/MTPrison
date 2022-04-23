using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;

namespace MTPrison.Tests.Aids {
    [TestClass] public class GetNamespaceTests : TypeTests {
        [TestMethod] public void OfTypeTest() {
            var obj = new CurrencyData();
            var name = obj.GetType().Namespace;
            var n = GetNamespace.OfType(obj);
            areEqual(name, n);
        }
        [TestMethod] public void OfTypeNullTest() {
            CurrencyData? obj = null;
            var n = GetNamespace.OfType(obj);
            areEqual(string.Empty, n);
        }
    }
}
