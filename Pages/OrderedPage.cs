﻿using MTPrison.Domain;
using MTPrison.Facade;

namespace MTPrison.Pages {
    public abstract class OrderedPage<TView, TEntity, TRepo> : FilteredPage<TView, TEntity, TRepo>
        where TView : UniqueView
        where TEntity : UniqueEntity
        where TRepo : IOrderedRepo<TEntity> {

        protected OrderedPage(TRepo r) : base(r) { }

    }
}
