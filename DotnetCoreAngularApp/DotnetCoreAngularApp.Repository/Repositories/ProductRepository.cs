using DotnetCoreAngularApp.Data;
using DotnetCoreAngularApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreAngularApp.Repository.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly DotnetCoreAngularAppDbContext _dbContext;

        public ProductRepository(DotnetCoreAngularAppDbContext dotnetCoreAngularAppDbContext)
        {
            this._dbContext = dotnetCoreAngularAppDbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _dbContext.Product.ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
