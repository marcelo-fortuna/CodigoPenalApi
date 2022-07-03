using CodigoPenalApi.Context;
using CodigoPenalApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalApi.Services
{
    public class CodigoPenalService : ICodigoPenalService
    {
        private readonly AppDbContext _context;

        public CodigoPenalService(AppDbContext context)
        {
            _context = context;
        }

        // Criminal Codes //

        public async Task<IEnumerable<CriminalCode>> GetCriminalCodes()
        {
            try
            {
                return await _context.CriminalCode.AsNoTracking()
                                                  .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<CriminalCode> GetCriminalCodes(int id)
        {
            var criminalCode = await _context.CriminalCode.FindAsync(id);
            return criminalCode;
        }

        public async Task<IEnumerable<CriminalCode>> GetCriminalCodesByName(string name)
        {
            IEnumerable<CriminalCode> criminalCodes;
            if (string.IsNullOrWhiteSpace(name))
            {
                criminalCodes = await _context.CriminalCode.Where(n => n.Name.Contains(name)).ToListAsync();
            }
            else
            {
                criminalCodes = await GetCriminalCodes();
            }
            return criminalCodes;
        }

        public async Task CreateCriminalCode(CriminalCode criminalCode)
        {
            _context.CriminalCode.Add(criminalCode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCriminalCode(CriminalCode criminalCode)
        {
            _context.Entry(criminalCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCriminalCode(CriminalCode criminalCode)
        {
            _context.CriminalCode.Remove(criminalCode);
            await _context.SaveChangesAsync();
        }
    }
}
