using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<PrisonerView, Prisoner, PrisonerData>, object> {
        private class testClass : BaseViewFactory<PrisonerView, Prisoner, PrisonerData> {
            protected override Prisoner toEntity(PrisonerData d) => new(d);
        }
        protected override BaseViewFactory<PrisonerView, Prisoner, PrisonerData> createObj() => new testClass();
    }
}
