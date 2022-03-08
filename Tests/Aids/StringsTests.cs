using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class StringsTests : IsTypeTested {
        private string? s;
        [TestInitialize] public void Init() {
            s = "123.abc.qwerty";
        }

        [TestMethod] public void RemoveTest() {
            areEqual("123.qwerty", s?.Remove("abc."));
        }
        [TestMethod] public void IsRealTypeNameTest() {
            Assert.IsTrue(s.IsRealTypeName());

        }
        [TestMethod] public void RemoveTailTest() {
            areEqual("123.abc", s.RemoveTail());
        }
    }
}
