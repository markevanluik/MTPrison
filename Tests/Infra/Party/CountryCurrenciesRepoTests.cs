using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using MTPrison.Infra;
using MTPrison.Infra.Party;

namespace MTPrison.Tests.Infra.Party {
    [TestClass] public class CountryCurrenciesRepoTests
        : SealedRepoTests<CountryCurrenciesRepo, Repo<CountryCurrency, CountryCurrencyData>, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrenciesRepo createObj() => new(GetRepo.Instance<PrisonDb>());
        protected override object? getSet(PrisonDb db) => db.CountryCurrencies;
    }
}
