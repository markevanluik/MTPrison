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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MTPrison.Tests.Pages.Party {
    [TestClass] public class PrisonersPageTests : SealedBaseTests<PrisonersPage, PagedPage<PrisonerView, Prisoner, IPrisonersRepo>> {
        private readonly IPrisonersRepo? pr = GetRepo.Instance<IPrisonersRepo>();
        private readonly ICountriesRepo? cr = GetRepo.Instance<ICountriesRepo>();
        private Prisoner? p;
        private PrisonerView? v;
        private Country? cntry;
        protected override PrisonersPage createObj() {
            isNotNull(pr); isNotNull(cr);
            return new PrisonersPage(pr, cr);
        }
        [TestInitialize] public void Init() {
            p = new Prisoner(GetRandom.Value<PrisonerData>());
            v = new PrisonerViewFactory().Create(p);
            cntry = p.Cntry;
            isNotNull(cntry);
            pr?.Add(p);
            cr?.Add(cntry);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
        [TestMethod] public void CountriesTest() => isReadOnly<SelectListItem>();

        [TestMethod] public void CountryNameTest() {
            isNotNull(cntry);
            var result = obj.CountryName(cntry.Id);
            areEqual(cntry.Name, result);
            result = obj.CountryName("jama");
            areEqual("Unspecified", result);
        }
        [TestMethod] public void ShortDateTest() {
            DateTime d = GetRandom.Value<DateTime>();
            var result = obj.ShortDate(d);
            areEqual(d.ToShortDateString(), result);
            result = obj.ShortDate(null);
            areEqual(DateTime.MinValue.ToShortDateString(), result);
        }
        [TestMethod] public void GetValueTest() {
            isNotNull(p);
            isNotNull(v);
            var result = obj.GetValue(nameof(p.DateOfRelease), v);
            areEqual(p.DateOfRelease.ToShortDateString(), result);
        }
        [TestMethod] public void CellsTest() => isReadOnly<Lazy<List<Cell?>>>();
    }
}

