using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(this CityManagementContext context)
        {
            //// first, clear the database.  This ensures we can always start 
            //// fresh with each demo.  Not advised for production environments, obviously :-)
            //context.Cities.RemoveRange(context.Cities);

            //context.SaveChanges();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Cities.Any())
            {
                return;   // DB has been seeded
            }

            // init seed data
            var cities = new List<City>()
            {
                new City()
                {
                    CityId = 1,
                    Name = "Gama",
                    Description = "The Villains World City.",
                    IsCapital = false,
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest() {
                            PointOfInterestId = 1,
                            Name = "Cine Itapuã",
                            Description = "Cinema da Cidade aponsetado",
                            CityId = 1
                        },
                        new PointOfInterest() {
                            PointOfInterestId = 2,
                            Name = "Igreja São Sebastião",
                            Description = "Paróquia da Cidade",
                            CityId = 1
                        },
                        new PointOfInterest() {
                            PointOfInterestId = 3,
                            Name = "Sayonara",
                            Description = "Referência Entrada da Cidade",
                            CityId = 1
                        }
                    }
                },
                new City()
                {
                    //CityId = 2,
                    Name = "Octogonal",
                    Description = "The Middle City.",
                    IsCapital = false,
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest() {
                            PointOfInterestId = 4,//1,
                            Name = "Terraço Shopping",
                            Description = "Shopping da Cidade",
                            CityId = 2
                        },
                        new PointOfInterest() {
                            PointOfInterestId = 5,//2,
                            Name = "HFA",
                            Description = "Hospital da Cidade",
                            CityId = 2
                        }
                    }
                }
             };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
