using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System.Collections.Generic;

namespace MTPrison.Tests.Aids {
    [TestClass] public class ListsTests : IsTypeTested {
        private List<dynamic>? list;

        [TestInitialize] public void Init() {
            list = new List<dynamic>();
        }

        [TestMethod] public void GetFirstTest() {
            Assert.AreEqual(null, Lists.GetFirst(list));

            list?.Add(1);
            Assert.AreEqual(1, list.GetFirst());
        }
        [TestMethod] public void RemoveTest() {
            Assert.AreEqual(0, list.Remove(x => x == 1));

            list?.Add(1); list?.Add(1); list?.Add(3);
            Assert.AreEqual(2, list.Remove(x => x == 1));
            Assert.AreEqual(3, list.GetFirst());
        }
        [TestMethod] public void IsEmptyTest() {
            Assert.IsTrue(list.IsEmpty());

            list?.Add(1);
            Assert.IsFalse(list.IsEmpty());
        }
        [TestMethod] public void ContainsItemTest() {
            Assert.IsFalse(list.ContainsItem(x => x == 1));

            list?.Add(2); list?.Add(3); list?.Add(5);
            Assert.IsTrue(list.ContainsItem(x => x == 5));
        }
    }
}
