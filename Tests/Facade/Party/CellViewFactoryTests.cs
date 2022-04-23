using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass]
    public class CellViewFactoryTests : SealedClassTests<CellViewFactory, BaseViewFactory<CellView, Cell, CellData>> {
        [TestMethod] public void CreateTest() { }

        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<CellData>();
            var e = new Cell(d);
            var v = new CellViewFactory().Create(e);
            isNotNull(v);
            arePropertiesEqual(v, e);
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<CellView>();
            var e = new CellViewFactory().Create(v);
            isNotNull(e);
            arePropertiesEqual(e, v);
        }
    }
}
