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

namespace ECommerceBook.Application.Command._Author
{
    public class AuthorCommandHandler : IRequestHandler<AuthorCommand, AuthorDto>
    {
        private readonly IBaseRepository baseRepository;
        private readonly IMapper mapper;

        public AuthorCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<AuthorDto> Handle(AuthorCommand request, CancellationToken cancellationToken)
        {
            Author author;
            switch (request.Operation)
            {
                case Operation.Create:
                    author = new Author
                    {
                        Name = request.Author2Dto.Name,
                        DOB = request.Author2Dto.DOB,
                        Nationality = request.Author2Dto.Nationality
                    };
                    var createdAuthor = await baseRepository.CreateAuthorAsync(author);
                    return mapper.Map<AuthorDto>(createdAuthor);

                case Operation.Update:
                    var updateAuhtor = new Author
                    {
                        Id = request.AuthorDto.Id,
                        Name = request.AuthorDto.Name,
                        DOB = request.AuthorDto.DOB,
                        Nationality = request.AuthorDto.Nationality
                    };

                    await baseRepository.UpdateAuthorAsync(request.AuthorDto.Id, updateAuhtor); 
                    return mapper.Map<AuthorDto> (updateAuhtor);


                case Operation.Delete:  

                    await baseRepository.DeleteAuthorAsync(request.AuthorDto.Id);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
    }
}
