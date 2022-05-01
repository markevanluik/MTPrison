using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class ICurrenciesRepoTests : TypeTests { }
    [TestClass] public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>> {
        protected override Currency createObj() => new(GetRandom.Value<CurrencyData>());
        [TestMethod] public void CountryCurrenciesTest()
            => itemsTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(
                d => d.CurrencyId = obj.Id, d => new CountryCurrency(d), () => obj.CountryCurrencies);

        [TestMethod] public void CountriesTest() => relatedItemsTest<ICountriesRepo, CountryCurrency, Country, CountryData>
            (CountryCurrenciesTest, () => obj.CountryCurrencies, () => obj.Countries,
            x => x.CountryId, d => new Country(d), c => c?.Data, x => x?.Country?.Data);
    }
}
