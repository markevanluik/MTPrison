using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class CharsTests : IsTypeTested {
        [TestMethod] public void IsNameCharTest() {
            isTrue(Chars.IsNameChar('A'));
            isTrue(Chars.IsNameChar('9'));
            isFalse(Chars.IsNameChar('.'));
            isFalse(Chars.IsNameChar('_'));
            isFalse(Chars.IsNameChar(':'));
        }
        [TestMethod] public void IsFullNameCharTest() {
            isTrue(Chars.IsFullNameChar('A'));
            isTrue(Chars.IsFullNameChar('9'));
            isTrue(Chars.IsFullNameChar('.'));
            isFalse(Chars.IsFullNameChar('_'));
            isFalse(Chars.IsFullNameChar(':'));
        }
    }
}
