using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrison.Pages;
using MTPrison.Pages.Party;

namespace MTPrison.Tests.Pages.Party {
    [TestClass] public class CellsPageTests : SealedBaseTests<CellsPage, PagedPage<CellView, Cell, ICellsRepo>> {
        private readonly ICellsRepo? r = GetRepo.Instance<ICellsRepo>();
        private CellView? v;
        private Cell? c;

        protected override CellsPage createObj() {
            isNotNull(r);
            return new CellsPage(r);
        }
        [TestInitialize] public void Init() {
            var d = GetRandom.Value<CellData>();
            isNotNull(d);
            c = new Cell(d);
            v = new CellViewFactory().Create(c);
            r?.Add(c);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void UniqueCellsTest() => isReadOnly<SelectListItem>();
        [TestMethod] public void TypesTest() => isReadOnly<SelectListItem>();
        [TestMethod] public void CellTypeDescriptionTest() {
            var result = obj.CellTypeDescription(CellType.Duo);
            areEqual(CellType.Duo.Description(), result);
            result = obj.CellTypeDescription(null);
            areEqual(CellType.Standard.Description(), result);
        }
        [TestMethod] public void GetValueTest() {
            isNotNull(c);
            isNotNull(v);
            var result = obj.GetValue(nameof(c.Type), v);
            areEqual(c.Type?.Description(), result);
        }
        [TestMethod] public void PrisonersTest() => isReadOnly<Lazy<List<Prisoner?>>>();
    }
}
