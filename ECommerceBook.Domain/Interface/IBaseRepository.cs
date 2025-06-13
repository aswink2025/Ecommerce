using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Entities;

namespace ECommerceBook.Domain.Interface
{
    public interface IBaseRepository
    {
        Task<Author> CreateAuthorAsync(Author author);
        Task<int> UpdateAuthorAsync(int id, Author author);
        Task<int> DeleteAuthorAsync(int id);

        Task<Book> CreateBookAsync(Book book);
        Task<int> UpdateBookAsync(int id, Book book);
        Task<int> DeleteBookAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
        Task<int> UpdateOrderAsync(int id, Order order);
        Task<int> DeleteOrderAsync(int id);

        Task<Publisher> CreatePublisherAsync(Publisher publisher);
        Task<int> UpdatePublisherAsync(int id, Publisher publisher);
        Task<int> DeletePublisherAsync(int id);

        Task<User> CreateUserAsync(User user);
        Task<int> UpdateUserAsync(int id, User user);
        Task<int> DeleteUserAsync(int id);
        Task<Book> GetBookByIdAsync(int bookId);
    }
}
