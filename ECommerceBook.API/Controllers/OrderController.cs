using System.Reflection.PortableExecutable;
using System.Text;
using ECommerceBook.Application.Command._Order;
using ECommerceBook.Domain.Dto;
using ECommerceBook.Domain.Enum;
using ECommerceBook.Domain.Interface;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace ECommerceBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiController
    {
        private readonly IGetOrderQuery getOrderQuery;

        public OrderController(IGetOrderQuery getOrderQuery)
        {
            this.getOrderQuery = getOrderQuery;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var order = getOrderQuery.GetAllOrders();
            return Ok(order);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var order = getOrderQuery.GetOrderById(id);
            return Ok(order);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Order2Dto order2Dto)
        {
            var command = new OrderCommand(Operation.Create, order2Dto: order2Dto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDto orderDto)
        {
            if (id == orderDto.Id)
            {
                var command = new OrderCommand(Operation.Update, orderDto);
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            return BadRequest("You are a fool");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = new OrderDto { Id = id };
            var command = new OrderCommand(Operation.Delete, book);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPost("upload-invoice")]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Read the uploaded PDF file into a memory stream
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);


            var reader = new PdfReader(ms);
            var pdfDoc = new PdfDocument(reader);

            var extractedText = new StringBuilder();
            for (int pageIndex = 1; pageIndex <= pdfDoc.GetNumberOfPages(); pageIndex++)
            {
                var page = pdfDoc.GetPage(pageIndex);
                var strategy = new SimpleTextExtractionStrategy();
                var pageContent = PdfTextExtractor.GetTextFromPage(page, strategy);
                extractedText.AppendLine(pageContent);
            }

            return Ok(extractedText.ToString());
        }
    }
}
