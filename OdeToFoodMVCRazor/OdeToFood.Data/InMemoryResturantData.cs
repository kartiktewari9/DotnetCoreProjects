using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class InMemoryResturantData : IResturantData
    {
        List<Resturant> resturants;
        public InMemoryResturantData()
        {
            resturants = new List<Resturant>
            {
                new Resturant {Id=1,Name="Resturant 1",Location="Location 1", Cuisine=CuisineType.Indian},
                new Resturant {Id=2,Name="Resturant 2",Location="Location 2", Cuisine=CuisineType.Italian},
                new Resturant {Id=3,Name="Resturant 3",Location="Location 3", Cuisine=CuisineType.Maxican}
            };
        }
        public IEnumerable<Resturant> GetResturantsByName(string name=null)
        {
            return from r in resturants
                   where string.IsNullOrEmpty(name) || r.Name.Contains(name)
                   orderby r.Name
                   select r;
        }
        public Resturant GetById(int id)
        {
            return resturants.SingleOrDefault(r => r.Id == id);
        }
        public Resturant Add(Resturant newResturant)
        {
            newResturant.Id = resturants.Max(r => r.Id) + 1;
            resturants.Add(newResturant);
            return newResturant;
        }
        public Resturant Update(Resturant updatedResturant)
        {
            var resturnat = resturants.SingleOrDefault(x => x.Id == updatedResturant.Id);
            if (resturnat != null)
            {
                resturnat.Name = updatedResturant.Name;
                resturnat.Location = updatedResturant.Location;
                resturnat.Cuisine = updatedResturant.Cuisine;
            }
            return resturnat;
        }

        public int Commit()
        {
            return 0;
        }

        public Resturant Delete(int Id)
        {
            var resturant = resturants.FirstOrDefault(r => r.Id == Id);
            if (resturant != null)
            {
                resturants.Remove(resturant);
            }
            return resturant;
        }

        public int GetCountOfRestaurants()
        {
            return resturants.Count();
        }

        public async Task<int> SaveChangesAsync()
        {
            return 1;
        }
    }
}
