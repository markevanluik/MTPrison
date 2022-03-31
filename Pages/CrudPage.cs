﻿using MTPrison.Domain;
using MTPrison.Facade;

namespace MTPrison.Pages {
    public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
        where TView : UniqueView
        where TEntity : UniqueEntity
        where TRepo : ICrudRepo<TEntity> {

        protected CrudPage(TRepo r) : base(r) { }

    }
}
