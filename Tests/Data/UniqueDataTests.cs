﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Data;

namespace MTPrison.Tests.Data {
    [TestClass]
    public class UniqueDataTests : AbstractClassTests {
        private class testClass : UniqueData { }
        protected override object createObject() => new testClass();
        [TestMethod] public void NewIdTest() {
            isNotNull(UniqueData.NewId);
            areNotEqual(UniqueData.NewId, UniqueData.NewId);
            var pi = typeof(UniqueData).GetProperty(nameof(UniqueData.NewId));
            isFalse(pi?.CanWrite);
        }
        [TestMethod] public void IdTest() => isProperty<string>();

    }
}
