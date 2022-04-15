using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;

namespace MTPrison.Tests.Data.Party {
    [TestClass] public class CountryCurrencyDataTests : SealedClassTests<CountryCurrencyData> {
        [TestMethod] public void CountryIdTest() => isProperty<string>();
        [TestMethod] public void CurrencyIdTest() => isProperty<string>();
        [TestMethod] public void CountryNameTest() => isProperty<string>();
        [TestMethod] public void CurrencyNameTest() => isProperty<string>();
    }
}
