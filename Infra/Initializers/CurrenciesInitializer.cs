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
                    var id = c.ISOCurrencySymbol;
                    if (!isCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                    var data = createCurrency(id, c.CurrencyEnglishName, c.CurrencyNativeName);
                    l.Add(data);
                }
                return l;
            }
        }
        internal static CurrencyData createCurrency(string code, string name, string nativeName) => new() {
            Id = code, Code = code, Name = name, NativeName = nativeName
        };
    }

}
