using MTPrison.Data.Party;
using MTPrison.Domain.Party;

namespace MTPrison.Facade.Party
{
    public class PrisonerViewFactory
    {
        public Prisoner Create(PrisonerView v) => new(new PrisonerData 
        {
            Id = v.Id,
            FirstName = v.FirstName,
            LastName = v.LastName,
            Offense = v.Offense,
            DoB = v.DoB,
            DateOfImprisonment = v.DateOfImprisonment,
            DateOfRelease = v.DateOfRelease
        });
        
        public PrisonerView Create(Prisoner o) => new()
        {
            Id = o.Id,
            FirstName = o.FirstName,
            LastName = o.LastName,
            Offense = o.Offense,
            DoB = o.DoB,
            DateOfImprisonment = o.DateOfImprisonment,
            DateOfRelease = o.DateOfRelease,
            FullName = o.ToString()
        };
    }
}
