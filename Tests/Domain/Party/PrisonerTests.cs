using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class PrisonerTests : BaseTests<Prisoner> {
        [TestMethod] public void IdTest() => isInconclusive();
        [TestMethod] public void FirstNameTest() => isInconclusive();
        [TestMethod] public void LastNameTest() => isInconclusive();
        [TestMethod] public void OffenseTest() => isInconclusive();
        [TestMethod] public void DoBTest() => isInconclusive();
        [TestMethod] public void DateOfReleaseTest() => isInconclusive();
        [TestMethod] public void DateOfImprisonmentTest() => isInconclusive();
        [TestMethod] public void FullnameTest() => isInconclusive();
    }
}
