using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Infra.Party;
using System.Threading.Tasks;

namespace MTPrison.Tests.MTPrisonApp {
    [TestClass] public class CurrenciesPageTests : BasePageTests {
        private readonly string name = $"{nameof(CurrenciesRepo)[0..^4]}";
        [TestMethod] public async Task CurrenciesIndexPageTest() => await GetIndexPageTest<ICurrenciesRepo, Currency, CurrencyData>(name, x => new Currency(x));
        [TestMethod] public async Task CurrenciesEditPageTest() {
            (CurrencyData d, string html) = await GetEditPageTest<ICurrenciesRepo, Currency, CurrencyData>(name, x => new Currency(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CurrenciesDetailsPageTest() {
            (CurrencyData d, string html) = await GetDetailsPageTest<ICurrenciesRepo, Currency, CurrencyData>(name, x => new Currency(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CurrenciesDeletePageTest() {
            (CurrencyData d, string html) = await GetDeletePageTest<ICurrenciesRepo, Currency, CurrencyData>(name, x => new Currency(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CurrenciesCreatePageTest() {
            (CurrencyData d, string html) = await GetCreatePageTest<ICurrenciesRepo, Currency, CurrencyData>(name, x => new Currency(x));
            isNotNull(d);
        }
        private static void isNotNull(CurrencyData d) {
            isNotNull(d.Code);
            isNotNull(d.Name);
            isNotNull(d.NativeName);
        }
        private static void isTrue(CurrencyData d, string html) {
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.NativeName));
        }
    }
}
