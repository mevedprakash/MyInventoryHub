using AutoMapper;
using DTO;
using DTO.CustomModel;
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
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> logger;
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService, IMapper mapper
            )
        {
            this.logger = logger;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        [HttpGet("orders")]
        public async Task<ActionResult<PagedList<OrderDto>>> GetOrderList(int page = 1, int pageSize = 10,string search=null)
        {
            var orders = await orderService.GetOrders(search,page,pageSize);
            return Ok(orders);
        }
        [HttpPost("order/add")]
        public async Task<ActionResult<OrderDto>> AddOrder(OrderDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(model.OrderItems==null || model.OrderItems.Count == 0)
            {
                return BadRequest("Add at least one item");
            }
            await orderService.SaveOrder(model);
            return Ok();
        }

        [HttpGet("orderdetail/{orderId}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
        {         
            var order=await orderService.GetOrder(orderId);
            return Ok(mapper.Map<OrderDto>(order));
        }

    }
}
