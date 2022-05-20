using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.Threading.Tasks;

namespace MTPrison.Tests.MTPrisonApp {
    [TestClass] public class CountriesPageTests : BasePageTests {
        [TestMethod] public async Task CountriesIndexPageTest() => await GetIndexPageTest<ICountriesRepo, Country, CountryData>("Countries", x => new Country(x));
        [TestMethod] public async Task CountriesEditPageTest() {
            (CountryData d, string html) = await GetEditPageTest<ICountriesRepo, Country, CountryData>("Countries", x => new Country(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CountriesDetailsPageTest() {
            (CountryData d, string html) = await GetDetailsPageTest<ICountriesRepo, Country, CountryData>("Countries", x => new Country(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CountriesDeletePageTest() {
            (CountryData d, string html) = await GetDeletePageTest<ICountriesRepo, Country, CountryData>("Countries", x => new Country(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CountriesCreatePageTest() {
            (CountryData d, string html) = await GetCreatePageTest<ICountriesRepo, Country, CountryData>("Countries", x => new Country(x));
            isNotNull(d);
        }
        private static void isNotNull(CountryData d) {
            isNotNull(d.Code);
            isNotNull(d.Name);
            isNotNull(d.NativeName);
        }
        private static void isTrue(CountryData d, string html) {
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.NativeName));
        }
    }
}
