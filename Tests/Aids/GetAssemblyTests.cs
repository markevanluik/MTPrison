using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using MTPrison.Aids;
using MTPrison.Data.Party;
using System.Linq;

namespace MTPrison.Tests.Aids {
    [TestClass] public class GetAssemblyTests : TypeTests {
        private string? name;
        private Assembly? assembly;
        private string[] typeNames = Array.Empty<string>();

        [TestInitialize] public void Init() {
            name = $"{nameof(MTPrison)}.{nameof(MTPrison.Aids)}";
            assembly = GetAssembly.ByName(name);
            typeNames = new string[] {nameof(Chars), nameof(Enums), nameof(Lists),
            nameof(Strings), nameof(Safe), nameof(Types)};
        }
        [TestCleanup] public void Clean() {
            isNotNull(assembly);
            areEqual(name, assembly.GetName().Name);
        }

        [TestMethod] public void ByNameTest() { }

        [TestMethod] public void OfTypeTest() {
            name = $"{nameof(MTPrison)}.{nameof(MTPrison.Data)}";
            var obj = new CountryData();
            assembly = GetAssembly.OfType(obj);
        }
        [TestMethod] public void TypesTest() {
            var list = GetAssembly.Types(assembly);
            isTrue((typeNames.Length) <= (list?.Count ?? -1));
            foreach (var n in typeNames) {
                areEqual(list?.FirstOrDefault(x => x.Name == n)?.Name, n);
                isNull(list?.FirstOrDefault(x => x.Name == GetRandom.String()));
            }
        }
        [TestMethod] public void TypeTest() {
            var n = randomTypeName;
            var obj = GetAssembly.Type(assembly, n);
            isNotNull(obj);
            areEqual(n, obj.Name);
        }
        private string randomTypeName => typeNames[GetRandom.Int32(0, typeNames.Length)];
    }
}
