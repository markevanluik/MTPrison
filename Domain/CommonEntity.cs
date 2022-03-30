using MTPrison.Data;

namespace MTPrison.Domain {
    public abstract class CommonEntity<TData> : UniqueEntity<TData> where TData : CommonData, new() {
        public CommonEntity() : this(new TData()) { }
        public CommonEntity(TData d) : base(d) { }

        public string Code => getValue(Data?.Code);
        public string Name => getValue(Data?.Name);
        public string NativeName => getValue(Data?.NativeName);
    }
}
