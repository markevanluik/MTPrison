using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.Net;
using System.Threading.Tasks;

namespace MTPrison.Tests.ShopTickets {

    public abstract class PagesTests : HostTests { } // separate class for clean-code/tests -
    [TestClass] public class IndexPageTests : PagesTests {
        [TestMethod] public async Task GetCountriesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x));
            var page = await client.GetAsync("/Countries?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains($"<h1>Countries</h1>")); // >Log in< if [Authorize] is active
        }
        [TestMethod] public async Task GetCurrenciesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out cnt, x => new Currency(x));
            var page = await client.GetAsync("/Currencies?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Currencies</h1>"));
        }
        [TestMethod] public async Task GetCellsIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICellsRepo, Cell, CellData>(out cnt, x => new Cell(x));
            var page = await client.GetAsync("/Cells?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Cells</h1>"));
        }
        [TestMethod] public async Task GetPrisonersIndexPageTest() {
            int cnt;
            var d = addRandomItems<IPrisonersRepo, Prisoner, PrisonerData>(out cnt, x => new Prisoner(x));
            var page = await client.GetAsync("/Prisoners?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Prisoners</h1>"));
        }
        [TestMethod] public async Task GetCountriesDetailPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x), id);
            isNotNull(d);
            isNotNull(d.Code);
            isNotNull(d.Name);
            isNotNull(d.NativeName);
            var page = await client.GetAsync($"/Countries/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains($"<h1>Details</h1>"));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.NativeName));
        }
    }
}
