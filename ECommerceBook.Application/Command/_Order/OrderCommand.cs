using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Enum;
using MediatR;

namespace ECommerceBook.Application.Command._Order
{
    public class OrderCommand : IRequest<OrderDto>
    {
        public OrderCommand(Operation operation, OrderDto orderDto = null, Order2Dto order2Dto = null)
        {
            Operation = operation;
            OrderDto = orderDto;
            Order2Dto = order2Dto;
        }

        public Operation Operation { get; set; }
        public OrderDto? OrderDto { get; set; } 
        public Order2Dto? Order2Dto { get; set; }     
    }
}
