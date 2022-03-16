
namespace MTPrison.Data {
    public abstract class EntityData {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
