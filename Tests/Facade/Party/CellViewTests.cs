﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class CellViewTests : SealedClassTests<CellView> {
        [TestMethod] public void CellNumberTest() => isProperty<int>();
        [TestMethod] public void CapacityTest() => isProperty<int>();
        [TestMethod] public void TypeTest() => isProperty<string?>();
        [TestMethod] public void SectionTest() => isProperty<string?>();
    }
}
