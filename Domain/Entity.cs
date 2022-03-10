using MTPrison.Data;

namespace MTPrison.Domain {
    public abstract class Entity {
        protected const string defaultStr = "Undefined";
        protected DateTime defaultDate => DateTime.MinValue;
        protected const int defaultInt = int.MinValue;
    }
    public abstract class Entity<TData> : Entity where TData : EntityData, new() {
        private readonly TData data;
        public TData Data => data;
        public Entity() : this(new TData()) { }
        public Entity(TData d) => data = d;
        public string Id => Data?.Id ?? defaultStr;
    }
}
