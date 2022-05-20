using System.ComponentModel.DataAnnotations;

namespace MTPrison.Data {
    public abstract class UniqueData {
        public static string NewId => Guid.NewGuid().ToString();
        protected static byte[] empty => Array.Empty<byte>();
        public string Id { get; set; } = NewId[..10];
        [Timestamp] public byte[] Token { get; set; } = empty;
    }
}
