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

namespace ECommerceBook.Application.Command._Publisher
{
    public class PublisherCommandHandler : IRequestHandler<PublisherCommand, PublisherDto>
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository baseRepository;

        public PublisherCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<PublisherDto> Handle(PublisherCommand request, CancellationToken cancellationToken)
        {
            Publisher publisher;

            switch (request.Operation)
            {
                case Operation.Create:
                    publisher = new Publisher
                    {
                        Name = request.Publisher2Dto.Name,
                        BookId = request.Publisher2Dto.BookId,
                        Price = request.Publisher2Dto.Price,
                        Stock = request.Publisher2Dto.Stock,
                        Payment = request.Publisher2Dto.Payment,
                    };

                    var createdPub = await baseRepository.CreatePublisherAsync(publisher);

                    return mapper.Map<PublisherDto>(createdPub);

                case Operation.Update:
                    var updatePub = new Publisher
                    {
                        Id = request.PublisherDto.Id,
                        Name = request.PublisherDto.Name,
                        BookId = request.PublisherDto.BookId,
                        Price = request.PublisherDto.Price,
                        Stock = request.PublisherDto.Stock,
                        Payment = request.PublisherDto.Payment
                    };

                    await baseRepository.UpdatePublisherAsync(request.PublisherDto.Id, updatePub);

                    return mapper.Map<PublisherDto>(updatePub);

                case Operation.Delete:
                    await baseRepository.DeleteAuthorAsync(request.PublisherDto.Id);

                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }

        }
    }
}
