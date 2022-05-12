using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class ConcurrencyTokenTests : TypeTests {
        [TestMethod] public void ToStrTest() {
            byte[] b = { 0, 1, 124, 255 };
            areEqual("01124255", ConcurrencyToken.ToStr(b));
            areEqual("", ConcurrencyToken.ToStr(null));
        }

        [TestMethod] public void ToByteArrayTest() {
            areEqual(8, ConcurrencyToken.ToByteArray(null).Length);
            areEqual(10, ConcurrencyToken.ToByteArray(GetRandom.String(10, 10)).Length);
        }
    }
}
