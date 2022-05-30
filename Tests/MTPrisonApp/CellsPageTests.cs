using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Infra.Party;
using System.Threading.Tasks;

namespace MTPrison.Tests.MTPrisonApp {
    [TestClass] public class CellsPageTests : BasePageTests {
        private readonly string name = $"{nameof(CellsRepo)[0..^4]}";
        [TestMethod] public async Task CellsIndexPageTest() => await GetIndexPageTest<ICellsRepo, Cell, CellData>(name, x => new Cell(x));
        [TestMethod] public async Task CellsEditPageTest() {
            (CellData d, string html) = await GetEditPageTest<ICellsRepo, Cell, CellData>(name, x => new Cell(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CellsDetailsPageTest() {
            (CellData d, string html) = await GetDetailsPageTest<ICellsRepo, Cell, CellData>(name, x => new Cell(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CellsDeletePageTest() {
            (CellData d, string html) = await GetDeletePageTest<ICellsRepo, Cell, CellData>(name, x => new Cell(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task CellsCreatePageTest() {
            (CellData d, string html) = await GetCreatePageTest<ICellsRepo, Cell, CellData>(name, x => new Cell(x));
            isNotNull(d);
        }
        private static void isNotNull(CellData d) {
            isNotNull(d.CellNumber);
            isNotNull(d.Section);
            isNotNull(d.Capacity);
            isNotNull(d.Type);
        }
        private static void isTrue(CellData d, string html) {
            isTrue(html.Contains(d.CellNumber.ToString()));
            isTrue(html.Contains(d.Section.ToString()));
            isTrue(html.Contains(d.Type.ToString()));
        }
    }
}
