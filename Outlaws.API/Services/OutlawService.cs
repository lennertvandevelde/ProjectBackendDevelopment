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
        Task<Outlaw> AddOutlawWithUri(string uri);
        Task<List<DeathCause>> GetDeathCauses();
        Task<List<Gang>> GetGangs();
        Task<Outlaw> GetOutlaw(Guid outlawid);
        Task<List<Outlaw>> GetOutlaws();
        Task<Outlaw> UpdateOutlaw(OutlawUpdateDTO updateoutlaw);
    }

    public class OutlawService : IOutlawService
    {
        private IDeathCauseRepository _deathCauseRepository;
        private IOutlawRepository _outlawRepository;
        private IGangRepository _gangRepository;
        private IMapper _mapper;
        private ISPARQLService _sparqlService;
        public OutlawService(IDeathCauseRepository deathCauseRepository,
            IOutlawRepository outlawRepository,
            IGangRepository gangRepository,
            IMapper mapper, ISPARQLService sparqlService
        )
        {
            _mapper = mapper;
            _deathCauseRepository = deathCauseRepository;
            _outlawRepository = outlawRepository;
            _gangRepository = gangRepository;
            _sparqlService = sparqlService;
        }
        public async Task<List<Outlaw>> GetOutlaws()
        {
            return await _outlawRepository.GetOutlaws();
        }
        public async Task<Outlaw> GetOutlaw(Guid outlawid)
        {
            return await _outlawRepository.GetOutlaw(outlawid);
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
                if (outlaw.Gangs != null)
                {
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

        public async Task<Outlaw> AddOutlawWithUri(string uri)
        {
            try
            {
                Outlaw outlaw = await _sparqlService.GetOutlaw(uri);

                await _outlawRepository.AddOutlaw(outlaw);
                return outlaw;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Outlaw> UpdateOutlaw(OutlawUpdateDTO updateoutlaw)
        {
            try
            {
                Outlaw outlaw = await _outlawRepository.GetOutlaw(updateoutlaw.OutlawId);
                outlaw.GangOutlaws = new List<GangOutlaw>();
                if (updateoutlaw.Gangs != null)
                {
                    foreach (var GangId in updateoutlaw.Gangs)
                    {
                        outlaw.GangOutlaws.Add(new GangOutlaw() { GangId = GangId });
                    }
                }
                if (updateoutlaw.DeathCauseId != null)
                {
                    outlaw.DeathCauseId = updateoutlaw.DeathCauseId[0];
                }


                await _outlawRepository.UpdateOutlaw(outlaw);
                return outlaw;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
