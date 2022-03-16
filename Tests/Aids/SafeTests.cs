using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class SafeTests : IsTypeTested {
        [TestMethod] public void RunTest() {
            Safe.Run(() => ThrowException());
            isTrue(Safe.Run(() => ThrowException("message")) == null);
            isTrue(Safe.Run(() => ThrowException("message"), string.Empty) == string.Empty);
        }
        private static void ThrowException() {
            throw new System.Exception();
        }
        private static string ThrowException(string s) {
            throw new System.Exception(s);
        }
    }
}
