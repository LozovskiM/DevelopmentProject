using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopmentProject.DB;
using DevelopmentProject.DB.Models;
using DevelopmentProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentProject.Services
{
    public class BookService : IBookService
    {
        private readonly DevelopmentProjectDbContext _db;

        public BookService(DevelopmentProjectDbContext db)
        {
            _db = db;
        }
        public async Task<Book> CreateAsync(Book model)
        {
            _db.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = _db.Books.SingleOrDefault(x => x.Id == id);
            if (exists == null) return false;
            _db.Books.Remove(exists);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _db.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _db.Books.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book> UpdateAsync(Book model)
        {
            var editBook = await _db.Books.FindAsync(model.Id);
            CopyFields(editBook, model);
            await _db.SaveChangesAsync();
            return model;
        }

        private static void CopyFields (Book dest, Book source)
        {
            var modelProps = dest.GetType().GetProperties();
            foreach (var modelProp in modelProps)
            {
                modelProp.SetValue(dest, modelProp.GetValue(source));
            }
        }
    }
}
