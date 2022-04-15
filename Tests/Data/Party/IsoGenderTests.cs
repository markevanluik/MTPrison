using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data.Party;
using MTPrison.Aids;

namespace MTPrison.Tests.Data.Party {
    [TestClass] public class IsoGenderTests : IsTypeTested {
        [TestMethod] public void MaleTest() => doTest(IsoGender.Male, 1, "Male");
        [TestMethod] public void FemaleTest() => doTest(IsoGender.Female, 2, "Female");
        [TestMethod] public void NotKnownTest() => doTest(IsoGender.NotKnown, 0, "Not known");
        [TestMethod] public void NotApplicableTest() => doTest(IsoGender.NotApplicable, 9, "Not applicable");

        private static void doTest(IsoGender gender, int value, string description) {
            areEqual(value, (int)gender);
            areEqual(description, gender.Description());
        }
    }
}
