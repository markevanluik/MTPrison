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
    [TestClass] public class PrisonersPageTests : SealedBaseTests<PrisonersPage, PagedPage<PrisonerView, Prisoner, IPrisonersRepo>> {
        private readonly IPrisonersRepo? r = GetRepo.Instance<IPrisonersRepo>();
        private Prisoner? p;
        private PrisonerView? v;
        protected override PrisonersPage createObj() {
            isNotNull(r);
            return new PrisonersPage(r);
        }
        [TestInitialize] public void Init() {
            p = new Prisoner(GetRandom.Value<PrisonerData>());
            v = new PrisonerViewFactory().Create(p);
            r?.Add(p);
        }
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string[]>();
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
            var result = obj.GetValue(nameof(p.DoB), v);
            areEqual(p.DoB.ToShortDateString(), result);
        }
        [TestMethod] public void CellsTest() => isReadOnly<Lazy<List<Cell?>>>();
    }
}
