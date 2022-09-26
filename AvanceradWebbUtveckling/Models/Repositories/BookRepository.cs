using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public class BookRepository : IRepository<Book>
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }




        public Book GetSingle(int id)
        {
            return _appDbContext.Books.FirstOrDefault(c => c.BookID == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _appDbContext.Books.ToList();
        }

        public void Delete(int id)
        {
            var bookToDelete = _appDbContext.Books.FirstOrDefault(c => c.BookID == id);
            if (bookToDelete != null)
            {

                _appDbContext.Remove(bookToDelete);
            }

        }

        public void Add(Book book)
        {
            var bookToAdd = _appDbContext.Books.FirstOrDefault(c => c.BookID == book.BookID);
            _appDbContext.Books.Add(book);

        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Update(Book book)
        {
            _appDbContext.Entry(book).State = EntityState.Modified;
        }
    
    }
}
