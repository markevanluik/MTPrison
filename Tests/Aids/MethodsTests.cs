using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System;
using System.Reflection;

namespace MTPrison.Tests.Aids {     // not working correctly
    [TestClass] public class MethodsTests : IsTypeTested {
        public static bool JustAMethod() => true;
        private readonly MethodInfo? info = typeof(MethodsTests).GetMethod("JustAMethod");
        [TestMethod] public void HasAttributeTest() {

            Assert.IsTrue(info.HasAttribute<Attribute>());
        }

    }
}
