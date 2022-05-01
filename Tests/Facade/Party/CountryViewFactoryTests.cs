using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CountryViewFactoryTests : ViewFactoryTests<CountryViewFactory, CountryView, Country, CountryData> {
        protected override Country toObject(CountryData d) => new(d);
    }
}
