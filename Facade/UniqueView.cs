using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade {
    public abstract class UniqueView {
        [Required] public string Id { get; set; } = Guid.NewGuid().ToString()[..10];
        [Required] public byte[] Token { get; set; } = Array.Empty<byte>();
    }
}
