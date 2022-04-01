using Microsoft.EntityFrameworkCore;
using MTPrison.Data;
using MTPrison.Domain;

namespace MTPrison.Infra {
    public abstract class FilteredRepo<TDomain, TData> : CrudRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
        protected FilteredRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }

        public string CurrentFilter { get; set; }

        // sql query
        protected internal override IQueryable<TData> createSql() => addFilter(base.createSql());
        internal virtual IQueryable<TData> addFilter(IQueryable<TData> query) => query;
    }
}
