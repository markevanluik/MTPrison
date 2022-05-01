using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;

namespace MTPrison.Tests.Facade {
    [TestClass] public class NamedViewTests : AbstractClassTests<NamedView, UniqueView> {
        private class testClass : NamedView { }
        protected override NamedView createObj() => new testClass();

        [TestMethod] public void CodeTest() => isRequired<string>("Code");
        [TestMethod] public void NameTest() => isRequired<string>("Name");
        [TestMethod] public void NativeNameTest() => isRequired<string>("Native name");
    }
}
