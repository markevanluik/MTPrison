using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class PrisonerCellViewTests : SealedClassTests<PrisonerCellView, NamedView> {
        [TestMethod] public void PrisonerIdTest() => isRequired<string>("Prisoner");
        [TestMethod] public void CellIdTest() => isRequired<string>("Cell");
        [TestMethod] public void CodeTest() => isDisplayNamed<string>("Interests");
        [TestMethod] public void NameTest() => isDisplayNamed<string>("Date Of Imprisonment");
        [TestMethod] public void NativeNameTest() => isDisplayNamed<string>("Date Of Release");
    }
}
