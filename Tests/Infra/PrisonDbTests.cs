using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using MTPrison.Infra;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MTPrison.Data.Party;

namespace MTPrison.Tests.Infra {
    [TestClass] public class PrisonDbTests : SealedBaseTests<PrisonDb, DbContext> {
        protected override PrisonDb createObj() {
            var options = new DbContextOptionsBuilder<PrisonDb>().UseInMemoryDatabase("TestDb").Options;
            return new PrisonDb(options);
        }
        private class testClass : DbContext {
            public testClass() { }
            protected override void OnModelCreating(ModelBuilder b) {
                base.OnModelCreating(b);
                PrisonDb.InitializeTables(b);
            }
            public ModelBuilder RunOnModelCreating() {
                var set = new ConventionSet();
                var mb = new ModelBuilder(set);
                OnModelCreating(mb);
                return mb;
            }
        }
        [TestMethod] public void PrisonersTest() => isProperty(obj.Prisoners);
        [TestMethod] public void CellsTest() => isProperty(obj.Cells);
        [TestMethod] public void CountriesTest() => isProperty(obj.Countries);
        [TestMethod] public void CurrenciesTest() => isProperty(obj.Currencies);
        [TestMethod] public void PrisonerCellsTest() => isProperty(obj.PrisonerCells);
        [TestMethod] public void CountryCurrenciesTest() => isProperty(obj.CountryCurrencies);
        [TestMethod]
        public void InitializeTablesTest() {
            var builder = new testClass().RunOnModelCreating();
            testEntity<PrisonerData>(builder);
            testEntity<CellData>(builder);
            testEntity<CountryData>(builder);
            testEntity<CurrencyData>(builder);
            testEntity<PrisonerCellData>(builder);
            testEntity<CountryCurrencyData>(builder);
        }
        private void testEntity<T>(ModelBuilder b) {
            var name = typeof(T).FullName ?? string.Empty;
            var entity = b.Model.FindEntityType(name);
            Assert.IsNotNull(entity, name);
        }
    }
}
