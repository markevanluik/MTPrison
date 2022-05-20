using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;
using MTPrison.Facade.Party;
using System;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class PrisonerViewTests : SealedClassTests<PrisonerView, UniqueView> {
        [TestMethod] public void FirstNameTest() => isRequired<string>("First Name");
        [TestMethod] public void LastNameTest() => isRequired<string>("Last Name");
        [TestMethod] public void DoBTest() => isDisplayNamed<DateTime>("Birth Date");
        [TestMethod] public void OffenseTest() => isRequired<string>("Offense");
        [TestMethod] public void DateOfImprisonmentTest() => isDisplayNamed<DateTime>("Date Of Imprisonment");
        [TestMethod] public void DateOfReleaseTest() => isDisplayNamed<DateTime>("Date Of Release");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string>("Full Name");
    }
}
