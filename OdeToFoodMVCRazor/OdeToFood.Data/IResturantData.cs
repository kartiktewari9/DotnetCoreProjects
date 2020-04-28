using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetResturantsByName(string name);
        Resturant GetById(int id);
        Resturant Add(Resturant newResturant);
        Resturant Update(Resturant updatedResturant);
        Resturant Delete(int Id);
        int GetCountOfRestaurants();
        int Commit();
        Task<int> SaveChangesAsync();
    }
}
