using MTPrison.Data;
using MTPrison.Data.Party;
using MTPrison.Domain;
using System.Globalization;

namespace MTPrison.Infra.Initializers {
    public sealed class CountriesInitializer : BaseInitializer<CountryData> {
        public CountriesInitializer(PrisonDb? db) : base(db, db?.Countries) { }
        protected override IEnumerable<CountryData> getEntities {
            get {
                var l = new List<CountryData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var id = c.ThreeLetterISORegionName;
                    if (!isCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                    var d = createCountry(id, c.EnglishName, c.NativeName);
                    l.Add(d);
                }
                return l;
            }
        }
        internal static CountryData createCountry(string code, string name, string nativeName) 
            => new () { Id = code ?? UniqueData.NewId, Code = code ?? UniqueEntity.DefaultStr, Name = name, NativeName = nativeName };
    }
}
