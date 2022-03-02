using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTPrison.Tests.MTPrisonApp {
    [TestClass] public class IsMTPrisonAppTested : IsAssemblyTested {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"MTPrison.MTPisonApp\"");
    }
}
