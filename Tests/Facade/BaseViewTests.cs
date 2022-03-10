using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;

namespace MTPrison.Tests.Facade {
    [TestClass] public class BaseViewTests : BaseTests<BaseView>{
        [TestMethod] public void IdTest() => isProperty<string?>();
    }
}
