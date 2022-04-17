using MTPrison.Data;
using MTPrison.Data.Party;
using System.Globalization;

namespace MTPrison.Infra.Initializers {
    public sealed class CountryCurrenciesInitializer : BaseInitializer<CountryCurrencyData> {
        public CountryCurrenciesInitializer(PrisonDb? db) : base(db, db?.CountryCurrencies) { }
        private readonly List<CountryCurrencyData> l = new();
        protected override IEnumerable<CountryCurrencyData> getEntities {
            get {
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var coId = c.ThreeLetterISORegionName;
                    if (!isCorrectIsoCode(coId)) continue;
                    if (l.FirstOrDefault(x => x.Id == coId) is not null) continue;
                    var data = createCountry(coId, c.ISOCurrencySymbol, c.CurrencySymbol, c.EnglishName, c.CurrencyEnglishName, c.CurrencyNativeName);
                    addUniqueDataToList(data);
                }
                return l;
            }
        }
        internal static CountryCurrencyData createCountry(string coId, string cuId, string symbol, string coName, string cuName, string nativeName) => new() {
            Id = $"{coId}-{cuId}-{UniqueData.NewId[..5]}",
            CountryId = coId,
            CurrencyId = cuId,
            Code = cuId,
            Name = symbol,
            CountryName = coName,
            CurrencyName = cuName,
            NativeName = nativeName
        };
        private void addUniqueDataToList(CountryCurrencyData d) {
            bool locked = false;
            foreach (var i in l) {
                if (i.CountryId == d.CountryId &&
                    i.CurrencyId == d.CurrencyId &&
                    i.Code == d.Code &&
                    i.Name == d.Name &&
                    i.CountryName == d.CountryName &&
                    i.CurrencyName == d.CurrencyName &&
                    i.NativeName == d.NativeName) locked = true;
            }
            if (!locked) l.Add(d);
        }
    }
}
