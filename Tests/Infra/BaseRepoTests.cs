using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTPrison.Tests.Infra {
    [TestClass] public class BaseRepoTests : AbstractClassTests<BaseRepo<Prisoner, PrisonerData>, object> {
        private class testClass : BaseRepo<Prisoner, PrisonerData> {
            public testClass(DbContext? c, DbSet<PrisonerData>? s) : base(c, s) { }

            public override bool Add(Prisoner obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(Prisoner obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override List<Prisoner> Get() => throw new NotImplementedException();
            public override Prisoner Get(string id) => throw new NotImplementedException();
            public override List<Prisoner> GetAll(Func<Prisoner, dynamic>? orderBy = null)
                => throw new NotImplementedException();
            public override Task<List<Prisoner>> GetAsync() => throw new NotImplementedException();
            public override Task<Prisoner> GetAsync(string id) => throw new NotImplementedException();
            public override bool Update(Prisoner obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(Prisoner obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<Prisoner, PrisonerData> createObj() => new testClass(null, null);
        [TestMethod] public void dbTest() => isReadOnly<DbContext?>();
        [TestMethod] public void setTest() => isReadOnly<DbSet<PrisonerData>?>();
        [TestMethod] public void BaseRepoTest() {
            var db = GetRepo.Instance<PrisonDb>();
            var set = db?.Prisoners;
            isNotNull(set);
            obj = new testClass(db, set);
            areEqual(db, obj.db);
            areEqual(set, obj.set);
        }
        [TestMethod] public async Task clearTest() {
            BaseRepoTest();
            var cnt = GetRandom.Int32(5, 30);
            var db = obj.db;
            isNotNull(db);
            var set = obj.set;
            isNotNull(set);
            for (int i = 0; i < cnt; i++) set.Add(GetRandom.Value<PrisonerData>());
            areEqual(0, await set.CountAsync());
            db.SaveChanges();
            areEqual(cnt, await set.CountAsync());
            obj.clear();
            areEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => isAbstractMethod(nameof(obj.Add), typeof(Prisoner));
        [TestMethod] public void AddAsyncTest() => isAbstractMethod(nameof(obj.AddAsync), typeof(Prisoner));
        [TestMethod] public void DeleteTest() => isAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void DeleteAsyncTest() => isAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
        [TestMethod] public void GetTest() => isAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetListTest() => isAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAllTest() => isAbstractMethod(nameof(obj.GetAll), typeof(Func<Prisoner, dynamic>));
        [TestMethod] public void GetAsyncTest() => isAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetListAsyncTest() => isAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateTest() => isAbstractMethod(nameof(obj.Update), typeof(Prisoner));
        [TestMethod] public void UpdateAsyncTest() => isAbstractMethod(nameof(obj.UpdateAsync), typeof(Prisoner));
    }
}
