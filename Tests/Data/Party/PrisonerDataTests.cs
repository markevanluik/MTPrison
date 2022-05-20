using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data;
using MTPrison.Data.Party;
using System;

namespace MTPrison.Tests.Data.Party {
    [TestClass] public class PrisonerDataTests : SealedClassTests<PrisonerData, UniqueData> {
        [TestMethod] public void FirstNameTest() => isProperty<string>();
        [TestMethod] public void LastNameTest() => isProperty<string>();
        [TestMethod] public void SSNTest() => isProperty<string>();
        [TestMethod] public void CountryTest() => isProperty<string>();
        [TestMethod] public void OffenseTest() => isProperty<string>();
        [TestMethod] public void DateOfImprisonmentTest() => isProperty<DateTime>();
        [TestMethod] public void DateOfReleaseTest() => isProperty<DateTime>();
    }
}
