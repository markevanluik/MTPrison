using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System;

namespace MTPrison.Tests.Aids {
    [TestClass] public class TypesTests : IsTypeTested {
        [TestMethod] public void BelongsToTest() {
            isFalse(GetType().BelongsTo("Not.A.Namespace"));
            isTrue(GetType().BelongsTo("MTPrison.Tests"));
        }
        [TestMethod] public void NameIsTest() {
            isFalse(GetType().NameIs("Not.A.Type.Fullname"));
            isTrue(GetType().NameIs("MTPrison.Tests.Aids.TypesTests"));
        }
        [TestMethod] public void NameEndsTest() {
            isFalse(GetType().NameEnds("Not.A.Type.NameEnd"));
            isTrue(GetType().NameEnds(".TypesTests"));
        }
        [TestMethod] public void NameStartsTest() {
            isFalse(GetType().NameStarts("Not.A.Type.NameStart"));
            isTrue(GetType().NameStarts("MTPrison."));
        }
        [TestMethod] public void IsRealTypeTest() {
            isTrue(GetType().IsRealType());
        }
        [TestMethod] public void GetNameTest() {
            areEqual("TypesTests", GetType().GetName());
        }
        [TestMethod] public void DeclaredMembersTest() {
            isTrue(Types.DeclaredMembers(null) != null);
            isTrue(GetType().DeclaredMembers()?.Count > 0);
        }
        [TestMethod] public void IsInheritedTest() {
            isFalse(Types.IsInherited(null, GetType()));
        }
        [TestMethod] public void HasAttributeTest() {
            isTrue(GetType().HasAttribute<TestClassAttribute>());
            isFalse(GetType().HasAttribute<SerializableAttribute>());
        }
        [TestMethod] public void MethodTest() {
            isTrue(GetType().Method("NotAMethod") == null);
            isTrue(GetType().Method("MethodTest")?.Name.Equals("MethodTest"));
        }
    }
}
