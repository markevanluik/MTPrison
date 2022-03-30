﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;

namespace MTPrison.Tests.Facade {
    [TestClass] public class BaseViewTests : AbstractClassTests{
        [TestMethod] public void IdTest() => isProperty<string?>();
        private class testClass : UniqueView { }
        protected override object createObject() => new testClass();
    }
}
