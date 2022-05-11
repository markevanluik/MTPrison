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
                    var obj = createCountry(coId, c.ISOCurrencySymbol, c.CurrencySymbol, c.EnglishName, c.CurrencyEnglishName, c.CurrencyNativeName);
                    addUniqueObjToList(obj, nameof(obj.Id), nameof(obj.Token));
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
        internal void addUniqueObjToList(dynamic obj, params string[] exlude) {
            bool locked = false;
            PropertyInfo[] prop = obj.GetType().GetProperties();
            foreach (var line in l) {
                int match = 0, len = prop.Length - exlude.Length;
                foreach (var pi in prop) {
                    if (exlude.Contains(pi.Name)) continue;
                    string o = Convert.ToString(pi.GetValue(obj)) ?? string.Empty;
                    string ln = Convert.ToString(pi.GetValue(line)) ?? string.Empty;
                    if (o == ln) match++;
                }
                if (match == len) { locked = true; break; }
            }
            if (!locked) l.Add(obj);
        }
    }
}
