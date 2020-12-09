using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyContacts.API.Resources;
using MyContacts.API.Validation;
using MyContacts.Core.Models;
using MyContacts.Core.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapperService;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IMapper mapperService, IConfiguration config)
        {
            _userService = userService;
            _mapperService = mapperService;
            _config = config;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(SaveUserResource saveUserResource)
        {
            var user = await _userService.Authenticate(saveUserResource.Username, saveUserResource.Password);
            if (user == null) return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.Id,
                Contact = user.ContactId,
                Username = user.Username,
                Token = tokenString
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(SaveUserResource saveUserResource)
        {
            try
            {
                //Validation des données entrantes
                var validation = new SaveUserResourceValidation();
                var validationResult = await validation.ValidateAsync(saveUserResource);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                //Mappage
                var user = _mapperService.Map<SaveUserResource, User>(saveUserResource);
                //Création
                var userSave = await _userService.Create(user, saveUserResource.Password);
                //Mappage
                var userResource = _mapperService.Map<User, UserResource>(userSave);

                //Send token 

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config.GetValue<string>("AppSettings:Secret"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(new
                {
                    Id = user.Id,
                    Contact = user.ContactId,
                    Username = user.Username,
                    Token = tokenString
                }); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
