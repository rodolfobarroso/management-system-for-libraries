using ManagementSystemforLibraries.Data;
using ManagementSystemforLibraries.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services.Excepetions;

namespace WebApplication.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> FindAllAsync()
        {
            return await _context.Books
                .OrderBy(x => x.Title)
                .ToListAsync();
        }

        public async Task<Book> FindByIdAsync(Guid id)
        {
            return await _context
                .Books
                .Include(x => x.PublishingCompany)
                .Include(x => x.AuthorBooks)
                .Include(x => x.Copies)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> HasAnyByAutorIdAsync(Guid id)
        {
            return await _context.Copies.AnyAsync(x => x.BookId == id);
        }

        public async Task InsertAsync(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Book book)
        {
            bool hasAny = await _context.Books.AnyAsync(x => x.Id == book.Id);

            if (!hasAny)
            {
                throw new DllNotFoundException("Id not found");
            }

            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }

        }
    }
}
