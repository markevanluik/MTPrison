using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;
using MTPrison.Infra.Party;

namespace MTPrison.Tests.Infra.Party {
    [TestClass] public class CurrenciesRepoTests : SealedRepoTests<CurrenciesRepo, Repo<Currency, CurrencyData>, Currency, CurrencyData> {
        protected override CurrenciesRepo createObj() => new(GetRepo.Instance<PrisonDb>());
        protected override object? getSet(PrisonDb db) => db.Currencies;
    }
}
