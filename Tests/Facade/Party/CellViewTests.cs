using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CellViewTests : SealedClassTests<CellView, UniqueView> {
        [TestMethod] public void CellNumberTest() => isRequired<int>("Cell Number");
        [TestMethod] public void CapacityTest() => isDisplayNamed<int>("Capacity");
        [TestMethod] public void TypeTest() => isRequired<CellType>("Type");
        [TestMethod] public void SectionTest() => isProperty<string>("Section");
    }
}
