using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class PrisonerCellViewFactoryTests : ViewFactoryTests<PrisonerCellViewFactory, PrisonerCellView, PrisonerCell, PrisonerCellData> {
        protected override PrisonerCell toObject(PrisonerCellData d) => new(d);
    }
}
