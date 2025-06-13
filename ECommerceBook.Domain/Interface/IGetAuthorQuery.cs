using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBook.Domain.Dto;

namespace ECommerceBook.Domain.Interface
{
    public interface IGetAuthorQuery
    {
        IList<AuthorDto> GetAllAuthors();

        AuthorDto GetAuthorById(int id);
    }
}
