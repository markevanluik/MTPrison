using MTPrison.Data;
using MTPrison.Data.Party;
using System.Globalization;
using System.Reflection;

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
                    addUniqueDataToList(data, nameof(data.Id));
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
        private void addUniqueDataToList(dynamic data, string id) {
            bool locked = false;
            PropertyInfo[] prop = data.GetType().GetProperties();
            foreach (var line in l) {
                int count = 0, sum = 0;
                foreach (var pi in prop) {
                    if (pi.Name == id) continue;
                    string d = Convert.ToString(pi.GetValue(data)) ?? string.Empty;
                    string ln = Convert.ToString(pi.GetValue(line)) ?? string.Empty;
                    sum++;
                    if (d == ln) count++;
                }
                if (count == sum) { locked = true; break; } }
            if (!locked) l.Add(data);
        }
    }
}
