using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class SqlResturantData : IResturantData
    {
        private readonly IOdeToFoodDbContext dbContext;

        public SqlResturantData(IOdeToFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Resturant Add(Resturant newResturant)
        {
            dbContext.Resturants.Add(newResturant);
            return newResturant;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Resturant Delete(int Id)
        {
            var resturnat = GetById(Id);
            if (resturnat != null)
            {
                dbContext.Resturants.Remove(resturnat);
            }
            return resturnat;
        }

        public Resturant GetById(int id)
        {
            return dbContext.Resturants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return dbContext.Resturants.Count();
        }

        public IEnumerable<Resturant> GetResturantsByName(string name)
        {
            return dbContext.Resturants.Where(r => string.IsNullOrEmpty(name) || r.Name.Contains(name)).OrderBy(r => r.Name);
        }

        public Task<int> SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        public Resturant Update(Resturant updatedResturant)
        {
            var entity = dbContext.Resturants.Attach(updatedResturant);
            entity.State = EntityState.Modified;
            return updatedResturant;
        }
    }
}
