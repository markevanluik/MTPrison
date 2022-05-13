using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CellViewTests : SealedClassTests<CellView, UniqueView> {
        [TestMethod] public void CellNumberTest() => isRequired<int>("Cell Number");
        [TestMethod] public void CapacityTest() => isDisplayNamed<int>("Capacity");
        [TestMethod] public void TypeTest() => isRequired<CellType>("Type");
        [TestMethod] public void SectionTest() => isProperty("Section");
        [TestMethod] public void CheckCellNrTest() {
            CellData ? d = GetRandom.Value<CellData>();
            isNotNull(d);
            d.CellNumber = 1;
            var e = new Cell(d);
            var v = new CellViewFactory().Create(e);
            areEqual(v.CheckCellNr, e.CellNumber);

            var l = GetRepo.Instance<ICellsRepo>();
            isNotNull(l);
            l?.Add(e);
            v = new CellViewFactory().Create(e);
            areNotEqual(v.CheckCellNr, e.CellNumber);
            areEqual(v.CheckCellNr, -1);
        }
    }
}
