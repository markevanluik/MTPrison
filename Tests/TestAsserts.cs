using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace MTPrison.Tests {
    public abstract class TestAsserts {
        protected static void isTrue(bool? b, string? msg = null) => Assert.IsTrue(b ?? false, msg ?? string.Empty);
        protected static void isFalse(bool? b, string? msg = null) => Assert.IsFalse(b ?? true, msg ?? string.Empty);
        protected static void isInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
        protected static void isNotNull([NotNull] object? o = null, string? msg = null) => Assert.IsNotNull(o, msg ?? string.Empty);
        protected static void isNull(object? o = null, string? msg = null) => Assert.IsNull(o, msg ?? string.Empty);
        protected static void areEqual(object? expected, object? actual, string? msg = null) => Assert.AreEqual(expected, actual, msg ?? string.Empty);
        protected static void areNotEqual(object? expected, object? actual, string? msg = null) => Assert.AreNotEqual(expected, actual, msg ?? string.Empty);
        protected static void isInstanceOfType(object o, Type expectedType, string? msg = null) => Assert.IsInstanceOfType(o, expectedType, msg ?? string.Empty);
        protected static void arePropertiesEqual(dynamic? expected, dynamic? actual, params string[] exclude) {
            var prop = expected?.GetType().GetProperties() ?? Array.Empty<PropertyInfo>();
            foreach (PropertyInfo pi in prop) {
                if (exclude?.Contains(pi.Name) ?? false) continue;
                var exp = pi.GetValue(expected);
                var act = actual?.GetType().GetProperty(pi.Name)?.GetValue(actual);
                if (act is null) continue;
                areEqual(exp, act);
            }
        }
        protected static void areEqualProperties(object? a, object? b, params string[] exclude) {
            isNotNull(a);
            isNotNull(b);
            var tA = a.GetType();
            var tB = b.GetType();
            foreach (var piA in tA?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                if (exclude?.Contains(piA.Name) ?? false) continue;
                var vA = piA.GetValue(a);
                var piB = tB?.GetProperty(piA.Name);
                var vB = piB?.GetValue(b);
                areEqual(vA, vB, $"for property {piA.Name}.");
            }
        }
    }
}
