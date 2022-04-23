
namespace MTPrison.Aids {
    public static class Chars {
        public static bool IsNameChar(this char c) => char.IsLetterOrDigit(c) || c == '`';
        public static bool IsFullNameChar(this char c) => IsNameChar(c) || c == '.';
    }
}
