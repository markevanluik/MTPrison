using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;

namespace MTPrison.Tests.Facade {
    [TestClass] public class UniqueViewTests : AbstractClassTests<UniqueView, object> {
        private class testClass : UniqueView { }
        protected override UniqueView createObj() => new testClass();
        [TestMethod] public void IdTest() => isProperty<string>();
    }
}
