using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IOdeToFoodDbContext
    {
        DbSet<Resturant> Resturants { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
    public class OdeToFoodDbContext: DbContext, IOdeToFoodDbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options):base(options)
        {

        }
        public DbSet<Resturant> Resturants { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        int IOdeToFoodDbContext.SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
