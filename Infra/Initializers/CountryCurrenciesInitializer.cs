using MTPrison.Data.Party;
using System.Globalization;

namespace MTPrison.Infra.Initializers {
    public sealed class CountryCurrenciesInitializer : BaseInitializer<CountryCurrencyData> {
        public CountryCurrenciesInitializer(PrisonDb? db) : base(db, db?.CountryCurrencies) { }

        protected override IEnumerable<CountryCurrencyData> getEntities {
            get {
                var l = new List<CountryCurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var coId = c.ThreeLetterISORegionName;
                    if (!isCorrectIsoCode(coId)) continue;
                    if (l.FirstOrDefault(x => x.Id == coId) is not null) continue;
                    var data = createCountry(coId, c.ISOCurrencySymbol, c.CurrencySymbol, c.EnglishName, c.CurrencyEnglishName, c.CurrencyNativeName);
                    l.Add(data);
                }
                return l;
            }
        }
        internal static CountryCurrencyData createCountry(string coId, string cuId, string symbol, string coName, string cuName, string nativeName) => new() {
            Id = coId,
            CountryId = coId,
            CurrencyId = cuId,
            Code = cuId,
            Name = symbol,
            CountryName = coName,
            CurrencyName = cuName,
            NativeName = nativeName
        };
    }
}
