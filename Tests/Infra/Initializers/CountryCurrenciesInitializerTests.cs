using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Infra.Initializers;

namespace MTPrison.Tests.Infra.Initializers {
    [TestClass] public class CountryCurrenciesInitializerTests : SealedBaseTests<CountryCurrenciesInitializer, BaseInitializer<CountryCurrencyData>> {
        protected override CountryCurrenciesInitializer createObj() {
            var db = GetRepo.Instance<PrisonDb>();
            return new CountryCurrenciesInitializer(db);
        }
    }
}
