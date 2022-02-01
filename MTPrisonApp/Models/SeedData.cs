using Microsoft.EntityFrameworkCore;
using MTPrisonApp.Data;

namespace MTPrisonApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Prisoner == null || context.PrisonCell == null)
                {
                    throw new ArgumentNullException("Null Context");
                }

                if (context.Prisoner.Any() || context.PrisonCell.Any())
                {
                    return;
                }

                context.Prisoner.AddRange(
                    new Prisoner
                    {
                        Id = "12345",
                        FirstName = "Bob",
                        LastName = "Smith",
                        Offense = "Insurance Fraud",
                        DoB = DateTime.Parse("1989-2-12"),
                        DateOfImprisonment = DateTime.Parse("1999-1-1"),
                        DateOfRelease = DateTime.Parse("2002-2-2")
                    },

                    new Prisoner
                    {
                        Id = "22345",
                        FirstName = "John",
                        LastName = "Doe",
                        Offense = "Burglary",
                        DoB = DateTime.Parse("1989-2-12"),
                        DateOfImprisonment = DateTime.Parse("1999-1-1"),
                        DateOfRelease = DateTime.Parse("2002-2-2")
                    },

                    new Prisoner
                    {
                        Id = "32345",
                        FirstName = "Jane",
                        LastName = "Doe",
                        Offense = "Manslaughter",
                        DoB = DateTime.Parse("1989-2-12"),
                        DateOfImprisonment = DateTime.Parse("1999-1-1"),
                        DateOfRelease = DateTime.Parse("2002-2-2")
                    },

                    new Prisoner
                    {
                        Id = "42345",
                        FirstName = "Foo",
                        LastName = "Bar",
                        Offense = "GTA",
                        DoB = DateTime.Parse("1989-2-12"),
                        DateOfImprisonment = DateTime.Parse("1999-1-1"),
                        DateOfRelease = DateTime.Parse("2002-2-2")
                    }
                );

                context.PrisonCell.AddRange(
                    new PrisonCell
                    {
                        Id = "52345",
                        CellNumber = 1,
                        Capacity = 3,
                        Type = "Deluxe",
                        Section = "C"
                    },

                    new PrisonCell
                    {
                        Id = "62345",
                        CellNumber = 21,
                        Capacity = 2,
                        Type = "Duo",
                        Section = "B"
                    },

                    new PrisonCell
                    {
                        Id = "72345",
                        CellNumber = 31,
                        Capacity = 1,
                        Type = "Solitary",
                        Section = "A"
                    },

                    new PrisonCell
                    {
                        Id = "82345",
                        CellNumber = 32,
                        Capacity = 1,
                        Type = "Solitary",
                        Section = "A"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
