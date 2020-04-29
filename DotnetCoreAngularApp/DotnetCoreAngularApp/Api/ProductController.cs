using DotnetCoreAngularApp.Models.ProductModels;
using DotnetCoreAngularApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreAngularApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            var result=await productService.GetAllProducts();
            return result.ToList();
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var result = await productService.GetProductById(id);
            return result;
        }
    }
}
