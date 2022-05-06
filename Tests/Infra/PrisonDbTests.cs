using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using MTPrison.Infra;

namespace MTPrison.Tests.Infra {
    [TestClass] public class PrisonDbTests : SealedBaseTests<PrisonDb, DbContext> {
        protected override PrisonDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}
