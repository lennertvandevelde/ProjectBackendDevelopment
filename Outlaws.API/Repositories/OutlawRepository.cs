using System;
using System.Collections.Generic;
using System.Net.Http;
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
            {await _context.Outlaws.AddAsync(outlaw);
            await _context.SaveChangesAsync();
            return outlaw;}
            catch (Exception e){
                throw e;
            }

        }
    }
}
