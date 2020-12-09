using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyContacts.API.Resources;
using MyContacts.API.Validation;
using MyContacts.Core.Models;
using MyContacts.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertiseController : ControllerBase
    {
        private readonly IExpertiseService _expertiseService;
        private readonly IMapper _mapperService;

        public ExpertiseController(IExpertiseService expertiseService, IMapper mapperService)
        {
            _expertiseService = expertiseService;
            _mapperService = mapperService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ExpertiseResource>>> GetAllExpertises()
        {
            try
            {

                var expertises = await _expertiseService.GetAllExpertises();

                var expertiseResources = _mapperService.Map<IEnumerable<Expertise>, IEnumerable<ExpertiseResource>>(expertises);

                return Ok(expertiseResources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpertiseResource>> GetExpertiseById(int id)
        {
            try
            {

                var expertise = await _expertiseService.GetExpertiseById(id);

                if (expertise == null) return BadRequest("No expertise found");

                var expertiseResource = _mapperService.Map<Expertise, ExpertiseResource>(expertise);

                return Ok(expertiseResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<ExpertiseResource>> CreateExpertise(SaveExpertiseResource saveExpertiseResource)
        {
            try
            {
                //Validation des données entrantes
                var validation = new SaveExpertiseResourceValidation();
                var validationResult = await validation.ValidateAsync(saveExpertiseResource);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                //Mappage
                var expertise = _mapperService.Map<SaveExpertiseResource, Expertise>(saveExpertiseResource);
                //Création
                var expertiseNew = await _expertiseService.CreateExpertise(expertise);
                //Mappage
                var expertiseResource = _mapperService.Map<Expertise, ExpertiseResource>(expertiseNew);
                return Ok(expertiseResource);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("")]
        public async Task<ActionResult<ExpertiseResource>> UpdateExpertise(int id, SaveExpertiseResource saveExpertiseResource)
        {
            try
            {
                //Validation des données entrantes
                var validation = new SaveExpertiseResourceValidation();
                var validationResult = await validation.ValidateAsync(saveExpertiseResource);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                //Get expertise by id
                var expertiseUpdate = await _expertiseService.GetExpertiseById(id);
                if (expertiseUpdate == null) return NotFound();

                //Mappage
                var expertise = _mapperService.Map<SaveExpertiseResource, Expertise>(saveExpertiseResource);
                //Update expertise
                await _expertiseService.UpdateExpertise(expertiseUpdate, expertise);
                //get new expertise by id
                var expertiseNew = await _expertiseService.GetExpertiseById(id);
                //Mappage
                var expertiseNewResource = _mapperService.Map<Expertise, ExpertiseResource>(expertiseNew);

                return Ok(expertiseNewResource);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpertise(int id)
        {
            try
            {
                var expertise = await _expertiseService.GetExpertiseById(id);

                if (expertise == null) return NotFound();

                await _expertiseService.DeleteExpertise(expertise);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
