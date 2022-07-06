using CodigoPenalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalApi.Services
{
    public interface ICodigoPenalService
    { 
      // Codigos Penais
        Task<IEnumerable<CriminalCode>> GetCriminalCodes();
        Task<CriminalCode> GetCriminalCodes(int id);
        Task<IEnumerable<CriminalCode>> GetCriminalCodesByName(string name);
        Task CreateCriminalCode(CriminalCode criminalCode);
        Task UpdateCriminalCode(CriminalCode criminalCode);
        Task DeleteCriminalCode(CriminalCode criminalCode);
    }
}
