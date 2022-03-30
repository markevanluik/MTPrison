using MTPrison.Data;

namespace MTPrison.Domain {
    public abstract class UniqueEntity {
        private const string defaultStr = "Undefined";
        private static DateTime defaultDate => DateTime.MinValue;
        private const int defaultInt = int.MinValue;
        protected static string getValue(string? v) => v ?? defaultStr;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        protected static int getValue(int? v) => v ?? defaultInt;
    }
    public abstract class UniqueEntity<TData> : UniqueEntity where TData : UniqueData, new() {
        private readonly TData data;
        public TData Data => data;
        public UniqueEntity() : this(new TData()) { }
        public UniqueEntity(TData d) => data = d;
        public string Id => getValue(Data?.Id);
    }
}
