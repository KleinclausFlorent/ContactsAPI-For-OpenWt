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
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {

        private readonly ISkillService _skillService;
        private readonly IMapper _mapperService;

        public SkillController(ISkillService skillService, IMapper mapperService)
        {
            _skillService = skillService;
            _mapperService = mapperService;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SkillResource>>> GetAllSkills()
        {
            try
            {

                var skills = await _skillService.GetAllSkills();

                var skillResources = _mapperService.Map<IEnumerable<Skill>, IEnumerable<SkillResource>>(skills);

                return Ok(skillResources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<SkillResource>> GetSkillById(int id)
        {
            try
            {

                var skill = await _skillService.GetSkillById(id);

                if (skill == null) return BadRequest("No Skill found");

                var skillResource = _mapperService.Map<Skill, SkillResource>(skill);

                return Ok(skillResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        [Authorize]
        public async Task<ActionResult<SkillResource>> CreateSkill(SaveSkillResource saveSkillResource)
        {
            try
            {
                //Validation des données entrantes
                var validation = new SaveSkillResourceValidation();
                var validationResult = await validation.ValidateAsync(saveSkillResource);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                //Mappage
                var skill = _mapperService.Map<SaveSkillResource, Skill>(saveSkillResource);
                //Création
                var skillNew = await _skillService.CreateSkill(skill);
                //Mappage
                var skillResource = _mapperService.Map<Skill, SkillResource>(skillNew);
                return Ok(skillResource);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("")]
        [Authorize]
        public async Task<ActionResult<SkillResource>> UpdateSkill(int id, SaveSkillResource saveSkillResource)
        {
            try
            {
                //Validation des données entrantes
                var validation = new SaveSkillResourceValidation();
                var validationResult = await validation.ValidateAsync(saveSkillResource);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                //Get skill by id
                var skillUpdate = await _skillService.GetSkillById(id);
                if (skillUpdate == null) return NotFound();

                //Mappage
                var skill = _mapperService.Map<SaveSkillResource, Skill>(saveSkillResource);
                //Update skill
                await _skillService.UpdateSkill(skillUpdate, skill);
                //get new skill by id
                var skillNew = await _skillService.GetSkillById(id);
                //Mappage
                var skillNewResource = _mapperService.Map<Skill, SkillResource>(skillNew);

                return Ok(skillNewResource);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteSkill(int id)
        {
            try
            {
                var skill = await _skillService.GetSkillById(id);

                if (skill == null) return NotFound();

                await _skillService.DeleteSkill(skill);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
