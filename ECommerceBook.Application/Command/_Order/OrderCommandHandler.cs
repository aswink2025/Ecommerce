using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Entities;
using ECommerceBook.Domain.Enum;
using ECommerceBook.Domain.Interface;
using MediatR;

namespace ECommerceBook.Application.Command._Order
{
    public class OrderCommandHandler : IRequestHandler<OrderCommand, OrderDto>
    {
        private readonly IBaseRepository baseRepository;
        private readonly IMapper mapper;
        public OrderCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<OrderDto> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            Order order;

            switch(request.Operation)
            {
                case Operation.Create:
                    var book = await baseRepository.GetBookByIdAsync(request.Order2Dto.BookId);
                    if (book == null)
                        throw new InvalidOperationException("Book not found.");

                    
                    if (book.Quantity < request.Order2Dto.Quantity)
                        throw new InvalidOperationException("Insufficient book quantity.");

                    
                    book.Quantity -= (int)request.Order2Dto.Quantity;

                    
                    await baseRepository.UpdateBookAsync(book.Id, book);

                   
                    var neworder = new Order
                    {
                        LoginId = request.Order2Dto.LoginId,
                        Date = request.Order2Dto.Date,
                        BookId = request.Order2Dto.BookId,
                        Quantity = request.Order2Dto.Quantity,
                        TotalPrice = request.Order2Dto.TotalPrice
                    };

                    var createdOrder = await baseRepository.CreateOrderAsync(neworder);
                    return mapper.Map<OrderDto>(createdOrder);

                case Operation.Update:
                    var updateOrder = new Order
                    {
                        Id = request.OrderDto.Id,
                        LoginId = request.OrderDto.LoginId,
                        Date = request.OrderDto.Date,
                        BookId = request.OrderDto.BookId,
                        Quantity = request.OrderDto.Quantity,
                        TotalPrice = request.OrderDto.TotalPrice
                    };

                    await baseRepository.UpdateOrderAsync(request.OrderDto.Id, updateOrder);
                    return mapper.Map<OrderDto>(updateOrder);

                case Operation.Delete:

                    await baseRepository.DeleteOrderAsync(request.OrderDto.Id);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
