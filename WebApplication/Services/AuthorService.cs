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
    public class AuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> FindAllAsync()
        {
            return await _context.Authors
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Author> FindByIdAsync(Guid id)
        {
            return await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Author author)
        {
            _context.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {
                var author = await _context.Authors.FindAsync(id);
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Author author)
        {
            bool hasAny = await _context.Authors.AnyAsync(x => x.Id == author.Id);

            if (!hasAny)
            {
                throw new DllNotFoundException("Id not found");
            }

            try
            {
                _context.Update(author);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }

        }
    }
}
