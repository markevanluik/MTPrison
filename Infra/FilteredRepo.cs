using Microsoft.EntityFrameworkCore;
using MTPrison.Data;
using MTPrison.Domain;

namespace MTPrison.Infra {
    public abstract class FilteredRepo<TDomain, TData> : CrudRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
        protected FilteredRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
