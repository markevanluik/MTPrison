using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MTPrison.Aids;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrison.Pages.Extensions;
using MTPrison.Pages.Party;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MTPrison.Tests.Pages.Extensions {
    [TestClass] public class ShowTableHtmlTests : TypeTests {

        [TestMethod] public void ShowTableTest() {
            //var c = new Cell(GetRandom.Value<CellData>());
            //var l = new List<CellView> {
            //    new CellViewFactory().Create(c)
            //};
            //var mocker = new Mock<IHtmlHelper<CellsPage>>().Object;
            //var html = mocker.ShowTable(l);

            //var pi = html.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "Entries");
            //var obj = pi.GetValue(html, null);

            //isNotNull(obj);
            //string indexerName = ((DefaultMemberAttribute)obj.GetType()
            //    .GetCustomAttributes(typeof(DefaultMemberAttribute), true)[0]).MemberName;

            //var pi2 = obj.GetType().GetProperty(indexerName);
            //isNotNull(pi2);
            //var obj2 = pi2.GetValue(obj, new object[] { 0 });

            //var s = Convert.ToString(obj2) ?? string.Empty;
            //isTrue(s.Contains("<table class=\"table\">"));

            isInconclusive();
        }
    }
}
