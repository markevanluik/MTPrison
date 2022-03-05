using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class StringsTests : IsTypeTested {
        private string? s;
        [TestInitialize] public void Init() {
            s = "123.abc.qwerty";
        }

        [TestMethod] public void RemoveTest() {
            Assert.AreEqual("123.qwerty", s?.Remove("abc."));
        }
        [TestMethod] public void IsRealTypeNameTest() {
            Assert.IsTrue(s.IsRealTypeName());

        }
        [TestMethod] public void RemoveTailTest() {
            Assert.AreEqual("123.abc", s.RemoveTail());
        }
    }
}
