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
    public class PublishingCompanyService
    {
        private readonly ApplicationDbContext _context;

        public PublishingCompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PublishingCompany>> FindAllAsync()
        {
            return await _context.PublishingCompanies.ToListAsync();
        }

        public async Task<PublishingCompany> FindByIdAsync(Guid id)
        {
            return await _context.PublishingCompanies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(PublishingCompany publishingCompany)
        {
            _context.Add(publishingCompany);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            try
            {
                var publishingCompany = await _context.PublishingCompanies.FindAsync(id);
                _context.PublishingCompanies.Remove(publishingCompany);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(PublishingCompany publishingCompany)
        {
            bool hasAny = await _context.PublishingCompanies.AnyAsync(x => x.Id == publishingCompany.Id);

            if (!hasAny)
            {
                throw new DllNotFoundException("Id not found");
            }

            try
            {
                _context.Update(publishingCompany);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }

        }
    }
}
