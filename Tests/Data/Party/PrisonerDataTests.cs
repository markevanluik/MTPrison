using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using System;

namespace MTPrison.Tests.Data.Party {
    [TestClass] public class PrisonerDataTests : BaseTests<PrisonerData> {
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void OffenseTest() => isProperty<string?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
        [TestMethod] public void DateOfReleaseTest() => isProperty<DateTime?>();
        [TestMethod] public void DateOfImprisonmentTest() => isProperty<DateTime?>();
    }
}
