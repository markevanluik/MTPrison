using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MTPrison.Tests {
    public abstract class AssemblyTests : TestAsserts {
        private static string testsStr => "Tests";
        private static string testsProjectStr => $"{testsStr}.";
        private string notTestedMsg => $"Class \"{fullNameOfFirstNotTested()}\" is not tested";

        private Assembly? testingAssembly;
        private Assembly? assemblyToBeTested;
        private List<Type>? testingTypes;
        private List<Type>? typesToBeTested;
        private string? namespaceOfTest;
        private string? namespaceOfType;

        [TestMethod] public void IsAllTested() => isAllTested();

        protected virtual void isAllTested() {
            testingAssembly = getAssembly(this);
            testingTypes = getTypes(testingAssembly);
            namespaceOfTest = getNamespace(this);
            removeNotInNamespace(testingTypes, namespaceOfTest);
            removeNotClassTests();
            removeNotCorrectTests();
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getTypes(assemblyToBeTested);
            removeNotInNamespace(typesToBeTested, namespaceOfType);
            removeInterfaces();
            removeNotNeedTesting();
            removeDuplicates();
            removeTested();
            if (allAreTested()) return;
            reportAllNotTested();
        }

        private void removeNotInNamespace(List<Type>? t, string? nameSpace) => t?.Remove(x => !Types.NameStarts(x, nameSpace));
        private void removeNotClassTests() => testingTypes.Remove(x => !Types.NameEnds(x, testsStr));
        private void removeNotCorrectTests() => testingTypes.Remove(x => !hasTestFor(x));
        private static Assembly? getAssembly(object o) => GetAssembly.OfType(o);
        private static List<Type>? getTypes(Assembly? a) => GetAssembly.Types(a);
        private static string? getNamespace(object o) => GetNamespace.OfType(o);
        private static string? removeTestsTagFrom(string? s) => s?.Remove(testsProjectStr);
        private static Assembly? getAssembly(string? name) => GetAssembly.ByName(name);

        private void removeInterfaces() => typesToBeTested?.RemoveAll(t => t.IsInterface);
        private void removeNotNeedTesting() => typesToBeTested?.Remove(t => !hasTypeForTesting(t));
        private bool hasTypeForTesting(Type t) => t?.BelongsTo(namespaceOfType) ?? false;
        private void removeDuplicates() => typesToBeTested?.Find(t => isItDuplicate(t));
        private bool isItDuplicate(Type x) {
            var type = typesToBeTested?.Find(y => isDuplicate(y, x));
            if (type is null) return false;
            _ = typesToBeTested?.Remove(type);
            return type is not null;
        }
        private static bool isDuplicate(Type x, Type y) {
            if (x == y) return false;
            var nameX = x.Name;
            var nameY = y.Name;
            var lengthX = nameX.IndexOf('`');
            var lengthY = nameY.IndexOf('`');
            if (lengthX >= 0) nameX = nameX[..lengthX];
            if (lengthY >= 0) nameY = nameY[..lengthY];
            return nameX == nameY;
        }
        private void removeTested() => typesToBeTested?.Remove(t => hasCorrectTest(t));
        private bool hasCorrectTest(Type t) {
            var type = testingTypes?.Find(i => canTestFor(i, t));
            if (type is null) return false;
            _ = testingTypes?.Remove(type);
            return type is not null;
        }
        private static bool canTestFor(Type testingType, Type typeToBeTested) {
            var testName = typeToBeTested.FullName ?? string.Empty;
            testName = testName.RemoveHead();
            var length = testName.IndexOf('`');
            if (length >= 0) testName = testName[..length];
            return testingType.NameEnds($".{testName}{testsStr}");
        }

        private static bool hasTestFor(Type i) => hasInheritage(i) && hasAttribute(i);
        private static bool hasInheritage(Type i) => i.IsInherited(typeof(TypeTests));
        private static bool hasAttribute(Type i) => i?.HasAttribute<TestClassAttribute>() ?? false;

        private bool allAreTested() => typesToBeTested.IsEmpty();
        private void reportAllNotTested() => isInconclusive(notTestedMsg);
        private string fullNameOfFirstNotTested() => firstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        private static Type? firstNotTestedType(List<Type>? l) => l.GetFirst();
    }
}
