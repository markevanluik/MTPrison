using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class GetNamespaceTests : IsTypeTested {
        [TestMethod] public void OfTypeTest() {
            areEqual("MTPrison.Tests.Aids", GetNamespace.OfType(this));
        }
    }
}
