﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade;

namespace MTPrison.Tests.Facade {
    [TestClass] public class IsoNamedViewTests : AbstractClassTests<IsoNamedView, NamedView> {
        private class testClass : IsoNamedView { }
        protected override IsoNamedView createObj() => new testClass();

        [TestMethod] public void CodeTest() => isRequired<string>("ISO 3-letter");
        [TestMethod] public void NameTest() => isDisplayNamed<string>("English name");
        [TestMethod] public void NativeNameTest() => isDisplayNamed<string>("Native name");
    }
}
