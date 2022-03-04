using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System.Collections.Generic;

namespace MTPrison.Tests.Aids {
    [TestClass] public class ListsTests : IsTypeTested {
        [TestMethod] public void GetFirstTest() {
            var list = new List<dynamic>();
            Assert.AreEqual(null, Lists.GetFirst(list));

            list.Add(1);
            Assert.AreEqual(1, list.GetFirst());
        }
        [TestMethod] public void RemoveTest() {
            var empty = new List<dynamic>();
            Assert.AreEqual(0, empty.Remove(x => x == "1"));  // trying remove "1", 0 removes

            var list = new List<dynamic> { 1, 1, 3};
            Assert.AreEqual(2, list.Remove(x => x == 1));     // trying remove 2  1's
            Assert.AreEqual(3, list.GetFirst());              // 3 remains
        }
        [TestMethod] public void IsEmptyTest() {
            var list = new List<dynamic>();
            Assert.IsTrue(list.IsEmpty());

            list.Add(1);
            Assert.IsFalse(list.IsEmpty());
        }
        [TestMethod] public void ContainsItemTest() {
            var list = new List<dynamic>();
            Assert.IsFalse(list.ContainsItem(x => x == 1));

            list.Add(2); list.Add(3); list.Add(5);
            Assert.IsTrue(list.ContainsItem(x => x == 5));
        }
    }
}
