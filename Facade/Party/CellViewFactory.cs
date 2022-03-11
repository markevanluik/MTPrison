using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Facade.Party {
    public sealed class CellViewFactory {
        public Cell Create(CellView? v) => new(new CellData {
            Id = v.Id,
            CellNumber = v.CellNumber,
            Capacity = v.Capacity,
            Type = v.Type,
            Section = v.Section
        });

        public CellView Create(Cell? p) => new() {
            Id = p.Id,
            CellNumber = p.CellNumber,
            Capacity = p.Capacity,
            Type = p.Type,
            Section = p.Section
        };
    }
}
