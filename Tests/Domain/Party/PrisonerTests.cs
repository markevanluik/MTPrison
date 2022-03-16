using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;
using System;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class IPrisonersRepoTests : IsTypeTested { }
    [TestClass] public class PrisonerTests : SealedClassTests<Prisoner> {
        [TestMethod] public void IdTest() => isProperty<string?>(null, true);
        [TestMethod] public void FirstNameTest() => isProperty<string?>(null, true);
        [TestMethod] public void LastNameTest() => isProperty<string?>(null, true);
        [TestMethod] public void OffenseTest() => isProperty<string?>(null, true);
        [TestMethod] public void DoBTest() => isProperty<DateTime?>(null, true);
        [TestMethod] public void DateOfReleaseTest() => isProperty<DateTime?>(null, true);
        [TestMethod] public void DateOfImprisonmentTest() => isProperty<DateTime?>(null, true);
        [TestMethod] public void FullNameTest() => isInconclusive();
    }
}
