using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Infra.Party;
using System.Threading.Tasks;

namespace MTPrison.Tests.MTPrisonApp {
    [TestClass] public class CountryCurrenciesPageTests : BasePageTests {
        private readonly string name = $"{nameof(CountryCurrenciesRepo)[0..^4]}";
        [TestMethod] public async Task CountryCurrenciesIndexPageTest()
            => await GetIndexPageTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(name, x => new CountryCurrency(x));
        [TestMethod] public async Task CountryCurrenciesEditPageTest() {
            (CountryCurrencyData d, string html) = await GetEditPageTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(name, x => new CountryCurrency(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CountryCurrenciesDetailsPageTest() {
            (CountryCurrencyData d, string html) = await GetDetailsPageTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(name, x => new CountryCurrency(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CountryCurrenciesDeletePageTest() {
            (CountryCurrencyData d, string html) = await GetDeletePageTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(name, x => new CountryCurrency(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CountryCurrenciesCreatePageTest() {
            (CountryCurrencyData d, string html) = await GetCreatePageTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(name, x => new CountryCurrency(x));
            isNotNull(d);
        }
        private static void isNotNull(CountryCurrencyData d) {
            isNotNull(d.CountryId);
            isNotNull(d.CurrencyId);
            isNotNull(d.CountryName);
            isNotNull(d.CurrencyName);
            isNotNull(d.Code);
            isNotNull(d.Name);
            isNotNull(d.NativeName);
        }
        private static void isTrue(CountryCurrencyData d, string html) {
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.NativeName));
        }
    }
}
