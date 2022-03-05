using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class GetNamespaceTests : IsTypeTested {
        [TestMethod] public void OfTypeTest() {
            Assert.AreEqual(GetNamespace.OfType(null), string.Empty);
            Assert.AreEqual(GetNamespace.OfType(this), "MTPrison.Tests.Aids");
        }
    }
}
