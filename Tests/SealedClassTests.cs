using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTPrison.Tests {
    public abstract class SealedClassTests<TClass> : BaseTests where TClass : class, new () {
        protected override object createObject() => new TClass();
        [TestMethod] public void IsSealedTest() => isTrue(obj?.GetType()?.IsSealed?? false);

    }
}
