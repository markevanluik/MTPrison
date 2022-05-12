using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Aids {
    [TestClass] public class CopyTests : TypeTests {
        [TestMethod] public void PropertiesTest() {
            var d = GetRandom.Value<CountryData>();
            var v = new CountryView();
            Copy.Properties(d, v);
            arePropertiesEqual(d, v);

            v = GetRandom.Value<CountryView>();
            d = new CountryData();
            Copy.Properties(v, d);
            arePropertiesEqual(v, d);
        }
    }
}
