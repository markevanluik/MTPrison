using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Tests.Aids;
using System.Diagnostics;
using System.Reflection;

namespace MTPrison.Tests {
    public abstract class BaseTests<TClass, TBaseClass> : TypesTests where TClass : class where TBaseClass : class {

        protected TClass obj;
        protected abstract TClass createObj();
        protected BaseTests() => obj = createObj();

        protected void isProperty<T>(T? value = default, bool isReadOnly = false, string? callingMethod = null) {
            callingMethod ??= nameof(isProperty);
            var memberName = getCallingMember(callingMethod).Replace("Test", string.Empty);
            var propertyInfo = obj.GetType().GetProperty(memberName);
            isNotNull(propertyInfo);
            if (isNullOrDefault(value)) value = random<T>();
            if (canWrite(propertyInfo, isReadOnly )) propertyInfo?.SetValue(obj, value);
            areEqual(value, propertyInfo?.GetValue(obj));
        }
 
        protected void isReadOnly<T>(T? value) => isProperty(value, true, nameof(isReadOnly));
        private static bool isNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;
        private static bool canWrite(PropertyInfo i, bool isReadOnly) {
            var canWrite = i?.CanWrite ?? false;
            areEqual(canWrite, !isReadOnly);
            return canWrite;
        }
        private static T? random<T>() => GetRandom.Value<T>();
        private static string getCallingMember(string memberName) {
            var s = new StackTrace();
            var isNext = false;
            for (var i = 0; i < s.FrameCount - 1; i++) {
                var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
                if (n is "MoveNext" or "Start") continue;
                if (isNext) return n;
                if (n == memberName) isNext = true;
            }
            return string.Empty;
        }
        [TestMethod] public void BaseClassTest() => areEqual(typeof(TClass).BaseType, typeof(TBaseClass));
    }
}
