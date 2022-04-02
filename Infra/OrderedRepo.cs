using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using MTPrison.Data;
using MTPrison.Domain;

namespace MTPrison.Infra {
    public abstract class OrderedRepo<TDomain, TData> : FilteredRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
        protected OrderedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }

        public string CurrentSort { get; set; }
        public static string DescendingString => "_desc";


        protected internal override IQueryable<TData> createSql() => addSort(base.createSql());
        internal IQueryable<TData> addSort(IQueryable<TData> query) {
            if (string.IsNullOrWhiteSpace(CurrentSort)) return query;
            var e = lambdaExpression;
            if (e is null) return query;
            if (isDescending) return query.OrderByDescending(e);
            return query.OrderBy(e);
        }
        internal bool isDescending => CurrentSort?.EndsWith(DescendingString) ?? false;
        internal bool isSameProperty(string s) => (string.IsNullOrEmpty(s) ? false : (CurrentSort?.StartsWith(s) ?? false));
        internal string propertyName => CurrentSort?.Replace(DescendingString, "") ?? "";
        internal PropertyInfo? propertyInfo => typeof(TData).GetProperty(propertyName);
        internal Expression<Func<TData, object>>? lambdaExpression {
            get {
                if (propertyInfo is null) return null;
                var param = Expression.Parameter(typeof(TData), "x");
                var property = Expression.Property(param, propertyInfo);
                var body = Expression.Convert(property, typeof(object));
                return Expression.Lambda<Func<TData, object>>(body, param);
            }
        }
        public string SortOrder(string propertyName) {
            var n = propertyName;
            if (!isSameProperty(n)) return n + DescendingString;
            if (isDescending) return n;
            return n + DescendingString;
        }
    }
}
