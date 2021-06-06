using AutoMapper;
using DTO;
using DTO.CustomModel;
using Entity;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity.Enum;

namespace Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;

        private IUnitOfWork unitOfWork { get; }

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await unitOfWork.OrderRepository.GetAsync();
        }

        public async Task<Order> SaveOrder(OrderDto model)
        {
            if (model.Id == 0)
            {
                var order = mapper.Map<Order>(model);
                if (order.Payment != null)
                    order.Payment.Status = (int)PaymentStatus.Completed;

                foreach(var item in order.OrderItems)
                {
                    var product=unitOfWork.ProductRepository.GetById(item.ProductId);
                    product.AvaiableQuantity -= item.Quantity;
                }
                unitOfWork.SaveChanges();
                return order;
            }
            else
            {
                var order = await GetOrder(model.Id);
                if (model.Customer != null)
                {
                    if (order.Customer == null)
                    {
                        order.Customer = mapper.Map<Customer>(model.Customer);
                    }
                    else
                    {
                        order.Customer.Name = model.Customer.Name;
                        order.Customer.MobileNo = model.Customer.MobileNo;
                    }
                }
                if (model.Payment != null)
                {
                    if (order.Payment == null)
                    {
                        order.Payment = mapper.Map<Payment>(model.Payment);
                        order.Payment.Status = (int)PaymentStatus.Completed;
                    }
                    else
                    {
                        order.Payment.Type = model.Payment.Type;
                        order.Payment.Status = (int)PaymentStatus.Completed;
                    }
                }
                order.SubAmount = model.SubAmount;
                order.Discount = model.Discount;
                order.Tax = model.Tax;
                order.NetAmount = model.NetAmount;
                foreach (var item in order.OrderItems)
                {
                        var product = unitOfWork.ProductRepository.GetById(item.ProductId);
                        product.AvaiableQuantity += item.Quantity;
                }
                order.OrderItems = mapper.Map<List<OrderItem>>(model.OrderItems);
                foreach (var item in order.OrderItems)
                {
                    var product = unitOfWork.ProductRepository.GetById(item.ProductId);
                    product.AvaiableQuantity -= item.Quantity;
                }
                unitOfWork.SaveChanges();
                return order;
            }
        } 
        public async Task<PagedList<OrderDto>> GetOrders(                              
                               string search = null,
                               int page = 1,
                               int pageSize = int.MaxValue
            )
        {

            var query = unitOfWork.OrderRepository.TableNoTrack;
            if (!string.IsNullOrEmpty(search))
               query = query.Where(x => x.Customer.Name.Contains(search) || x.OrderItems.Any(x => x.Product.Name.Contains(search)));
            var query1= query.Include(x => x.Customer).Include(x => x.OrderItems).Include(x=>x.Payment);
            var query2 = query1.OrderByDescending(x => x.CreatedAt);
            var list = await new PagedList<Order>().PopulateAsync(query2, page, pageSize);
            return mapper.Map<PagedList<OrderDto>>(list);
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await unitOfWork.OrderRepository.Table.Include(x => x.Customer).Include(x => x.OrderItems).Include(x=>x.Payment).Where(x => x.Id == orderId).FirstOrDefaultAsync();
            
        }
    }
}
