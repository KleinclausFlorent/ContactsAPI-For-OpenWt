using AutoMapper;
using MyContacts.API.Resources;
using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Mapping
{
    /// <summary>
    /// Class used to define the mappingProfile for automapper
    /// It allows use to transfer data from one class to another easyly
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain(base de données) vers Resource
            CreateMap<Contact, ContactResource>();
            CreateMap<Skill, SkillResource>();
            CreateMap<Skill, SaveSkillResource>();
            CreateMap<Contact, SaveContactResource>();
            CreateMap<Expertise, ExpertiseResource>();
            CreateMap<Expertise, SaveExpertiseResource>();
            CreateMap<ContactSkillExpertise, ContactSkillExpertiseResource>();
            CreateMap<ContactSkillExpertise, SaveContactSkillExpertiseResource>();
            CreateMap<User, UserResource>();
            CreateMap<User, SaveUserResource>();

            // Resources vers domain ou bdd
            CreateMap<ContactResource, Contact>();
            CreateMap<SkillResource, Skill>();
            CreateMap<SaveSkillResource, Skill>();
            CreateMap<SaveContactResource, Contact>();
            CreateMap<ExpertiseResource, Expertise>();
            CreateMap<SaveExpertiseResource, Expertise>();
            CreateMap<ContactSkillExpertiseResource, ContactSkillExpertise>();
            CreateMap<SaveContactSkillExpertiseResource, ContactSkillExpertise>();
            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
