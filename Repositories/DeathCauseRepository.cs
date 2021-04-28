using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBackendDevelopment.Data;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.Repositories
{
    public interface IDeathCauseRepository
    {
        Task<List<DeathCause>> GetDeathCauses();
    }

    public class DeathCauseRepository : IDeathCauseRepository
    {
        private IOutlawContext _context;
        public DeathCauseRepository(IOutlawContext context)
        {
            _context = context;
        }
        public async Task<List<DeathCause>> GetDeathCauses()
        {
            return await _context.DeathCauses.ToListAsync();
        }
    }
}
