using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
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
        protected static void arePropertiesEqual(dynamic? expected, dynamic? actual, params string[]? excluded) {
            bool isExcluded;
            var tExpected = expected?.GetType();
            foreach (var piExpected in tExpected?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                isExcluded = false;
                foreach (var s in excluded ?? Array.Empty<string>())
                    if (piExpected.Name == s) isExcluded = true;
                if (isExcluded) continue;
                var piActual = actual?.GetType().GetProperty(piExpected.Name);
                if (piActual is null) continue;
                areEqual(piExpected.GetValue(expected), piActual.GetValue(actual));
            }
        }
        protected static void areEqualProperties(object? a, object? b) {
            isNotNull(a);
            isNotNull(b);
            var tA = a.GetType();
            var tB = b.GetType();
            foreach (var piA in tA?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                var vA = piA.GetValue(a);
                var piB = tB?.GetProperty(piA.Name);
                var vB = piB?.GetValue(b);
                areEqual(vA, vB, $"for property {piA.Name}.");
            }
        }
    }
}
