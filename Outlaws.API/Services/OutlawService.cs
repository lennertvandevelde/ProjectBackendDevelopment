using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Outlaws.API.DTO;
using Outlaws.API.Models;
using Outlaws.API.Repositories;

namespace Outlaws.API.Services
{
    public interface IOutlawService
    {
        Task<OutlawDTO> AddOutlaw(OutlawDTO outlaw);
        Task<List<DeathCause>> GetDeathCauses();
        Task<List<Gang>> GetGangs();
        Task<List<Outlaw>> GetOutlaws();
    }

    public class OutlawService : IOutlawService
    {
        private IDeathCauseRepository _deathCauseRepository;
        private IOutlawRepository _outlawRepository;
        private IGangRepository _gangRepository;
        private IMapper _mapper;
        public OutlawService(IDeathCauseRepository deathCauseRepository,
            IOutlawRepository outlawRepository,
            IGangRepository gangRepository,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _deathCauseRepository = deathCauseRepository;
            _outlawRepository = outlawRepository;
            _gangRepository = gangRepository;
        }
        public async Task<List<Outlaw>> GetOutlaws()
        {
            return await _outlawRepository.GetOutlaws();
        }
        public async Task<List<DeathCause>> GetDeathCauses()
        {
            return await _deathCauseRepository.GetDeathCauses();

        }
        public async Task<List<Gang>> GetGangs()
        {
            return await _gangRepository.GetGangs();
        }
        public async Task<OutlawDTO> AddOutlaw(OutlawDTO outlaw)
        {
            try
            {
                Outlaw newOutlaw = _mapper.Map<Outlaw>(outlaw);
                newOutlaw.GangOutlaws = new List<GangOutlaw>();
                if(outlaw.Gangs != null){
                    foreach (var GangId in outlaw.Gangs)
                {
                    newOutlaw.GangOutlaws.Add(new GangOutlaw() { GangId = GangId });
                }
                }
                
                await _outlawRepository.AddOutlaw(newOutlaw);
                return outlaw;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}