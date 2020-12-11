using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyContactsMVC.Models;
using MyContactsMVC.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyContactsMVC.Controllers
{
    /// <summary>
    /// Class controller for the ContactSkillExpertise. 
    /// It defines and implements the Client methods used to make request to the API
    /// </summary>
    public class CSEController : Controller
    {
        // --- Attributes ---
            private readonly IConfiguration _Config;
            private string URLBase
            {
                get
                {
                    return _Config.GetSection("BaseURL").GetSection("URL").Value;
                }
            }

        // --- Methods ---
            public CSEController(IConfiguration Config)
            {
                _Config = Config;
            }

            public IActionResult Index()
            {
                return View();
            }


            public async Task<IActionResult> Show()
            {
           
                var listCSEViewModel = new ListCSEViewModel();
                var listCSE = new List<ContactSkillExpertise>();
                using (var httpClient = new HttpClient())
                {
                    var JWToken = HttpContext.Session.GetString("token");
                    var ContactId = HttpContext.Session.GetString("ContactId");
                    if (string.IsNullOrEmpty(JWToken))
                    {
                        ViewBag.MessageError = "You must be authenticate";
                        return View(listCSEViewModel);
                    }
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);
                    using (var response = await httpClient.GetAsync(URLBase + "ContactSkillExpertise/Contact/" + Int32.Parse(ContactId)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        listCSE = JsonConvert.DeserializeObject<List<ContactSkillExpertise>>(apiResponse);
                    }
                }
                listCSEViewModel.ListCSE = listCSE;
                return View(listCSEViewModel);
            }

            public async Task<IActionResult> Add()
            {
                var cseVM = new ContactSkillExpertiseViewModel();

                List<Contact> contactList = new List<Contact>();
                List<Skill> skillList = new List<Skill>();
                List<Skill> contactSkillList = new List<Skill>();
                List<Skill> contactSkillListToShow = new List<Skill>();
                List<Expertise> expertiseList = new List<Expertise>();

                using (var httpClient = new HttpClient())
                {
                    var JWToken = HttpContext.Session.GetString("token");
                    var ContactId = HttpContext.Session.GetString("ContactId");
                    if (string.IsNullOrEmpty(JWToken))
                    {
                        ViewBag.MessageError = "You must be authenticate";
                        return View(cseVM);
                    }

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);
                    using (var response = await httpClient.GetAsync(URLBase + "Contact/" + Int32.Parse(ContactId)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        contactList.Add(JsonConvert.DeserializeObject<Contact>(apiResponse));
                    }
                    //Add verification to show only skill which has no link with this contact ID
                    using (var response = await httpClient.GetAsync(URLBase + "Skill"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        skillList = JsonConvert.DeserializeObject<List<Skill>>(apiResponse);
                    }
                    using (var response = await httpClient.GetAsync(URLBase + "ContactSkillExpertise/Contact/" + Int32.Parse(ContactId)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        List<ContactSkillExpertise> temp = JsonConvert.DeserializeObject<List<ContactSkillExpertise>>(apiResponse);
                        if (temp != null)
                        {
                            foreach (var cse in temp)
                            {
                                contactSkillList.Add(cse.Skill);
                            }
                        }
                    }

                    foreach(var skill in skillList)
                    {
                        if (!contactSkillList.Any(s => s.Id == skill.Id))
                        {
                            contactSkillListToShow.Add(skill);
                        }
                    }

                        using (var response = await httpClient.GetAsync(URLBase + "Expertise"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        expertiseList = JsonConvert.DeserializeObject<List<Expertise>>(apiResponse);
                    }

                }
                cseVM.ContactList = new SelectList(contactList, "Id", "Firstname");
                cseVM.SkillList = new SelectList(contactSkillListToShow, "Id", "Name");
                cseVM.ExpertiseList = new SelectList(expertiseList, "Id", "Name");
                return View(cseVM);
            }
        
            [HttpPost]
            public async Task<IActionResult> Add(ContactSkillExpertiseViewModel cseModelView)
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        var cse = new ContactSkillExpertise() { ContactId = int.Parse(cseModelView.ContactId), SkillId = int.Parse(cseModelView.SkillId), ExpertiseId = int.Parse(cseModelView.ExpertiseId) };
                        var JWToken = HttpContext.Session.GetString("token");
                        if (string.IsNullOrEmpty(JWToken))
                        {
                            ViewBag.MessageError = "You must be authenticate";
                            return View(cseModelView);
                        }
                        string stringData = JsonConvert.SerializeObject(cse);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);
                        var response = await client.PostAsync(URLBase + "ContactSkillExpertise", contentData);
                        var result = response.IsSuccessStatusCode;
                        if (result)
                        {
                            return RedirectToAction("Show", "CSE");
                        }
                        ViewBag.MessageError = response.ReasonPhrase;
                        return View(cseModelView);

                    }

                }
                return View(cseModelView);
            }

            public async Task<IActionResult> Update()
            {
                var cseVM = new ContactSkillExpertiseViewModel();

                List<Contact> contactList = new List<Contact>();
                List<Skill> skillList = new List<Skill>();
                List<Expertise> expertiseList = new List<Expertise>();

                using (var httpClient = new HttpClient())
                {
                    var JWToken = HttpContext.Session.GetString("token");
                    var ContactId = HttpContext.Session.GetString("ContactId");
                    if (string.IsNullOrEmpty(JWToken))
                    {
                        ViewBag.MessageError = "You must be authenticate";
                        return View(cseVM);
                    }

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);
                    using (var response = await httpClient.GetAsync(URLBase + "Contact/" + Int32.Parse(ContactId)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        contactList.Add(JsonConvert.DeserializeObject<Contact>(apiResponse));
                    }
                    using (var response = await httpClient.GetAsync(URLBase + "ContactSkillExpertise/Contact/" + Int32.Parse(ContactId)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        List<ContactSkillExpertise> temp = JsonConvert.DeserializeObject<List<ContactSkillExpertise>>(apiResponse);
                        if (temp != null)
                        {
                            foreach ( var cse in temp)
                            {
                                skillList.Add(cse.Skill);
                            }
                        } else
                        {
                            ViewBag.MessageError = "No skill to update";
                            return View(cseVM);
                        }
                    
                    }
                    using (var response = await httpClient.GetAsync(URLBase + "Expertise"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        expertiseList = JsonConvert.DeserializeObject<List<Expertise>>(apiResponse);
                    }

                }
                cseVM.ContactList = new SelectList(contactList, "Id", "Firstname");
                cseVM.SkillList = new SelectList(skillList, "Id", "Name");
                cseVM.ExpertiseList = new SelectList(expertiseList, "Id", "Name");
                return View(cseVM);
            }


            [HttpPost]
            public async Task<IActionResult> Update(ContactSkillExpertiseViewModel cseModelView)
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        var cse = new ContactSkillExpertise() { ContactId = int.Parse(cseModelView.ContactId), SkillId = int.Parse(cseModelView.SkillId), ExpertiseId = int.Parse(cseModelView.ExpertiseId) };
                        var JWToken = HttpContext.Session.GetString("token");
                        if (string.IsNullOrEmpty(JWToken))
                        {
                            ViewBag.MessageError = "You must be authenticate";
                            return View(cseModelView);
                        }
                        string stringData = JsonConvert.SerializeObject(cse);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);
                        var response = await client.PutAsync(URLBase + "ContactSkillExpertise", contentData);
                        var result = response.IsSuccessStatusCode;
                        if (result)
                        {
                            return RedirectToAction("Show", "CSE");
                        }
                        ViewBag.MessageError = response.ReasonPhrase;
                        return View(cseModelView);

                    }

                }
                return View(cseModelView);
            }




            public async Task<IActionResult> Delete()
            {
                var cseVM = new ContactSkillExpertiseViewModel();

                List<Contact> contactList = new List<Contact>();
                List<Skill> skillList = new List<Skill>();
                List<Expertise> expertiseList = new List<Expertise>();

                using (var httpClient = new HttpClient())
                {
                    var JWToken = HttpContext.Session.GetString("token");
                    var ContactId = HttpContext.Session.GetString("ContactId");
                    if (string.IsNullOrEmpty(JWToken))
                    {
                        ViewBag.MessageError = "You must be authenticate";
                        return View(cseVM);
                    }

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);
                    using (var response = await httpClient.GetAsync(URLBase + "Contact/" + Int32.Parse(ContactId)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        contactList.Add(JsonConvert.DeserializeObject<Contact>(apiResponse));
                    }
                    using (var response = await httpClient.GetAsync(URLBase + "ContactSkillExpertise/Contact/" + Int32.Parse(ContactId)))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        List<ContactSkillExpertise> temp = JsonConvert.DeserializeObject<List<ContactSkillExpertise>>(apiResponse);
                        if (temp != null)
                        {
                            foreach (var cse in temp)
                            {
                                skillList.Add(cse.Skill);
                            }
                        }
                        else
                        {
                            ViewBag.MessageError = "No skill to update";
                            return View(cseVM);
                        }

                    }
                    using (var response = await httpClient.GetAsync(URLBase + "Expertise"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        expertiseList = JsonConvert.DeserializeObject<List<Expertise>>(apiResponse);
                    }

                }
                cseVM.ContactList = new SelectList(contactList, "Id", "Firstname");
                cseVM.SkillList = new SelectList(skillList, "Id", "Name");
                cseVM.ExpertiseList = new SelectList(expertiseList, "Id", "Name");
                return View(cseVM);
            }


            [HttpPost]
            public async Task<IActionResult> Delete(ContactSkillExpertiseViewModel cseModelView)
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        var cse = new ContactSkillExpertise() { ContactId = int.Parse(cseModelView.ContactId), SkillId = int.Parse(cseModelView.SkillId), ExpertiseId = int.Parse(cseModelView.ExpertiseId) };
                        var JWToken = HttpContext.Session.GetString("token");
                        if (string.IsNullOrEmpty(JWToken))
                        {
                            ViewBag.MessageError = "You must be authenticate";
                            return View(cseModelView);
                        }

                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", JWToken);

                        var cseId = 0;
                        //Get cseId
                        using (var responseId = await client.GetAsync(URLBase + "ContactSkillExpertise/Contact/Skill/" + cse.ContactId + "/" + cse.SkillId))
                        {
                            string apiResponse = await responseId.Content.ReadAsStringAsync();

                            cseId = JsonConvert.DeserializeObject<int>(apiResponse);
                        }

                        var response = await client.DeleteAsync(URLBase + "ContactSkillExpertise/" + cseId);
                        var result = response.IsSuccessStatusCode;
                        if (result)
                        {
                            return RedirectToAction("Show", "CSE");
                        }
                        ViewBag.MessageError = response.ReasonPhrase;
                        return View(cseModelView);

                    }

                }
                return View(cseModelView);
            }



    }
}
