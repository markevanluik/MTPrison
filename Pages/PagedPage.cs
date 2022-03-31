using Microsoft.AspNetCore.Mvc;
using MTPrison.Domain;
using MTPrison.Facade;

namespace MTPrison.Pages {
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>
        where TView : UniqueView
        where TEntity : UniqueEntity
        where TRepo : IPagedRepo<TEntity> {

        protected PagedPage(TRepo r) : base(r) { }

        public string? CurrentSort { get; set; }
        public string? CurrentFilter { get; set; }
        public int PageIndex {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage => repo.HasNextPage;
        public bool HasPreviousPage => repo.HasPreviousPage;

        public async override Task<IActionResult> OnGetIndexAsync(int pageIndex = 0, string currentFilter = null, string sortOrder = null) {
            PageIndex = pageIndex;
            return await base.OnGetIndexAsync(pageIndex, currentFilter, sortOrder);
        }
    }
}
