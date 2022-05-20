using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using System.Threading.Tasks;

namespace MTPrison.Tests.MTPrisonApp {
    [TestClass] public class PrisonersPageTests : BasePageTests {
        [TestMethod] public async Task PrisonersIndexPageTest() => await GetIndexPageTest<IPrisonersRepo, Prisoner, PrisonerData>("Prisoners", x => new Prisoner(x));
        [TestMethod] public async Task PrisonersEditPageTest() {
            (PrisonerData d, string html) = await GetEditPageTest<IPrisonersRepo, Prisoner, PrisonerData>("Prisoners", x => new Prisoner(x));
            isNotNull(d);
            isTrue(d, html);
            isTrue(html.Contains(d.DoB.ToString("yyyy-MM-dd")));
            isTrue(html.Contains(d.DateOfImprisonment.ToString("yyyy-MM-dd")));
            isTrue(html.Contains(d.DateOfRelease.ToString("yyyy-MM-dd")));
        }
        [TestMethod] public async Task PrisonersDetailsPageTest() {
            (PrisonerData d, string html) = await GetDetailsPageTest<IPrisonersRepo, Prisoner, PrisonerData>("Prisoners", x => new Prisoner(x));
            isNotNull(d);
            isTrue(d, html);
            isTrue(html.Contains(d.DoB.ToShortDateString()));
            isTrue(html.Contains(d.DateOfImprisonment.ToShortDateString()));
            isTrue(html.Contains(d.DateOfRelease.ToShortDateString()));
        }
        [TestMethod] public async Task PrisonersDeletePageTest() {
            (PrisonerData d, string html) = await GetDeletePageTest<IPrisonersRepo, Prisoner, PrisonerData>("Prisoners", x => new Prisoner(x));
            isNotNull(d);
            isTrue(d, html);
            isTrue(html.Contains(d.DoB.ToShortDateString()));
            isTrue(html.Contains(d.DateOfImprisonment.ToShortDateString()));
            isTrue(html.Contains(d.DateOfRelease.ToShortDateString()));
        }
        [TestMethod] public async Task PrisonersCreatePageTest() {
            (PrisonerData d, string html) = await GetCreatePageTest<IPrisonersRepo, Prisoner, PrisonerData>("Prisoners", x => new Prisoner(x));
            isNotNull(d);
        }
        private static void isNotNull(PrisonerData d) {
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.Offense);
            isNotNull(d.DoB);
            isNotNull(d.DateOfRelease);
            isNotNull(d.DateOfImprisonment);
        }
        private static void isTrue(PrisonerData d, string html) {
            isTrue(html.Contains(d.FirstName));
            isTrue(html.Contains(d.LastName));
            isTrue(html.Contains(d.Offense));
        }
    }
}
