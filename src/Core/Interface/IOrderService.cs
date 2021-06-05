using DTO;
using DTO.CustomModel;
using Entity;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IOrderService
    {        
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(int orderId);
        Task<Order> SaveOrder(OrderDto order);
        Task<PagedList<OrderDto>> GetOrders(
                               string search = null,
                               int page = 1,
                               int pageSize = int.MaxValue
            );
    }
}
