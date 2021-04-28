using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Outlaws.API.Data;
using Outlaws.API.Models;

namespace Outlaws.API.Repositories
{
    public interface IOutlawRepository
    {
        Task<Outlaw> AddOutlaw(Outlaw outlaw);
        Task<List<Outlaw>> GetOutlaws();
    }

    public class OutlawRepository : IOutlawRepository
    {
        private IOutlawContext _context;
        public OutlawRepository(IOutlawContext context)
        {
            _context = context;
        }
        public async Task<List<Outlaw>> GetOutlaws()
        {
            return await _context.Outlaws.Include(b => b.DeathCause).Include(b => b.GangOutlaws).ThenInclude(b => b.Gang).ToListAsync();
        }

        public async Task<Outlaw> AddOutlaw(Outlaw outlaw)
        {
            await _context.Outlaws.AddAsync(outlaw);
            await _context.SaveChangesAsync();
            return outlaw;

        }
    }
}