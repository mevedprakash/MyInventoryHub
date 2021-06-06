using AutoMapper;
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
using System.Threading.Tasks;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplyController : ControllerBase
    {
        private readonly ILogger<SupplyController> logger;
        private readonly ISupplyService supplyService;
        private readonly IMapper mapper;

        public SupplyController(ILogger<SupplyController> logger, ISupplyService supplyService, IMapper mapper
            )
        {
            this.logger = logger;
            this.supplyService = supplyService;
            this.mapper = mapper;
        }

        [HttpGet("productsupply")]
        public async Task<ActionResult<List<ProductSupply>>> GetProductSupplyList()
        {
            var products = await supplyService.GetProductSupply();
            return Ok(products);
        }
        [HttpPost("productsupply/add")]
        public async Task<ActionResult<ProductSupplyDto>> AddProductSupply(ProductSupplyViewModel model)
        {
            var productSupply = mapper.Map<ProductSupply>(model.ProductSupply);
            productSupply.Supplier = mapper.Map<Supplier>(model.Supplier);
            supplyService.SaveProductSupply(productSupply);
            return Ok();
        }

    }
}
