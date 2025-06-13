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

namespace ECommerceBook.Application.Command._Book
{
    public class BookCommandHandler : IRequestHandler<BookCommand, BookDto>
    {
        private readonly IBaseRepository baseRepository;
        private readonly IMapper mapper;
        public BookCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<BookDto> Handle(BookCommand request, CancellationToken cancellationToken)
        {
            Book book;

            switch(request.Operation)
            {
                case Operation.Create:
                    book = new Book
                    {
                        Title = request.Book2Dto.Title,
                        AuthorId = request.Book2Dto.AuthorId,
                        Price = request.Book2Dto.Price,
                        Description = request.Book2Dto.Description,
                        Quantity = request.Book2Dto.Quantity,
                    };

                    var createdBook = await baseRepository.CreateBookAsync(book);
                    return mapper.Map<BookDto>(createdBook);

                case Operation.Update:
                    var updateBook = new Book
                    {
                        Id = request.BookDto.Id,
                        Title = request.BookDto.Title,
                        AuthorId = request.BookDto.AuthorId,
                        Price = request.BookDto.Price,
                        Description = request.BookDto.Description,
                        Quantity = request.BookDto.Quantity

                    };

                    await baseRepository.UpdateBookAsync(request.BookDto.Id, updateBook);
                    return mapper.Map<BookDto>(updateBook);

                case Operation.Delete:

                    await baseRepository.DeleteAuthorAsync(request.BookDto.Id);

                    return null;
                    
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
