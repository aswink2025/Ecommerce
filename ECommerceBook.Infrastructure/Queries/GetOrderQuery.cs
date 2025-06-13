using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Interface;
using ECommerceBook.Infrastructure.Data;

namespace ECommerceBook.Infrastructure.Queries
{
    public class GetOrderQuery : IGetOrderQuery
    {
        private readonly ECommerceDbContext dbContext;
        private readonly IMapper mapper;

        public GetOrderQuery(ECommerceDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IList<OrderDto> GetAllOrders()
        {
            return mapper.Map<IList<OrderDto>>(dbContext.Orders.ToList());
        }

        public OrderDto GetOrderById(int id)
        {
            return mapper.Map<OrderDto>(dbContext.Orders.FirstOrDefault(x => x.Id == id));
        }

    }
}
