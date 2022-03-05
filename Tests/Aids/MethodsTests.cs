using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System.Reflection;

namespace MTPrison.Tests.Aids {
    [TestClass] public class MethodsTests : IsTypeTested {
        [TestMethod] public void HasAttributeTest() {
            MethodInfo? info = typeof(MethodsTests).Method("JustAMethod");
            Assert.IsTrue(info.HasAttribute<TestMethodAttribute>());
        }
        [TestMethod] public static bool JustAMethod() => true;

    }
}
