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
    /// Class controller for the contact model. 
    /// It defines and implements the API methods used to make request to the database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // --- Attributes ---
            private readonly IContactService _contactService;
            private readonly IMapper _mapperService;

        // --- Methods ---
            public ContactController(IContactService contactService, IMapper mapperService)
            {
                _contactService = contactService;
                _mapperService = mapperService;
            }

            [HttpGet("")]
            [Authorize]
            public async Task<ActionResult<IEnumerable<ContactResource>>> GetAllContact()
            {
                try
                {

                    var contacts = await _contactService.GetAllContacts();

                    var contactResources = _mapperService.Map<IEnumerable<Contact>, IEnumerable<ContactResource>>(contacts);

                    return Ok(contactResources);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("{id}")]
            [Authorize]
            public async Task<ActionResult<ContactResource>> GetContactById(int id)
            {
                try
                {

                    var contact = await _contactService.GetContactById(id);

                    if (contact == null) return BadRequest("No contact found");

                    var contactResource = _mapperService.Map<Contact, ContactResource>(contact);

                    return Ok(contactResource);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost("")]
            [Authorize]
            public async Task<ActionResult<ContactResource>> CreateContact(SaveContactResource saveContactResource)
            {
                try
                {
                    //Validation des données entrantes
                    var validation = new SaveContactResourceValidation();
                    var validationResult = await validation.ValidateAsync(saveContactResource);
                    if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                    //Mappage
                    var contact = _mapperService.Map<SaveContactResource, Contact>(saveContactResource);
                    //Création
                    var contactNew = await _contactService.CreateContact(contact);
                    //Mappage
                    var contactResource = _mapperService.Map<Contact, ContactResource>(contactNew);
                    return Ok(contactResource);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


            [HttpPut("")]
            [Authorize]
            public async Task<ActionResult<ContactResource>> UpdateContact(int id, SaveContactResource saveContactResource)
            {
                try
                {
                    //Validation des données entrantes
                    var validation = new SaveContactResourceValidation();
                    var validationResult = await validation.ValidateAsync(saveContactResource);
                    if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                    //Get contact by id
                    var contactUpdate = await _contactService.GetContactById(id);
                    if (contactUpdate == null) return NotFound();

                    //Mappage
                    var contact = _mapperService.Map<SaveContactResource, Contact>(saveContactResource);
                    //Update contact
                    await _contactService.UpdateContact(contactUpdate, contact);
                    //get new contact by id
                    var contactNew = await _contactService.GetContactById(id);
                    //Mappage
                    var contactNewResource = _mapperService.Map<Contact, ContactResource>(contactNew);

                    return Ok(contactNewResource);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete("{id}")]
            [Authorize]
            public async Task<ActionResult> DeleteContact(int id)
            {
                try
                {
                    var contact = await _contactService.GetContactById(id);

                    if (contact == null) return NotFound();

                    await _contactService.DeleteContact(contact);

                    return NoContent();

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
    }
}
