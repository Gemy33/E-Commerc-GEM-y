using Microsoft.AspNetCore.Mvc;
using RouteDev.Ecommerc.Presentation.Controllers.Base;
using RouteDev.Ecommerc.Service.Apstraction.Common;
using RouteDev.Ecommerc.Service.Apstraction.DTO_s.Product;
using RouteDev.Ecommerc.Service.Apstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteDev.Ecommerc.Presentation.Controllers.Product
{
    public class ProductController : BaseController
    {
        private readonly IserviceManager _iserviceManager;

        public ProductController(IserviceManager iserviceManager)
        {
            this._iserviceManager = iserviceManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts([FromQuery]QueryParmsSpecs parmsSpecs)
        {
            var products = await _iserviceManager.ProductService.GetAlLProductAsync(parmsSpecs);
            var counts = await _iserviceManager.ProductService.CountAsync(parmsSpecs);
            var resultToReturn = new PaginatedResult<ProductDto>()
            {
                PageIndex = parmsSpecs.PageIndex,
                PageSize = products.Count(),
                Data = products.ToList(),
                Count = counts
            };
            if (products is not null)
            {
            return Ok(resultToReturn);
                
            }
            return  Content("Not product match theis query");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            
            var product = await _iserviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
        [HttpGet]
        [Route("brands")]
        public async Task<ActionResult<IEnumerable<string>>> GetProductBrands()
        {
            var brands = await _iserviceManager.ProductService.GetAlLBrandAsync();
            return Ok(brands);

        }
        [HttpGet]
        [Route("types")]
        public async Task<ActionResult<IEnumerable<string>>> GetProductTypes()
        {
            var types = await _iserviceManager.ProductService.GetAlLTypeAsync();
            return Ok(types);
        }
    }
    }
