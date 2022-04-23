using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class ICountryCurrenciesTests : TypeTests { }
    [TestClass] public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>> {
        protected override CountryCurrency createObj() => new(GetRandom.Value<CountryCurrencyData>());
        [TestMethod] public void CountryIdTest() => isReadOnly(obj.Data.CountryId);
        [TestMethod] public void CurrencyIdTest() => isReadOnly(obj.Data.CurrencyId);
        [TestMethod] public void CountryNameTest() => isReadOnly(obj.Data.CountryName);
        [TestMethod] public void CurrencyNameTest() => isReadOnly(obj.Data.CurrencyName);
        [TestMethod] public void CodeTest() => isReadOnly(obj.Data.Code);
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void NativeNameTest() => isReadOnly(obj.Data.NativeName);

        [TestMethod] public void CountryTest() => GetRepo.Instance<ICountriesRepo>()?.Get(obj.Data.CountryId);
        [TestMethod] public void CurrencyTest() => GetRepo.Instance<ICurrenciesRepo>()?.Get(obj.Data.CurrencyId);
    }
}
