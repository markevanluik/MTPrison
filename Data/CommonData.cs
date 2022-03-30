
namespace MTPrison.Data {
    public abstract class CommonData : UniqueData {
        public string Code { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? NativeName { get; set; }
    }
}
