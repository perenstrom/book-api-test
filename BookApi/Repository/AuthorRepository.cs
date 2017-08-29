using System.Collections.Generic;
using BookApi.Models;

namespace BookApi.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository()
        {
            _items = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Jens Lapidus"
                }
            };
        }
    }
}
