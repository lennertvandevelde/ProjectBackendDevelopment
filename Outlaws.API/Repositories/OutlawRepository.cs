using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Outlaws.API.Data;
using Outlaws.API.Models;

namespace Outlaws.API.Repositories
{
    public interface IOutlawRepository
    {
        HttpClient Client { get; set; }

        Task<Outlaw> AddOutlaw(Outlaw outlaw);
        Task<Outlaw> GetOutlaw(Guid outlawid);
        Task<List<Outlaw>> GetOutlaws();
        Task UpdateOutlaw(Outlaw outlaw);
    }

    public class OutlawRepository : IOutlawRepository
    {
        public HttpClient Client { get; set; }
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
            try
            {
                await _context.Outlaws.AddAsync(outlaw);
                await _context.SaveChangesAsync();
                return outlaw;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<Outlaw> GetOutlaw(Guid outlawid)
        {
            return await _context.Outlaws.Where(b => b.OutlawId == outlawid)
            .Include(b => b.DeathCause).Include(b => b.GangOutlaws).ThenInclude(b => b.Gang).SingleOrDefaultAsync();
        }

        public async Task UpdateOutlaw(Outlaw outlaw)
        {
            _context.Outlaws.Update(outlaw);
            await _context.SaveChangesAsync();
        }

    }
}
