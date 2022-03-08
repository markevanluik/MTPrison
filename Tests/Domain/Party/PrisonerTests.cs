using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain.Party;
using System;

namespace MTPrison.Tests.Domain.Party {
    [TestClass] public class PrisonerTests : BaseTests<Prisoner> {
        private readonly Prisoner prisoner = new();
        [TestMethod] public void IdTest() {
            areEqual("Undefined", prisoner.Id);
        }
        [TestMethod] public void FirstNameTest() {
            areEqual("Undefined", prisoner.FirstName);
        }
        [TestMethod] public void LastNameTest() {
            areEqual("Undefined", prisoner.LastName);
        }
        [TestMethod] public void OffenseTest() {
            areEqual("Undefined", prisoner.Offense);
        }
        [TestMethod] public void DoBTest() {
            areEqual(DateTime.MinValue, prisoner.DoB);
        }
        [TestMethod] public void DateOfReleaseTest() {
            areEqual(DateTime.MinValue, prisoner.DateOfRelease);
        }
        [TestMethod] public void DateOfImprisonmentTest() {
            areEqual(DateTime.MinValue, prisoner.DateOfImprisonment);
        }
        [TestMethod] public void FullnameTest() {
            areEqual("Undefined Undefined", prisoner.Fullname());
        }
    }
}
