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
            /// <summary>
            /// attribute use to access the contact service reference to use the requests defined in it
            /// </summary>
            private readonly IContactService _contactService;
            /// <summary>
            /// Attribute use to acces the mapper service reference to use its conversion methods
            /// </summary>
            private readonly IMapper _mapperService;

        // --- Methods ---

            /// <summary>
            /// Constructor method use to inject dependancies
            /// </summary>
            /// <param name="contactService"><see cref="IContactService"/></param>
            /// <param name="mapperService"><see cref="IMapper"/></param>
            public ContactController(IContactService contactService, IMapper mapperService)
            {
                _contactService = contactService;
                _mapperService = mapperService;
            }


            /// <summary>
            /// method used when get request is made to the api for the Contact
            /// </summary>
            /// <returns>A list of <see cref="ContactResource"/></returns>
            [HttpGet("")]
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


            /// <summary>
            /// method used when the api answer to a get request with an id
            /// </summary>
            /// <param name="id">Int value refering to the id of a contact in the database</param>
            /// <returns>The <see cref="ContactResource"/> linked to the id or an error saying that there is no such contact </returns>
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


            /// <summary>
            /// method used to answer a post request
            /// </summary>
            /// <param name="saveContactResource">The saveContactResource to add to the database</param>
            /// <returns>The new contactResource from the database</returns>
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


            
            /// <summary>
            /// Method used to answer a put request. It updates a contact
            /// </summary>
            /// <param name="id">id of the contact which need to be modify</param>
            /// <param name="saveContactResource">the saveContactResource which contains the updated values for the contact</param>
            /// <returns>the contactResource of the updated contact</returns>
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

            /// <summary>
            /// method used to answer a delete request. It deletes a contact from the database
            /// </summary>
            /// <param name="id">Id of the contact which need to be delete</param>
            /// <returns>Nothing</returns>
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
