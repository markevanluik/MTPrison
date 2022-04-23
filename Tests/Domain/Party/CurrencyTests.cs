using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class ICurrenciesRepoTests : TypeTests { }
    [TestClass] public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>> {
        protected override Currency createObj() => new(GetRandom.Value<CurrencyData>());
        [TestMethod] public void CodeTest() => isReadOnly(obj.Data.Code);
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void NativeNameTest() => isReadOnly(obj.Data.NativeName);
        [TestMethod] public void CountryCurrenciesTest() => isInconclusive();
        [TestMethod] public void CountriesTest() => isInconclusive();
    }
}
