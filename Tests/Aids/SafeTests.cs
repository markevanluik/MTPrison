using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class SafeTests : IsTypeTested {
        [TestMethod] public void RunTest() {
            Safe.Run(() => ThrowException());
            Assert.IsTrue(Safe.Run(() => ThrowException("message")) == null);
            Assert.IsTrue(Safe.Run(() => ThrowException("message"), string.Empty) == string.Empty);
        }
        private void ThrowException() {
            throw new System.Exception();
        }
        private string ThrowException(string s) {
            throw new System.Exception(s);
        }
    }
}
