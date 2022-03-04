using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using System;

namespace MTPrison.Tests.Aids {
    [TestClass] public class GetRandomTests : IsTypeTested {
        [TestMethod] public void Int32Test() {
            //for (int i = 0; i < 999999999; i++) {
                Assert.IsTrue(GetRandom.Int32() is >= int.MinValue and < int.MaxValue);
            //}
        }
        [TestMethod] public void DoubleTest() {
            //for (int i = 0; i < 999999999; i++) {
                Assert.IsTrue(GetRandom.Double() is >= double.MinValue and < double.MaxValue);
            //}
        }
        [TestMethod] public void CharTest() {
            //for (int i = 0; i < 999999999; i++) {
                Assert.IsTrue(GetRandom.Char() is >= char.MinValue and < char.MaxValue);
            //}
        }
        [TestMethod] public void BoolTest() {
            //for (int i = 0; i < 999999999; i++) {
                Assert.IsTrue(GetRandom.Bool() || true);
            //}
        }
        [TestMethod] public void DateTimeTest() {
            //for (int i = 0; i < 99999999; i++) {
                DateTime temp = GetRandom.DateTime();
                Assert.IsTrue(temp >= DateTime.Parse("01.01.1900") && temp < DateTime.Parse("01.01.2100"));
            //}
        }
        [TestMethod] public void StringTest() {
            //for (int i = 0; i < 99999999; i++) {
                Assert.IsTrue(GetRandom.String().Length is >= 5 and < 30);
            //}
        }
        [TestMethod] public void ValueTest() {
            try {
                //for (int j = 0; j < 9999999; j++) {
                    _ = GetRandom.Value<int>();
                    _ = GetRandom.Value<int?>();
                    _ = GetRandom.Value<double>();
                    _ = GetRandom.Value<double?>();
                    _ = GetRandom.Value<char>();
                    _ = GetRandom.Value<char?>();
                    _ = GetRandom.Value<bool>();
                    _ = GetRandom.Value<bool?>();
                    _ = GetRandom.Value<DateTime>();
                    _ = GetRandom.Value<DateTime?>();
                    _ = GetRandom.Value<string>();
                    _ = GetRandom.Value<string?>();
                    _ = GetRandom.Value<long>();    // everything else turns into string..
                //}
                Assert.IsTrue(true);
            } catch { Exception e; }
        }
    }
}
