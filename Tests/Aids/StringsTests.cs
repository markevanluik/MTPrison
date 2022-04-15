using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class StringsTests : IsTypeTested {
        private string? s;
        [TestInitialize] public void Init() => s = "123.abc.qwerty";
        [TestMethod] public void RemoveTest() => areEqual("abc.qwerty", Strings.Remove(s, "123."));
        [TestMethod] public void IsTypeNameTest() => isTrue(Strings.IsTypeName("abcqwerty"));
        [TestMethod] public void IsTypeFullNameTest() => isTrue(Strings.IsTypeFullName("Abcqwerty"));
        [TestMethod] public void RemoveTailTest() => areEqual("123.abc", Strings.RemoveTail(s));
    }
}
