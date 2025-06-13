using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Enum;
using MediatR;

namespace ECommerceBook.Application.Command._Publisher
{
    public class PublisherCommand : IRequest<PublisherDto>
    {
        public PublisherCommand(Operation operation, PublisherDto publisherDto = null, Publisher2Dto publisher2Dto = null)
        {
            Operation = operation;
            PublisherDto = publisherDto;
            Publisher2Dto = publisher2Dto;
        }

        public Operation Operation { get; set; }
        public PublisherDto? PublisherDto { get; set; }

        public Publisher2Dto? Publisher2Dto { get; set; }
    }
}
