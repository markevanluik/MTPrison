using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data;

namespace MTPrison.Tests.Data {
    [TestClass] public class NamedDataTests : AbstractClassTests<NamedData, UniqueData> {
        private class testClass : NamedData { }
        protected override NamedData createObj() => new testClass();
        [TestMethod] public void CodeTest() => isProperty<string?>();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void NativeNameTest() => isProperty<string?>();
    }
}
