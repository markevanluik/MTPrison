using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using MTPrison.Data;
using MTPrison.Domain;
using MTPrison.Infra;
using MTPrison.Aids;
using System;

namespace MTPrison.Tests.Infra.Party {
    public abstract class SealedRepoTests<TClass, TBaseClass, TDomain, TData>
    : SealedBaseTests<TClass, TBaseClass>
    where TClass : FilteredRepo<TDomain, TData>
    where TBaseClass : class
    where TDomain : UniqueEntity<TData>, new()
    where TData : UniqueData, new() {
        private static Type prisonType => typeof(PrisonDb);
        public static Type setType => typeof(DbSet<TData>);
        private PrisonDb prisonDb {
            get {
                var o = obj.db;
                isNotNull(o);
                var db = o as PrisonDb;
                isNotNull(db);
                return db;
            }
        }
        protected void instanceTest(object? o, Type t) {
            isNotNull(o);
            isInstanceOfType(o, t);
        }
        protected void instanceTest(object? o, Type t, object? expected = null) {
            instanceTest(o, t);
            instanceTest(expected, t);
            areEqual(expected, o);
        }
        [TestMethod] public void DbContextTest() => instanceTest(obj.db, prisonType);
        [TestMethod] public void DbSetTest() => instanceTest(obj.set, setType, getSet(prisonDb));
        [TestMethod] public void ToDomainTest() {
            var d = GetRandom.Value<TData>();
            var o = obj.toDomain(d);
            isNotNull(o);
            isInstanceOfType(o, typeof(TDomain));
            areEqualProperties(d, o.Data);
        }
        [TestMethod] public void AddFilterTest() {
            static string contains(string s) => $"x.{s}.Contains";
            static string toStrContains(string s) => $"x.{s}.ToString().Contains";
            obj.CurrentFilter = "abc";
            var q = obj.createSql();
            var s = q.Expression.ToString();
            isNotNull(q);
            foreach (var p in typeof(TData).GetProperties()) {
                if (p.PropertyType == typeof(string)) isTrue(s.Contains(contains(p.Name)), $"{p.Name} property no where to be found");
                else isTrue(s.Contains(toStrContains(p.Name)), $"{p.Name} property no where to be found");
            }
        }
        protected abstract object? getSet(PrisonDb db);
    }
}
