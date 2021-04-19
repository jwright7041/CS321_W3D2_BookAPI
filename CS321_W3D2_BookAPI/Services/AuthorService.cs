using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D2_BookAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _bookContext;
        public AuthorService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Author Add(Author author)
        {
            _bookContext.Authors.Add(author);
            _bookContext.SaveChanges();
            return author;
        }

        public Author Get(int id)
        {
            return _bookContext.Authors.Include(a => a.books).FirstOrDefault(a => a.id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _bookContext.Authors.Include(a => a.books).ToList();
        }

        public void Remove(Author author)
        {
            _bookContext.Remove(author);
            _bookContext.SaveChanges();
        }

        public Author Update(Author author)
        {
            var currentAuthor = Get(author.id);

            if (currentAuthor == null)
                return null;

            _bookContext.Entry(currentAuthor)
                .CurrentValues
                .SetValues(author);

            _bookContext.Update(currentAuthor);
            _bookContext.SaveChanges();

            return currentAuthor;
        }
    }
}
