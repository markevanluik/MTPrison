﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class ICountriesRepoTests : TypeTests { }
    [TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {
        protected override Country createObj() => new(GetRandom.Value<CountryData>());
        [TestMethod] public void CountryCurrenciesTest()
            => itemsTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(
                d => d.CountryId = obj.Id, d => new CountryCurrency(d), () => obj.CountryCurrencies);

        [TestMethod] public void CurrenciesTest() => relatedItemsTest<ICurrenciesRepo, CountryCurrency, Currency, CurrencyData>
            (CountryCurrenciesTest, () => obj.CountryCurrencies, () => obj.Currencies,
            x => x.CurrencyId, d => new Currency(d), c => c?.Data, x => x?.Currency?.Data);
    }
}