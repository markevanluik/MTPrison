using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            CellData? d = new();
            isNotNull(d);
            d.CellNumber = 1;
            var c = new Cell(d);
            var v = new CellViewFactory().Create(c);
            areEqual(v.CheckCellNr, c.CellNumber);

            // check after adding to repo
            var r = GetRepo.Instance<ICellsRepo>();
            r?.Add(c);
            v = new CellViewFactory().Create(c);
            areNotEqual(v.CheckCellNr, c.CellNumber);
            areEqual(v.CheckCellNr, -1);
        }
    }
}
