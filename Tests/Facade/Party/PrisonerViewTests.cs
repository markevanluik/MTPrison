﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Facade.Party;
using System;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class PrisonerViewTests : BaseTests<PrisonerView> {
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void OffenseTest() => isProperty<string?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
        [TestMethod] public void DateOfReleaseTest() => isProperty<DateTime?>();
        [TestMethod] public void DateOfImprisonmentTest() => isProperty<DateTime?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
    }
    [TestClass] public class PrisonerViewFactoryTests : IsTypeTested { }

}
