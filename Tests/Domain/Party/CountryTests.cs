using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class ICountriesRepoTests : TypeTests { }
    [TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {
        protected override Country createObj() => new(GetRandom.Value<CountryData>());
        [TestMethod] public void CodeTest() => isReadOnly(obj.Data.Code);
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void NativeNameTest() => isReadOnly(obj.Data.NativeName);
        [TestMethod] public void CountryCurrenciesTest() => isInconclusive();
        [TestMethod] public void CountriesTest() => isInconclusive();
    }
}
