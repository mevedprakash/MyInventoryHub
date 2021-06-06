using AutoMapper;
using DTO;
using Entity;
using Entity.Enum;
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
    public class CommonController : ControllerBase
    {
        private readonly ILogger<CommonController> _logger;
        private readonly IBrandService brandService;
        private readonly IMapper mapper;
        private readonly ICommonService commonService;

        public CommonController(ILogger<CommonController> logger,
            IBrandService brandService, IMapper mapper,
            ICommonService commonService
            )
        {
            _logger = logger;
            this.brandService = brandService;
            this.mapper = mapper;
            this.commonService = commonService;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<Brand>>> GetBrands()
        {
            var brands =await brandService.GetBrands();
            return Ok(brands);
        }

        [HttpPost("brand/add")]
        public async Task<ActionResult<List<BrandDto>>> AddBrand(BrandDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model.Id == 0)
            {
                var brand = mapper.Map<Brand>(model);
                var brands = brandService.SaveBrand(brand);
                return Ok(brands);
            }
            else
            {
                var brand =await brandService.GetBrand(model.Id);
                brand.Name = model.Name;
                brand.Detail = model.Detail;
                brand.IsActive = model.IsActive;
                var brands = brandService.SaveBrand(brand);
                return Ok(brands);
            }
          
        }

        [HttpGet("units")]
        public async Task<ActionResult<List<Unit>>> GetUnits()
        {
            var units = await commonService.GetUnits();
            return Ok(units);
        }

        [HttpGet("paymenttypes")]
        public ActionResult<List<SelectListItem>> GetPaymentTyps()
        {
            var paymentTypes= (Enum.GetValues(typeof(PaymentType)).Cast<PaymentType>().Select(
               enu => new SelectListItem() { Text = enu.ToString(), Value = ((int)enu) })).ToList();
            return Ok(paymentTypes);
        }
    }
}
