using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data;
using MTPrison.Facade;

namespace MTPrison.Tests.Data {
    [TestClass] public class EntityDataTests : AbstractClassTests<UniqueData, object> {
        private class testClass : UniqueData { }
        protected override UniqueData createObj() => new testClass();
        [TestMethod] public void IdTest() => isProperty<string>();
    }
}
