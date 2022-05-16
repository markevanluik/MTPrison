using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrison.Pages;
using MTPrison.Pages.Party;

namespace MTPrison.Tests.Pages.Party {
    [TestClass] public class CurrenciesPageTests : SealedBaseTests<CurrenciesPage, PagedPage<CurrencyView, Currency, ICurrenciesRepo>> {
        private readonly ICurrenciesRepo? r = GetRepo.Instance<ICurrenciesRepo>();
        protected override CurrenciesPage createObj() {
            isNotNull(r);
            return new CurrenciesPage(r);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void CountriesTest() => isReadOnly<Lazy<List<Country?>>>();
    }
}
