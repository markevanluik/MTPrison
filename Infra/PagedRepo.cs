using Microsoft.EntityFrameworkCore;
using MTPrison.Data;
using MTPrison.Domain;

namespace MTPrison.Infra {
    public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
        protected PagedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }

        internal int skippedItemsCount => PageSize * PageIndex;
        internal static int itemsCountInPage = 10;

        public int PageIndex { get; set; }
        public int TotalPages => totalPages;
        public bool HasNextPage => PageIndex < TotalPages - 1;
        public bool HasPreviousPage => PageIndex > 0;
        public int PageSize { get; set; } = itemsCountInPage;

        // sql query
        protected internal override IQueryable<TData> createSql() => addSkipAndTake(base.createSql());
        internal IQueryable<TData> addSkipAndTake(IQueryable<TData> query) => query.Skip(skippedItemsCount).Take(PageSize);
        internal int totalPages => (int)Math.Ceiling(countPages);
        internal double countPages => itemsCount / (double)PageSize;
        internal int itemsCount => base.createSql().Count();
    }
}
