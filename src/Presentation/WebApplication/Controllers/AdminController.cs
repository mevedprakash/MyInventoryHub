using AutoMapper;
using DTO;
using Entity;
using Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> logger;
        private readonly IStoreService storeService;
        private readonly IMapper mapper;

        public AdminController(ILogger<AdminController> logger, IStoreService storeService, IMapper mapper
              )
        {
            this.logger = logger;
            this.storeService = storeService;
            this.mapper = mapper;
        }

        [HttpGet("store")]
        public async Task<ActionResult<StoreDto>> GetStore()
        {
            var store =mapper.Map<StoreDto>(storeService.GetStore(0));
            return Ok(store);
        }
        [HttpPost("store")]
        public async Task<ActionResult> SaveStore(StoreDto model)
        {
            var store = storeService.GetStore(0);
            store.ShortName = model.ShortName;
            store.Name = model.Name;
            store.Email = model.Email;
            store.AddressLine1 = model.AddressLine1;
            store.AddressLine2 = model.AddressLine2;
            store.City = model.City;
            store.State = model.State;
            store.Country = model.Country;
            store.PinCode = model.PinCode;
            store.IsTaxableInvoice = model.IsTaxableInvoice;
            store.AllowOrderDelete = model.AllowOrderDelete;
            store.AllowOrderEdit = model.AllowOrderEdit;
            storeService.UpdareStore(store);
            return Ok();
        }

    }
}
