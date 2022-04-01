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
        public string? CurrentFilter {
            get => repo.CurrentFilter;
            set => repo.CurrentFilter = value;
        }
        public int PageIndex {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage => repo.HasNextPage;
        public bool HasPreviousPage => repo.HasPreviousPage;

        public override IActionResult OnGetCreate(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return base.OnGetCreate(pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnPostCreateAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            ModelState.Remove(nameof(currentFilter));
            ModelState.Remove(nameof(sortOrder));
            return await base.OnPostCreateAsync(pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnGetEditAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnGetEditAsync(id, pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnPostEditAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            ModelState.Remove(nameof(currentFilter));
            ModelState.Remove(nameof(sortOrder));
            return await base.OnPostEditAsync(pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnGetDetailsAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnGetDetailsAsync(id, pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnGetDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnGetDeleteAsync(id, pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnPostDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnPostDeleteAsync(id, pageIndex, currentFilter, sortOrder);
        }
        public override async Task<IActionResult> OnGetIndexAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            return await base.OnGetIndexAsync(pageIndex, currentFilter, sortOrder);
        }
    }
}
