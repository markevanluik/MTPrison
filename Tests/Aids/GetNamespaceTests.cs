using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class GetNamespaceTests : IsTypeTested {
        [TestMethod] public void OfTypeTest() {
            areEqual(GetNamespace.OfType(null), string.Empty);
            areEqual(GetNamespace.OfType(this), "MTPrison.Tests.Aids");
        }
    }
}
