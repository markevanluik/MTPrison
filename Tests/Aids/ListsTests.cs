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
            areEqual(null, Lists.GetFirst(list));

            list?.Add(1);
            areEqual(1, list.GetFirst());
        }
        [TestMethod] public void RemoveTest() {
            areEqual(0, list.Remove(x => x == 1));

            list?.Add(1); list?.Add(1); list?.Add(3);
            areEqual(2, list.Remove(x => x == 1));
            areEqual(3, list.GetFirst());
        }
        [TestMethod] public void IsEmptyTest() {
            isTrue(list.IsEmpty());

            list?.Add(1);
            isFalse(list.IsEmpty());
        }
        [TestMethod] public void ContainsItemTest() {
            isFalse(list.ContainsItem(x => x == 1));

            list?.Add(2); list?.Add(3); list?.Add(5);
            isTrue(list.ContainsItem(x => x == 5));
        }
    }
}
