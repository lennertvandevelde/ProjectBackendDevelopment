using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Outlaws.API.Data;
using Outlaws.API.Models;
namespace Outlaws.API.Repositories
{
    public interface IGangRepository
    {
        Task<List<Gang>> GetGangs();
    }

    public class GangRepository : IGangRepository
    {
        private IOutlawContext _context;
        public GangRepository(IOutlawContext context)
        {
            _context = context;
        }
        public async Task<List<Gang>> GetGangs()
        {
            return await _context.Gangs.ToListAsync();
        }

    }
}
