using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Interface;
using ECommerceBook.Domain.Entities;
using ECommerceBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace ECommerceBook.Application.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ECommerceDbContext context;

        public BaseRepository(ECommerceDbContext _context)
        {
            this.context = _context;
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
            return author;
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;

        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }

        public async Task<Publisher> CreatePublisherAsync(Publisher publisher)
        {
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();
            return publisher;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteAuthorAsync(int id)
        {
            return await context.Authors.Where(x => x.Id == id).ExecuteDeleteAsync();

        }

        public async Task<int> DeleteBookAsync(int id)
        {
            return await context.Books.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteOrderAsync(int id)
        {
            return await context.Orders.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeletePublisherAsync(int id)
        {
            return await context.Publishers.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            return await context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public Task<Book> GetBookByIdAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAuthorAsync(int id, Author author)
        {
            return await context.Authors.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter
                                                                                                    .SetProperty(x => x.Name, author.Name)
                                                                                                    .SetProperty(x => x.DOB, author.DOB)
                                                                                                    .SetProperty(x => x.Nationality, author.Nationality));
        }

        public async Task<int> UpdateBookAsync(int id, Book book)
        {
            return await context.Books.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter
                                                                                                  .SetProperty(x => x.Title, book.Title)
                                                                                                  .SetProperty(x => x.AuthorId, book.AuthorId)
                                                                                                  .SetProperty(x => x.Price, book.Price)
                                                                                                  .SetProperty(x => x.Description, book.Description));


        }

        public async Task<int> UpdateOrderAsync(int id, Order order)
        {
            return await context.Orders.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter
                                                                                                    .SetProperty(x => x.LoginId, order.LoginId)
                                                                                                    .SetProperty(x => x.Date, order.Date)
                                                                                                    .SetProperty(x => x.BookId, order.BookId)
                                                                                                    .SetProperty(x => x.Quantity, order.Quantity)
                                                                                                    .SetProperty(x => x.TotalPrice, order.TotalPrice));

        }

        public async Task<int> UpdatePublisherAsync(int id, Publisher publisher)
        {
            return await context.Publishers.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.Name, publisher.Name)
                                                                                                        .SetProperty(x => x.BookId, publisher.BookId)
                                                                                                        .SetProperty(x => x.Price, publisher.Price)
                                                                                                        .SetProperty(x => x.Stock, publisher.Stock)
                                                                                                .SetProperty(x => x.Payment, publisher.Payment));
        }
        public async Task<int> UpdateUserAsync(int id, User user)
        {
            return await context.Users.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.UserName, user.UserName)
                                                                                                        .SetProperty(x => x.Password, user.Password)
                                                                                                        .SetProperty(x => x.Email, user.Email)
                                                                                                        .SetProperty(x => x.FirstName, user.FirstName)
                                                                                                        .SetProperty(x => x.LastName, user.LastName)
                                                                                                        .SetProperty(x => x.Address, user.Address)
                                                                                                        .SetProperty(x => x.Pincode, user.Pincode)
                                                                                                        .SetProperty(x => x.PhoneNumber, user.PhoneNumber)
                                                                                                        .SetProperty(x => x.IsCustomer, user.IsCustomer));
        }
    }
}
