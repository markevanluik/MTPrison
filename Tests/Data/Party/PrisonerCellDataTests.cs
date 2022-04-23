using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data;
using MTPrison.Data.Party;

namespace MTPrison.Tests.Data.Party {
    [TestClass]
    public class PrisonerCellDataTests : SealedClassTests<PrisonerCellData, NamedData> {
        [TestMethod] public void PrisonerIdTest() => isProperty<string>();
        [TestMethod] public void CellIdTest() => isProperty<string>();
    }
}
