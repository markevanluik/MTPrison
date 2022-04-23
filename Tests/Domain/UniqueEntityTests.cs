using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;

namespace MTPrison.Tests.Domain {
    [TestClass] public class UniqueEntityTests : AbstractClassTests<UniqueEntity<CountryData>, UniqueEntity> {
        private CountryData? d;

        private class testClass : UniqueEntity<CountryData> {
            public testClass() : this(new CountryData()) { }
            public testClass(CountryData d) : base(d) { }
        }
        protected override UniqueEntity<CountryData> createObj() {
            d = GetRandom.Value<CountryData>();
            return new testClass(d);
        }
        [TestMethod] public void DefaultStrTest() => areEqual("Undefined", UniqueEntity.DefaultStr);
        [TestMethod] public void DataTest() => isReadOnly(d);
        [TestMethod] public void IdTest() => isReadOnly(obj.Data.Id);
    }
}
