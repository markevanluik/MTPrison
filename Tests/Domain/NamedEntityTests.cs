using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain;

namespace MTPrison.Tests.Domain {
    [TestClass] public class NamedEntityTests : AbstractClassTests<NamedEntity<CountryData>, UniqueEntity<CountryData>> {
        private class testClass : NamedEntity<CountryData> {
            public testClass() : this(new CountryData()) { }
            public testClass(CountryData d) : base(d) { }
        }
        protected override NamedEntity<CountryData> createObj() => new testClass(GetRandom.Value<CountryData>());
        [TestMethod] public void CodeTest() => isReadOnly(obj.Data.Code);
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void NativeNameTest() => isReadOnly(obj.Data.NativeName);
    }
}
