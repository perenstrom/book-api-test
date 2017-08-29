using System.Collections.Generic;
using BookApi.Models;

namespace BookApi.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository()
        {
            _items = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Snabba Cash",
                    Intro = "Ett besök i Stockholms undre värld...",
                    Author = 1
                }
            };
        }
    }
}
