using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class PrisonerCellViewFactoryTests : SealedClassTests<PrisonerCellViewFactory, BaseViewFactory<PrisonerCellView, PrisonerCell, PrisonerCellData>> {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<PrisonerCellView>();
            var e = new PrisonerCellViewFactory().Create(v);
            isNotNull(e);
            arePropertiesEqual(e, v);
        }
    }
}
