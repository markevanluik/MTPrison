using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MTPrison.Facade.Party;
using MTPrison.Pages.Extensions;
using MTPrison.Pages.Party;
using System;
using System.Linq;
using System.Reflection;

namespace MTPrison.Tests.Pages.Extensions {
    [TestClass] public class MyTabHdrHtmlTests : TypeTests {
        [TestMethod] public void MyTabHdrTest() {
            //var c = new CountryView();
            //var mocker = new Mock<IHtmlHelper<CountriesPage>>().Object;
            //var html = mocker.MyTabHdr(nameof(c.Code));   // ViewData.Model object null issue

            //var pi = html.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "Entries");
            //var obj = pi.GetValue(html, null);

            //isNotNull(obj);
            //string indexerName = ((DefaultMemberAttribute)obj.GetType()
            //    .GetCustomAttributes(typeof(DefaultMemberAttribute), true)[0]).MemberName;

            //var pi2 = obj.GetType().GetProperty(indexerName);
            //isNotNull(pi2);
            //var obj2 = pi2.GetValue(obj, new object[] { 7 });

            //var s = Convert.ToString(obj2) ?? string.Empty;
            //isTrue(s.Contains($">{nameof(c.Code)}</a>"));

            isInconclusive();
        }
    }
}
