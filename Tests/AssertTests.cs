﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace MTPrison.Tests {
    public abstract class AssertTests {
        protected void inconclusive() => Assert.Inconclusive();
        protected static void isNotNull([NotNull] object? o = null) => Assert.IsNotNull(o);
        protected static void areEqual(object? expected, object? actual) => Assert.AreEqual(expected, actual);
    }
}
