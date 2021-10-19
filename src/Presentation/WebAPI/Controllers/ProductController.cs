using AutoMapper;
using Business.Services;
using DTO;
using Entity;
using Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     [Authorize]   
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly IStorageService storageService;

        public ProductController(ILogger<ProductController> logger,
            IProductService productService, 
            IMapper mapper,
            IStorageService storageService
            )
        {
            this.logger = logger;
            this.productService = productService;
            this.mapper = mapper;
            this.storageService = storageService;
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var user = this.GetAppUser();
            var products = await productService.GetProducts();
            return Ok(products);
        }
        [HttpPost("product/add")]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model.Id == 0)
            {
                var product = mapper.Map<Product>(model);
                productService.SaveProduct(product);
            }
            else
            {
                var product =await productService.GetProduct(model.Id);
                product.Name = model.Name;
                product.Detail = model.Detail;
                product.BrandId = model.BrandId;
                product.SKU = model.SKU;
                product.PurchasePrice = model.PurchasePrice;
                product.SalePrice = model.SalePrice;
                product.AvaiableQuantity = model.AvaiableQuantity;
                product.MinQuantityLimit = model.MinQuantityLimit;
                product.UnitId = model.UnitId;
                productService.SaveProduct(product);
            }
            return Ok();
        }

        [HttpGet("lowstock")]
        public async Task<ActionResult<List<Product>>> GetLowStockProducts()
        {
            var products = await productService.GetLowStokProducts();
            return Ok(products);
        }


        [HttpGet("bestselling")]
        public async Task<ActionResult<List<Product>>> GetBestSellingProducts()
        {
            var products = await productService.GetBestSellingProducts();
            return Ok(products);
        }

        [HttpPost("AddProductPicture")]
        [AllowAnonymous]
        public async Task<ActionResult> UploadProductPicture(IFormFile file, [FromForm] int productId, [FromForm] int displayOrder)
        {
            if (file == null)
            {
                return BadRequest();
            }

            var picture = await storageService.SaveImage(file);
            var productPicture = new ProductPicture()
            {
                DisplayOrder = displayOrder,
                PictureId = picture.Id,
                ProductId = productId
            };
            productService.AddProductPictures(productPicture);
            //when returning JSON the mime-type must be set to text/plain
            //otherwise some browsers will pop-up a "Save As" dialog.
            return Ok();
        }
    }
}
