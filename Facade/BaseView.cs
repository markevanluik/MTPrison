using System.ComponentModel.DataAnnotations;

namespace MTPrison.Facade {
    public class BaseView {
        [Required] public string Id { get; set; }
    }
}
