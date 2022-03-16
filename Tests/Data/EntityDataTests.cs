using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;

namespace MTPrison.Tests.Data {
    [TestClass] public class EntityDataTests : AbstractClassTests{
        [TestMethod] public void IdTest() => isProperty<string>();
        private class testClass : BaseView { }
        protected override object createObject() => new testClass();
    }
}
