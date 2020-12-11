using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Class controller for the ContactSkillExpertise model. 
    /// It defines and implements the API methods used to make request to the database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactSkillExpertiseController : ControllerBase
    {
        // --- Attributes ---
            private readonly IContactSkillExpertiseService _contactSkillExpertiseService;
            private readonly IMapper _mapperService;

        // --- Methods ---
            public ContactSkillExpertiseController(IContactSkillExpertiseService contactSkillExpertiseService, IMapper mapperService)
            {
                _contactSkillExpertiseService = contactSkillExpertiseService;
                _mapperService = mapperService;
            }

            [HttpPost("")]
            [Authorize]
            public async Task<ActionResult<ContactSkillExpertiseResource>> CreateCSE(SaveContactSkillExpertiseResource saveCSEResource)
            {

                // validation
                var validation = new SaveContactSkillExpertiseResourceValidation();

                var validationResult = await validation.ValidateAsync(saveCSEResource);

                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
                //mappage
                var cse = _mapperService.Map<SaveContactSkillExpertiseResource, ContactSkillExpertise>(saveCSEResource);
                // Creation de cse
                var newCSE = await _contactSkillExpertiseService.CreateContactSkillExpertise(cse);
                // mappage
                var cseResource = _mapperService.Map<ContactSkillExpertise, ContactSkillExpertiseResource>(newCSE);

                return Ok(cseResource);

            }

            [HttpGet("")]
            [Authorize]
            public async Task<ActionResult<IEnumerable<ContactSkillExpertiseResource>>> GetAllCSE()
            {
                try
                {
                    var cses = await _contactSkillExpertiseService.GetAllContactSkillExpertisesWithCSE();

                    var cseResources = _mapperService.Map<IEnumerable<ContactSkillExpertise>, IEnumerable<ContactSkillExpertiseResource>>(cses);

                    return Ok(cseResources);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

        
            [HttpGet("{id}")]
            [Authorize]
            public async Task<ActionResult<ContactSkillExpertiseResource>> GetCSEById(int id)
            {
                try
                {

                    var cse = await _contactSkillExpertiseService.GetContactSkillExpertiseById(id);
                    if (cse == null) return NotFound();

                    var cseResource = _mapperService.Map<ContactSkillExpertise, ContactSkillExpertiseResource>(cse);

                    return Ok(cseResource);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("Contact/{id}")]
            [Authorize]
            public async Task<ActionResult<IEnumerable<ContactSkillExpertiseResource>>> GetAllCSEsByContactId(int id)
            {
                try
                {

                    var cses = await _contactSkillExpertiseService.GetContactSkillExpertisesByContactId(id);

                    if (cses == null) return BadRequest("No cse for this contact");

                    var cseResources = _mapperService.Map<IEnumerable<ContactSkillExpertise>, IEnumerable<ContactSkillExpertiseResource>>(cses);

                    return Ok(cseResources);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("Skill/id")]
            [Authorize]
            public async Task<ActionResult<IEnumerable<ContactSkillExpertiseResource>>> GetAllCSEsBySkillId(int id)
            {
                try
                {

                    var cses = await _contactSkillExpertiseService.GetContactSkillExpertisesBySkillId(id);

                    if (cses == null) return BadRequest("No cse for this skill");

                    var cseResources = _mapperService.Map<IEnumerable<ContactSkillExpertise>, IEnumerable<ContactSkillExpertiseResource>>(cses);

                    return Ok(cseResources);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("Expertise/id")]
            [Authorize]
            public async Task<ActionResult<IEnumerable<ContactSkillExpertiseResource>>> GetAllCSEsByExpertiseId(int id)
            {
                try
                {

                    var cses = await _contactSkillExpertiseService.GetContactSkillExpertisesByExpertiseId(id);

                    if (cses == null) return BadRequest("No cse for this expertise");

                    var cseResources = _mapperService.Map<IEnumerable<ContactSkillExpertise>, IEnumerable<ContactSkillExpertiseResource>>(cses);

                    return Ok(cseResources);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("Contact/Skill/{ContactId}/{SkillId}")]
            [Authorize]
            public async Task<ActionResult<int>> GetCSEId(int ContactId, int SkillId)
            {
                try
                {
                    // Find CSE Id
                    var cseUpdateId = await _contactSkillExpertiseService.GetContactSkillExpertiseIdByContactIdSkillID(ContactId, SkillId);

                    if (cseUpdateId == 0) return BadRequest("cse not found for these contactId and SkillID");

                    return Ok(cseUpdateId);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }


            [HttpPut("{id}")]
            [Authorize]
            public async Task<ActionResult<ContactSkillExpertiseResource>> UpdateCSEWithId(int id, SaveContactSkillExpertiseResource saveCSEResource)
            {
                try
                {
                    // validation
                    var validation = new SaveContactSkillExpertiseResourceValidation();

                    var validationResult = await validation.ValidateAsync(saveCSEResource);

                    if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                    // if cse exist depuis id

                    var cseUpdate = await _contactSkillExpertiseService.GetContactSkillExpertiseById(id);

                    if (cseUpdate == null) return BadRequest("cse not found");

                    //  mappage
                    var cse = _mapperService.Map<SaveContactSkillExpertiseResource, ContactSkillExpertise>(saveCSEResource);

                    // update
                    await _contactSkillExpertiseService.UpdateContactSkillExpertise(cseUpdate, cse);

                    var cseUpdateNew = await _contactSkillExpertiseService.GetContactSkillExpertiseById(id);

                    // Mappage 
                    var cseResourceUpdate = _mapperService.Map<ContactSkillExpertise, ContactSkillExpertiseResource>(cseUpdateNew);
                    return Ok(cseResourceUpdate);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

       


            [HttpPut("")]
            [Authorize]
            public async Task<ActionResult<ContactSkillExpertiseResource>> UpdateCSE( SaveContactSkillExpertiseResource saveCSEResource)
            {
                try
                {
                    // validation
                    var validation = new SaveContactSkillExpertiseResourceValidation();

                    var validationResult = await validation.ValidateAsync(saveCSEResource);

                    if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                    // Find CSE Id
                    //  mappage
                    var cseToFind = _mapperService.Map<SaveContactSkillExpertiseResource, ContactSkillExpertise>(saveCSEResource);

                    var cseUpdateId = await _contactSkillExpertiseService.GetContactSkillExpertiseId(cseToFind);

                    if (cseUpdateId == 0) return BadRequest("cse not found");

                    var cseUpdate = await _contactSkillExpertiseService.GetContactSkillExpertiseById(cseUpdateId);

                    if (cseUpdate == null) return BadRequest("cse not found");

                    // update
                    await _contactSkillExpertiseService.UpdateContactSkillExpertise(cseUpdate, cseToFind);

                    var cseUpdateNew = await _contactSkillExpertiseService.GetContactSkillExpertiseById(cseUpdateId);

                    // Mappage 
                    var cseResourceUpdate = _mapperService.Map<ContactSkillExpertise, ContactSkillExpertiseResource>(cseUpdateNew);
                    return Ok(cseResourceUpdate);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            [HttpDelete("{id}")]
            [Authorize]
            public async Task<ActionResult> deleteCSE(int id)
            {
                var cse = await _contactSkillExpertiseService.GetContactSkillExpertiseById(id);

                if (cse == null) return BadRequest("CSE not found");

                await _contactSkillExpertiseService.DeleteContactSkillExpertise(cse);

                return NoContent();
            }

        


    }
}
