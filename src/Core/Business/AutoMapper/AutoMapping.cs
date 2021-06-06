using AutoMapper;
using DTO;
using DTO.CustomModel;
using Entity;

namespace Business.AutoMapper
{ 
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap(); 
            CreateMap<ProductSupply, ProductSupplyDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();

        }


    }
}
