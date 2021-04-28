using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Outlaws.API.Data;
using Outlaws.API.DTO;
using Outlaws.API.Models;
using Outlaws.API.Services;

namespace Outlaws.API.Controllers
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

        [Route("gangs")]
        [HttpGet]
        public async Task<ActionResult<List<Gang>>> GetGangsAsync(){
            return await _outlawService.GetGangs();
        }

        [HttpGet]
        [Route("outlaws")]
        public async Task<ActionResult<List<Outlaw>>> GetOutlawsAsync(){
            try {
                return await _outlawService.GetOutlaws();
            }
            catch(Exception e) {
                return new StatusCodeResult(500);
            }
            
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
