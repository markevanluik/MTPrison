using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System.Reflection;

namespace MTPrison.Tests.Aids {
    [TestClass] public class MethodsTests : IsTypeTested {
        [TestMethod] public void HasAttributeTest() {
            var mi = GetType().GetMethod(nameof(HasAttributeTest));
            isTrue(mi.HasAttribute<TestMethodAttribute>());
            isFalse(mi.HasAttribute<TestInitializeAttribute>());
        }
    }
}
