using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class PrisonerViewFactoryTests : SealedClassTests<PrisonerViewFactory, BaseViewFactory<PrisonerView, Prisoner, PrisonerData>> {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<PrisonerData>();
            var e = new Prisoner(d);
            var v = new PrisonerViewFactory().Create(e);
            isNotNull(v);
            arePropertiesEqual(v, e, nameof(v.FullName));
            areEqual(v.FullName, e.FullName());
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<PrisonerView>();
            var e = new PrisonerViewFactory().Create(v);
            isNotNull(e);
            arePropertiesEqual(e, v);
            areNotEqual(e.FullName(), v?.FullName);
        }
    }
}
