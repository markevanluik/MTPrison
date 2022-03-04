using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class GetNamespaceTests : IsTypeTested {
        [TestMethod] public void OfTypeTest() {
            Assert.AreEqual(GetNamespace.OfType(this), "MTPrison.Tests.Aids");  // this can be..Tests.. bc OfTypeTest() is very basic
            Assert.AreNotEqual(GetNamespace.OfType(this), "....");
        }
    }
}
