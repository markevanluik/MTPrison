using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data;

namespace MTPrison.Tests.Data {
    [TestClass] public class EntityDataTests : BaseTests<EntityData>{
        [TestMethod] public void IdTest() => isProperty<string>();
    }
}
