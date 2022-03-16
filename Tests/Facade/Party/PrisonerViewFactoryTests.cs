using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;

namespace MTPrison.Tests.Facade.Party {
    [TestClass] public class PrisonerViewFactoryTests : SealedClassTests<PrisonerViewFactory> { 
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<PrisonerData>();
            var e = new Prisoner(d);
            var v = new PrisonerViewFactory().Create(e);
            isNotNull(v);
            //TODO
            //arePropertiesEaqual(v, e, nameof(v.FullName));
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.Offense, e.Offense);
            areEqual(v.DoB, e.DoB);
            areEqual(v.DateOfImprisonment, e.DateOfImprisonment);
            areEqual(v.DateOfRelease, e.DateOfRelease);
            areEqual(v.FullName, e.FullName());
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<PrisonerView>();
            var e = new PrisonerViewFactory().Create(v);
            isNotNull(e);
            //TODO
            //arePropertiesEaqual(e, v);
            areEqual(e.Id, v.Id);
            areEqual(e.FirstName, v.FirstName);
            areEqual(e.LastName, v.LastName);
            areEqual(e.Offense, v.Offense);
            areEqual(e.DoB, v.DoB);
            areEqual(e.DateOfImprisonment, v.DateOfImprisonment);
            areEqual(e.DateOfRelease, v.DateOfRelease);
            areNotEqual(e.FullName(), v.FullName);
        }
    }
}
