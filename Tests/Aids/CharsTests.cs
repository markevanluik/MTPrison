using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class CharsTests : IsTypeTested {
        private char letter;
        private char digit;
        [TestInitialize] public void Init() {
            letter = GetRandom.Char('a', 'z');
            digit = GetRandom.Char('0', '9');
        }
        [TestMethod] public void IsNameCharTest() {
            isTrue(Chars.IsNameChar(letter));
            isFalse(Chars.IsNameChar(digit));
            isFalse(Chars.IsNameChar('.'));
            isFalse(Chars.IsNameChar('_'));
            isFalse(Chars.IsNameChar('`'));
            isFalse(Chars.IsNameChar(':'));
        }
        [TestMethod] public void IsFullNameCharTest() {
            isTrue(Chars.IsFullNameChar(letter));
            isFalse(Chars.IsFullNameChar(digit));
            isTrue(Chars.IsFullNameChar('.'));
            isTrue(Chars.IsFullNameChar('`'));
            isFalse(Chars.IsFullNameChar('_'));
            isFalse(Chars.IsFullNameChar(':'));
        }
    }
}
