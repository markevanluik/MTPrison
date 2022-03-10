using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;
using System;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class IPrisonersRepoTests : IsTypeTested { }
    [TestClass] public class PrisonerTests : BaseTests<Prisoner> {
        private readonly Prisoner prisoner = new();
        [TestMethod] public void IdTest() => isProperty<string?>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void OffenseTest() => isProperty<string?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
        [TestMethod] public void DateOfReleaseTest() => isProperty<DateTime?>();
        [TestMethod] public void DateOfImprisonmentTest() => isProperty<DateTime?>();
        [TestMethod] public void FullnameTest() => isProperty<string?>();
    }
}
