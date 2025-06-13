using System.ComponentModel;
using ECommerceBook.Application.Command._Book;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Entities;
using ECommerceBook.Domain.Enum;
using ECommerceBook.Domain.Interface;
using ECommerceBook.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace ECommerceBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ApiController
    {
        private readonly IGetBookQuery getBookQuery;

        public BookController(IGetBookQuery getBookQuery)
        {
            this.getBookQuery = getBookQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var book = getBookQuery.GetAllBooks();
            return Ok(book);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var book = getBookQuery.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Book2Dto book2Dto)
        {

            var command = new BookCommand(Operation.Create, book2Dto: book2Dto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookDto bookDto)
        {
            if (id == bookDto.Id)
            {
                var command = new BookCommand(Operation.Update, bookDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = new BookDto { Id = id };
            var command = new BookCommand(Operation.Delete, book);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost("bulk-upload")]
        public async Task<IActionResult> BulkUploadBooks(IFormFile file, [FromServices] ECommerceDbContext context)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please upload a valid Excel file.");

            var books = new List<Book>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    var worksheet = package.Workbook.Worksheets[0]; 
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        books.Add(new Book
                        {
                            Title = worksheet.Cells[row, 1].Text,
                            AuthorId = int.Parse(worksheet.Cells[row, 2].Text),
                            Price = long.Parse(worksheet.Cells[row, 3].Text),
                            Description = worksheet.Cells[row, 4].Text,
                            Quantity = int.Parse(worksheet.Cells[row, 5].Text)
                        });
                    }
                }
            }

            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();

            return Ok(new { Count = books.Count, Message = "Books uploaded successfully." });
        }
    }
}
