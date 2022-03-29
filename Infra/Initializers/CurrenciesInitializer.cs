using MTPrison.Data.Party;
using System.Globalization;

namespace MTPrison.Infra.Initializers {
    public sealed class CurrenciesInitializer : BaseInitializer<CurrencyData> {
        public CurrenciesInitializer(PrisonDb? db) : base(db, db?.Currencies) { }
        protected override IEnumerable<CurrencyData> getEntities {
            get {
                var l = new List<CurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var d = createCurrency(c.ISOCurrencySymbol, c.CurrencyEnglishName, c.CurrencyNativeName);
                    if (l.FirstOrDefault(x => x.Id == d.Id) is not null) continue;
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CurrencyData createCurrency(string code, string name, string nativeName)
            => new() { Id = code, Code = code, Name = name, NativeName = nativeName };
    }
}
