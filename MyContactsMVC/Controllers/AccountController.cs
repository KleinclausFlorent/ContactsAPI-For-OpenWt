using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyContactsMVC.Models;
using MyContactsMVC.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyContactsMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _Config;
        private string URLBase
        {
            get
            {
                return _Config.GetSection("BaseURL").GetSection("URL").Value;
            }
        }

        public AccountController(IConfiguration Config)
        {
            _Config = Config;
        }
        public IActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    var user = new User();
                    user.Username = loginViewModel.Username;
                    user.Password = loginViewModel.Password;
                    string stringData = JsonConvert.SerializeObject(user);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(URLBase + "User/authenticate", contentData);
                    var result = response.IsSuccessStatusCode;
                    if (result)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<System.IdentityModel.Tokens.Jwt.JwtPayload>(stringJWT);
                        var jwtString = jwt["token"].ToString();
                        HttpContext.Session.SetString("token", jwtString);

                        HttpContext.Session.SetString("username", jwt["username"].ToString());//username

                        //HttpContext.Session.SetString("ContactId", jwt["ContactId"].ToString()); //ContactId

                        ViewBag.Message = "User logged in successfully!" + jwt["username"].ToString();
                    }

                }
            }

            return View();
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Register()
        {
            var register = new RegisterViewModel();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    string stringData = JsonConvert.SerializeObject(register);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(URLBase + "User/register", contentData);
                    var result = response.IsSuccessStatusCode;
                    if (result)
                    {
                        string stringJWT = response.Content.ReadAsStringAsync().Result;
                        var jwt = JsonConvert.DeserializeObject<System.IdentityModel.Tokens.Jwt.JwtPayload>(stringJWT);
                        var jwtString = jwt["token"].ToString();
                        HttpContext.Session.SetString("token", jwtString);

                        HttpContext.Session.SetString("username", jwt["username"].ToString());//username

                       // HttpContext.Session.SetString("ContactId", jwt["ContactId"].ToString()); //ContactId

                        ViewBag.Message = "User logged in successfully!" + jwt["username"].ToString();
                        return RedirectToAction("Index", "Home");

                    }
                }
            }
            return View();
        }
    }
}
