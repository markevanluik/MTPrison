using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain;

namespace MTPrison.Tests.Domain {
    [TestClass] public class EntityTests : AbstractClassTests<UniqueEntity, object> {
        private class testClass : UniqueEntity { }
        protected override UniqueEntity createObj() => new testClass();
    }
}
