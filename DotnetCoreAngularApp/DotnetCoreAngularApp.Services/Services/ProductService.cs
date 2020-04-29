using DotnetCoreAngularApp.Models.ProductModels;
using DotnetCoreAngularApp.Repository.Interfaces;
using DotnetCoreAngularApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCoreAngularApp.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var dbProducts = await productRepository.GetAllProducts();
            var result = new List<ProductModel>();// use automapper for this
            foreach (var product in dbProducts)
            {
                result.Add(new ProductModel
                {
                    description = product.Description,
                    imageUrl = product.ImageUrl,
                    price = product.Price,
                    productCode = product.ProductCode,
                    productId = product.Id,
                    productName = product.ProductName,
                    releaseDate = product.ReleaseDate,
                    starRating = product.StarRating
                });
            }
            return result;
        }

        public async Task<ProductModel> GetProductById(int Id)
        {
            var product = await productRepository.GetProductById(Id);
            var result = new ProductModel();
            if (product != null)
            {
                result = new ProductModel //use automapper for this
                {
                    description = product.Description,
                    imageUrl = product.ImageUrl,
                    price = product.Price,
                    productCode = product.ProductCode,
                    productId = product.Id,
                    productName = product.ProductName,
                    releaseDate = product.ReleaseDate,
                    starRating = product.StarRating
                };
            }
            return result;
        }
    }
}
