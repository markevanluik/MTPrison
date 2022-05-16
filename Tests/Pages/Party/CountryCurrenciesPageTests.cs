using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrison.Pages;
using MTPrison.Pages.Party;

namespace MTPrison.Tests.Pages.Party {
    [TestClass] public class CountryCurrenciesPageTests : SealedBaseTests<CountryCurrenciesPage, PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrenciesRepo>> {
        private readonly ICountryCurrenciesRepo? r = GetRepo.Instance<ICountryCurrenciesRepo>();
        private readonly ICountriesRepo? co = GetRepo.Instance<ICountriesRepo>();
        private readonly ICurrenciesRepo? cu = GetRepo.Instance<ICurrenciesRepo>();
        private CountryCurrency? cc;
        private Country? cntry;
        private Currency? crncy;
        private CountryCurrencyView? v;
        protected override CountryCurrenciesPage createObj() {
            isNotNull(r); isNotNull(co); isNotNull(cu);
            return new CountryCurrenciesPage(r, co, cu);
        }
        [TestInitialize]  public void Init() {
            cc = new CountryCurrency(GetRandom.Value<CountryCurrencyData>());
            cntry = new Country(GetRandom.Value<CountryData>());
            crncy = new Currency(GetRandom.Value<CurrencyData>());
            v = new CountryCurrencyViewFactory().Create(cc);
            r?.Add(cc);
            co?.Add(cntry);
            cu?.Add(crncy);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void CountriesTest() => isReadOnly<SelectListItem>();
        [TestMethod] public void CurrenciesTest() => isReadOnly<SelectListItem>();
        [TestMethod] public void CountryNameTest() {
            isNotNull(cntry);
            var result = obj.CountryName(cntry.Id);
            areEqual(cntry.Name, result);
            result = obj.CountryName("");
            areEqual("Unspecified", result);
            result = obj.CountryName(null);
            areEqual("Unspecified", result);
        }
        [TestMethod] public void CurrencyNameTest() {
            isNotNull(crncy);
            var result = obj.CurrencyName(crncy.Id);
            areEqual(crncy.Name, result);
            result = obj.CurrencyName("");
            areEqual("Unspecified", result);
            result = obj.CurrencyName(null);
            areEqual("Unspecified", result);
        }
        [TestMethod] public void GetValueTest() {
            isNotNull(cc);
            isNotNull(v);
            var result = obj.GetValue(nameof(cc.Id), v);
            areEqual(cc.Id, result);
            result = obj.GetValue(nameof(cc.CountryId), v);
            areEqual("Unspecified", result);
        }
    }
}
