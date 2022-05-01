using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTPrison.Domain;
using MTPrison.Domain.Party;
using System;

namespace MTPrison.Tests.Domain {
    [TestClass] public class GetRepoTests : TypeTests {
        private class testClass : IServiceProvider {
            public object? GetService(Type serviceType) => throw new NotImplementedException();
        }
        [TestMethod] public void InstanceTest()
            => Assert.IsInstanceOfType(GetRepo.Instance<ICountriesRepo>(), typeof(ICountriesRepo));
        [TestMethod] public void SetServiceTest() {
            var s = GetRepo.service;
            var x = new testClass();
            GetRepo.SetService(x);
            areEqual(x, GetRepo.service);
            GetRepo.service = s;
        }
    }
}
