using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using MTPrison.Aids;

namespace MTPrison.Tests.Aids {
    [TestClass] public class GetAssemblyTests : IsTypeTested {
        private Assembly? assembly;
        private List<Type>? assemblyList;
        private Type? type;
        [TestMethod] public void ByNameTest() {
            assembly = GetAssembly.ByName("No.Business.Here");
            Assert.IsNull(assembly);

            assembly = GetAssembly.ByName("MTPrison.Aids");
            Assert.IsNotNull(assembly);
        }
        [TestMethod] public void OfTypeTest() {
            assembly = GetAssembly.OfType(this);
            Assert.IsNotNull(assembly);
            Assert.AreEqual("MTPrison.Tests", assembly?.FullName?.Split(',')[0]);
        }
        [TestMethod] public void TypesTest() {
            assembly = GetAssembly.ByName("No.Business.Here");
            assemblyList = GetAssembly.Types(assembly);
            Assert.IsNull(assemblyList);

            assembly = GetAssembly.ByName("MTPrison.Aids");
            assemblyList = GetAssembly.Types(assembly);
            Assert.IsNotNull(assemblyList);
        }
        [TestMethod] public void TypeTest() {
            assembly = GetAssembly.ByName("MTPrison.Aids");
            type = assembly?.Type("NotAType");
            Assert.IsNull(type);

            assembly = GetAssembly.ByName("MTPrison.Aids");
            type = assembly?.Type("GetAssembly");
            Assert.IsNotNull(type);
            Assert.AreEqual(type?.FullName, "MTPrison.Aids.GetAssembly");

        }
    }
}
