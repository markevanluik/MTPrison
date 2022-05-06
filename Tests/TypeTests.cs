using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MTPrison.Tests {
    public abstract class TypeTests : HostTests {
        private string? nameOfTest;
        private string? nameOfType;
        private string? namespaceOfTest;
        private string? namespaceOfType;
        private Assembly? assemblyToBeTested;
        private Type? typeToBeTested;
        private List<string>? membersOfType;
        private List<string>? membersOfTest;

        [TestMethod] public void IsAllTested() => isAllTested();

        protected virtual void isAllTested() {
            nameOfTest = getName(this);
            nameOfType = removeTestsTagFrom(nameOfTest);
            namespaceOfTest = getNamespace(this);
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typeToBeTested = GetType(assemblyToBeTested, nameOfType);
            membersOfType = getMembers(typeToBeTested);
            membersOfTest = getMembers(GetType());
            removeNotTests(GetType());
            removeNotNeedTesting();
            removeTested();
            if (allAreTested()) return;
            reportAllNotTested();

        }

        private static string? getName(object o) => Types.GetName(o?.GetType());
        private static string? removeTestsTagFrom(string? s) => s?.Remove("Tests")?.Remove("Test")?.Replace("..", ".");
        private static string? getNamespace(object o) => GetNamespace.OfType(o);
        private static Assembly? getAssembly(string? name) {
            while (!string.IsNullOrWhiteSpace(name)) {
                var a = GetAssembly.ByName(name);
                if (a != null) return a;
                name = name.RemoveTail();
            }
            return null;
        }
        private static Type? GetType(Assembly? a, string? name) {
            if (string.IsNullOrWhiteSpace(name)) return null;
            foreach (var t in a?.DefinedTypes ?? Array.Empty<TypeInfo>())
                if (t.Name.StartsWith(name)) return t.AsType();
            return null;
        }
        private static List<string>? getMembers(Type? t) => t?.DeclaredMembers();

        private void removeNotTests(Type t) => membersOfTest?.Remove(name => !isCorrectTestMethod(name, t));
        private static bool isCorrectTestMethod(string name, Type t) => hasInheritage(t) && hasAttribute(t) && canTestFor(name, t);
        private static bool hasInheritage(Type t) => t.IsInherited(typeof(TypeTests));
        private static bool hasAttribute(Type t) => t?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool canTestFor(string name, Type t) => t?.Method(name).HasAttribute<TestMethodAttribute>() ?? false;

        private void removeNotNeedTesting() => membersOfType?.Remove(name => !hasTypeForTesting(name));
        private static bool hasTypeForTesting(string name) => name?.IsTypeName() ?? false;

        private void removeTested() => membersOfType?.Remove(name => hasBeenTested(name));
        private bool hasBeenTested(string name) => membersOfTest?.ContainsItem(i => checkAgainstTested(i, name)) ?? false;
        private static bool checkAgainstTested(string i, string name) => i.Equals(name + "Test");

        private bool allAreTested() => membersOfType.IsEmpty();
        private void reportAllNotTested() => isInconclusive($"Member \"{nameOfFirstNotTested()}\" is not tested");
        private string nameOfFirstNotTested() => membersOfType?.GetFirst() ?? string.Empty;

    }
}
