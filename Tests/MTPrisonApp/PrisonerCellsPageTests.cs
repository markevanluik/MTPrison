using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Infra.Party;
using System.Threading.Tasks;

namespace MTPrison.Tests.MTPrisonApp {
    [TestClass] public class PrisonerCellsPageTests : BasePageTests {
        private readonly string name = $"{nameof(PrisonerCellsRepo)[0..^4]}";
        [TestMethod] public async Task PrisonerCellsIndexPageTest()
            => await GetIndexPageTest<IPrisonerCellsRepo, PrisonerCell, PrisonerCellData>(name, x => new PrisonerCell(x));
        [TestMethod] public async Task PrisonerCellsEditPageTest() {
            (PrisonerCellData d, string html) = await GetEditPageTest<IPrisonerCellsRepo, PrisonerCell, PrisonerCellData>(name, x => new PrisonerCell(x));
            isNotNull(d);
            isTrue(html.Contains(d.Code));
        }
        [TestMethod] public async Task PrisonerCellsDetailsPageTest() {
            (PrisonerCellData d, string html) = await GetDetailsPageTest<IPrisonerCellsRepo, PrisonerCell, PrisonerCellData>(name, x => new PrisonerCell(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task PrisonerCellsDeletePageTest() {
            (PrisonerCellData d, string html) = await GetDeletePageTest<IPrisonerCellsRepo, PrisonerCell, PrisonerCellData>(name, x => new PrisonerCell(x));
            isNotNull(d);
            isTrue(d, html);
        }
        [TestMethod] public async Task PrisonerCellsCreatePageTest() {
            (PrisonerCellData d, string html) = await GetCreatePageTest<IPrisonerCellsRepo, PrisonerCell, PrisonerCellData>(name, x => new PrisonerCell(x));
            isNotNull(d);
        }
        private static void isNotNull(PrisonerCellData d) {
            isNotNull(d.PrisonerId);
            isNotNull(d.CellId);
            isNotNull(d.Code);
            isNotNull(d.Name);
            isNotNull(d.NativeName);
        }
        private static void isTrue(PrisonerCellData d, string html) {
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains(d.NativeName));
        }
    }
}
