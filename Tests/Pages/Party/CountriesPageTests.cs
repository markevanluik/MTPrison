using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrison.Pages;
using MTPrison.Pages.Party;

namespace MTPrison.Tests.Pages.Party {
    [TestClass] public class CountriesPageTests : SealedBaseTests<CountriesPage, PagedPage<CountryView, Country, ICountriesRepo>> {
        private readonly ICountriesRepo? r = GetRepo.Instance<ICountriesRepo>();
        protected override CountriesPage createObj() {
            isNotNull(r);
            return new CountriesPage(r);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void CurrenciesTest() => isReadOnly<Lazy<List<Currency?>>>();
    }
}
