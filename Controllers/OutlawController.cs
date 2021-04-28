using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBackendDevelopment.Data;
using ProjectBackendDevelopment.DTO;
using ProjectBackendDevelopment.Models;
using ProjectBackendDevelopment.Services;

namespace ProjectBackendDevelopment.Controllers
{
    
    [ApiController]
    public class OutlawController :ControllerBase
    {
        private IOutlawService _outlawService;

        public OutlawController(IOutlawService outlawService)
        {
            _outlawService = outlawService;
        }

        [Route("deathcauses")]
        [HttpGet]
        public async Task<ActionResult<List<DeathCause>>> GetDeathCausesAsync(){
            return await _outlawService.GetDeathCauses();
        }

        [HttpGet]
        [Route("outlaws")]
        public async Task<ActionResult<List<Outlaw>>> GetOutlawsAsync(){
            return await _outlawService.GetOutlaws();
        }

        [Route("outlaw")]
        [HttpPost]
        public async Task<ActionResult<OutlawDTO>> AddOutlawAsync(OutlawDTO outlaw){
            try {
                return new OkObjectResult(await _outlawService.AddOutlaw(outlaw));

            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
           
        }
    }
}
