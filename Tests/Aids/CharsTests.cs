using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class CharsTests : TypeTests {
        private char letter;
        private char digit;
        [TestInitialize] public void Init() {
            letter = GetRandom.Char('a', 'z');
            digit = GetRandom.Char('0', '9');
        }
        [TestMethod] public void IsNameCharTest() {
            isTrue(Chars.IsNameChar(letter));
            isTrue(Chars.IsNameChar(digit));
            isFalse(Chars.IsNameChar('.'));
            isFalse(Chars.IsNameChar('_'));
            isTrue(Chars.IsNameChar('`'));
            isFalse(Chars.IsNameChar(':'));
        }
        [TestMethod] public void IsFullNameCharTest() {
            isTrue(Chars.IsFullNameChar(letter));
            isTrue(Chars.IsFullNameChar(digit));
            isTrue(Chars.IsFullNameChar('.'));
            isTrue(Chars.IsFullNameChar('`'));
            isFalse(Chars.IsFullNameChar('_'));
            isFalse(Chars.IsFullNameChar(':'));
        }
    }
}
