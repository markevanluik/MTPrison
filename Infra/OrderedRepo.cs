using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using MTPrison.Data;
using MTPrison.Domain;

namespace MTPrison.Infra {
    public abstract class OrderedRepo<TDomain, TData> : FilteredRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
        protected OrderedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
        public string? CurrentOrder { get; set; }
        public static string DescendingString => "_desc";
        // sql query
        protected internal override IQueryable<TData> createSql() => addSort(base.createSql());
        internal IQueryable<TData> addSort(IQueryable<TData> query) {
            if (string.IsNullOrWhiteSpace(CurrentOrder)) return query;
            var e = lambdaExpression;
            return e == null ? query
                : isDescending ? query.OrderByDescending(e)
                : (IQueryable<TData>)query.OrderBy(e);
        }
        internal bool isDescending => CurrentOrder?.EndsWith(DescendingString) ?? false;
        internal bool isSameProperty(string s) => !string.IsNullOrEmpty(s) && (CurrentOrder?.StartsWith(s) ?? false);
        internal string propertyName => CurrentOrder?.Replace(DescendingString, "") ?? "";
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
            return !isSameProperty(n) ? n + DescendingString
                : isDescending ? n : n + DescendingString;
        }
    }
}
