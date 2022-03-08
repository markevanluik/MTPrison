using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System;

namespace MTPrison.Tests.Aids {
    [TestClass] public class TypesTests : IsTypeTested {
        [TestMethod] public void BelongsToTest() {
            Assert.IsFalse(GetType().BelongsTo("Not.A.Namespace"));
            Assert.IsTrue(GetType().BelongsTo("MTPrison.Tests"));
        }
        [TestMethod] public void NameIsTest() {
            Assert.IsFalse(GetType().NameIs("Not.A.Type.Fullname"));
            Assert.IsTrue(GetType().NameIs("MTPrison.Tests.Aids.TypesTests"));
        }
        [TestMethod] public void NameEndsTest() {
            Assert.IsFalse(GetType().NameEnds("Not.A.Type.NameEnd"));
            Assert.IsTrue(GetType().NameEnds(".TypesTests"));
        }
        [TestMethod] public void NameStartsTest() {
            Assert.IsFalse(GetType().NameStarts("Not.A.Type.NameStart"));
            Assert.IsTrue(GetType().NameStarts("MTPrison."));
        }
        [TestMethod] public void IsRealTypeTest() {
            Assert.IsTrue(GetType().IsRealType());
        }
        [TestMethod] public void GetNameTest() {
            areEqual("TypesTests", GetType().GetName());
        }
        [TestMethod] public void DeclaredMembersTest() {
            Assert.IsTrue(Types.DeclaredMembers(null) != null);
            Assert.IsTrue(GetType().DeclaredMembers()?.Count > 0);
        }
        [TestMethod] public void IsInheritedTest() {
            Assert.IsFalse(Types.IsInherited(null, GetType()));
        }
        [TestMethod] public void HasAttributeTest() {
            Assert.IsTrue(GetType().HasAttribute<TestClassAttribute>());
            Assert.IsFalse(GetType().HasAttribute<SerializableAttribute>());
        }
        [TestMethod] public void MethodTest() {
            Assert.IsTrue(GetType().Method("NotAMethod") == null);
            Assert.IsTrue(GetType().Method("MethodTest")?.Name.Equals("MethodTest"));
        }
    }
}
