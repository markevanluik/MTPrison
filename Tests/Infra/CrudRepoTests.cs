using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;
using System;
using System.Threading.Tasks;

namespace MTPrison.Tests.Infra {
    [TestClass] public class CrudRepoTests : AbstractClassTests<CrudRepo<Prisoner, PrisonerData>, BaseRepo<Prisoner, PrisonerData>> {
        private PrisonDb? db;
        private DbSet<PrisonerData>? set;
        private PrisonerData? d;
        private Prisoner? p;
        private int cnt;
        private class testClass : CrudRepo<Prisoner, PrisonerData> {
            public testClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }
            protected internal override Prisoner toDomain(PrisonerData d) => new(d);
        }
        protected override CrudRepo<Prisoner, PrisonerData> createObj() {
            db = GetRepo.Instance<PrisonDb>();
            set = db?.Prisoners;
            isNotNull(set);
            return new testClass(db, set);
        }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            initSet();
            initAdr();
        }
        private void initSet() {
            cnt = GetRandom.Int32(5, 15);
            for (int i = 0; i < cnt; i++) set?.Add(GetRandom.Value<PrisonerData>());
            _ = db?.SaveChanges();
        }
        private void initAdr() {
            d = GetRandom.Value<PrisonerData>();
            isNotNull(d);
            p = new Prisoner(d);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }

        [TestMethod] public async Task AddTest() {
            isNotNull(p);
            isNotNull(set);
            _ = obj?.Add(p);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task AddAsyncTest() {
            isNotNull(p);
            isNotNull(set);
            _ = await obj.AddAsync(p);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task DeleteTest() {
            isNotNull(d);
            await GetTest();
            _ = obj.Delete(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task DeleteAsyncTest() {
            isNotNull(d);
            await GetTest();
            _ = await obj.DeleteAsync(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task GetTest() {
            isNotNull(d);
            await AddTest();
            var x = obj.Get(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public async Task GetAsyncTest() {
            isNotNull(d);
            await AddTest();
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public void GetListTest() {
            var l = obj.Get();
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task GetListAsyncTest() {
            var l = await obj.GetAsync();
            areEqual(cnt, l.Count);
        }

        [DataRow(nameof(Prisoner.FirstName))]
        [DataRow(nameof(Prisoner.LastName))]
        [DataRow(nameof(Prisoner.Offense))]
        [DataRow(nameof(Prisoner.DoB))]
        [DataRow(nameof(Prisoner.DateOfRelease))]
        [DataRow(nameof(Prisoner.DateOfImprisonment))]
        [DataRow(nameof(Prisoner.FullName))]
        [DataRow(null)]
        [TestMethod] public void GetAllTest(string s) {
            Func<Prisoner, dynamic>? orderBy = null;
            if (s is nameof(Prisoner.Id)) orderBy = x => x.Id;
            else if (s is nameof(Prisoner.FirstName)) orderBy = x => x.FirstName;
            else if (s is nameof(Prisoner.LastName)) orderBy = x => x.LastName;
            else if (s is nameof(Prisoner.Offense)) orderBy = x => x.Offense;
            else if (s is nameof(Prisoner.DoB)) orderBy = x => x.DoB;
            else if (s is nameof(Prisoner.DateOfRelease)) orderBy = x => x.DateOfRelease;
            else if (s is nameof(Prisoner.DateOfImprisonment)) orderBy = x => x.DateOfImprisonment;
            else if (s is nameof(Prisoner.FullName)) orderBy = x => x.FullName; // if problem .ToString() on combined data's maybe
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);
            if (orderBy is null) return;
            for (var i = 0; i < l.Count - 1; i++) {
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bY = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bY);
                var r = aX.CompareTo(bY);
                isTrue(r <= 0);
            }
        }
        [TestMethod] public async Task UpdateTest() {
            await GetTest();
            var dX = GetRandom.Value<PrisonerData>() as PrisonerData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var aX = new Prisoner(dX);
            obj.Update(aX);
            var x = obj.Get(d.Id);
            areEqualProperties(dX, x.Data);
        }
        [TestMethod] public async Task UpdateAsyncTest() {
            await GetTest();
            var dX = GetRandom.Value<PrisonerData>() as PrisonerData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var aX = new Prisoner(dX);
            await obj.UpdateAsync(aX);
            var x = obj.Get(d.Id);
            areEqualProperties(dX, x.Data);
        }
    }
}
