using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CellViewFactoryTests : IsTypeTested {
        [TestMethod] public void CreateTest() => isInconclusive();
    }
}


    //[TestClass] public class CellViewFactoryTests : SealedTests<CellViewFactory> {
    //[TestMethod] public void CreateTest() { }
    
    //[TestMethod] public void CreateViewTest() {
    //        var d = new CellData() {
    //            Id = "----",
    //            CellNumber = 123,
    //            Capacity = 4,
    //            Type = "AAA",
    //            Section = "Gold"
    //        };
    //        var e = new Cell(d);
    //        var v = new CellViewFactory().Create(e);
    //        isNotNull(v);
    //        areEqual(v.Id, e.Id);
    //        areEqual(v.CellNumber, e.CellNumber);
    //        areEqual(v.Amount, e.Amount);
    //        areEqual(v.Capacity, e.Capacity);
    //        areEqual(v.Type, e.Type);
    //        areEqual(v.Section, e.Section);
    //    }
    //    [TestMethod] public void CreateEntityTest() {
    //        var v = new CellView() {
    //            Id = "----",
    //            CellNumber = 123,
    //            Capacity = 4,
    //            Type = "AAA",
    //            Section = "Gold"
    //        };
    //        var e = new CellViewFactory().Create(v);
    //        isNotNull(e);
    //        areEqual(e.Id, v.Id);
    //        areEqual(e.CellNumber, v.CellNumber);
    //        areEqual(e.Amount, v.Amount);
    //        areEqual(e.Capacity, v.Capacity);
    //        areEqual(e.Type, v.Type);
    //        areEqual(e.Section, v.Section);
    //    }
    //}

