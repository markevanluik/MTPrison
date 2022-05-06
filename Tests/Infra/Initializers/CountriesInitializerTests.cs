using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;

namespace MTPrison.Tests.Infra.Initializers {
    [TestClass] public class CountriesInitializerTests : SealedBaseTests<CountriesInitializer, BaseInitializer<CountryData>> {
        protected override CountriesInitializer createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            return new CountriesInitializer(db);
        }
    }
}
