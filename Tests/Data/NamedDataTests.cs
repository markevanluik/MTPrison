using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data;

namespace MTPrison.Tests.Data {
    [TestClass]
    public class NamedDataTests : AbstractClassTests {
        private class testClass : NamedData { }
        protected override object createObject() => new testClass();
        [TestMethod] public void CodeTest() => isProperty<string?>();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void NativeNameTest() => isProperty<string?>();
    }
}
