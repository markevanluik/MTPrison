using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<CellView, Cell, CellData>, object> {
        private class testClass : BaseViewFactory<CellView, Cell, CellData> {
            protected override Cell toEntity(CellData d) => new(d);
        }
        protected override BaseViewFactory<CellView, Cell, CellData> createObj() => new testClass();

        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var v = GetRandom.Value<CellView>();
            var o = obj.Create(v);
            arePropertiesEqual(v, o.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            var d = GetRandom.Value<CellData>();
            var v = obj.Create(new Cell(d));
            arePropertiesEqual(d, v);
        }
    }
}
