using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System;

namespace MTPrison.Tests.Aids {
    [TestClass]
    public class GetRandomTests : IsTypeTested {
        [TestMethod]
        public void Int32Test() {
            Assert.IsTrue(GetRandom.Int32() is >= int.MinValue and < int.MaxValue);
        }
        [TestMethod]
        public void DoubleTest() {
            Assert.IsTrue(GetRandom.Double() is >= double.MinValue and < double.MaxValue);
        }
        [TestMethod]
        public void CharTest() {
            Assert.IsTrue(GetRandom.Char() is >= char.MinValue and < char.MaxValue);
        }
        [TestMethod]
        public void BoolTest() {
            bool result = GetRandom.Bool();
            Assert.IsTrue(result == true || result == false);
        }
        [TestMethod]
        public void DateTimeTest() {
            DateTime temp = GetRandom.DateTime();
            Assert.IsTrue(temp >= DateTime.Parse("01.01.1900") && temp < DateTime.Parse("01.01.2100"));
        }
        [TestMethod]
        public void StringTest() {
            Assert.IsTrue(GetRandom.String().Length is >= 5 and < 30);
        }
        [TestMethod]
        public void ValueTest() {
            Assert.IsTrue(GetRandom.Value<bool>() is bool);
            Assert.IsTrue(GetRandom.Value<bool?>() is bool);
            Assert.IsTrue(GetRandom.Value<char>() is char);
            Assert.IsTrue(GetRandom.Value<char?>() is char);
            Assert.IsTrue(GetRandom.Value<double>() is double);
            Assert.IsTrue(GetRandom.Value<double?>() is double);
            Assert.IsTrue(GetRandom.Value<int>() is int);
            Assert.IsTrue(GetRandom.Value<int?>() is int);
            Assert.IsTrue(GetRandom.Value<string>() is string);
            Assert.IsTrue(GetRandom.Value<string?>() is string);
            Assert.IsTrue(GetRandom.Value<DateTime>() is DateTime);
            Assert.IsTrue(GetRandom.Value<DateTime?>() is DateTime);
        }
    }
}
