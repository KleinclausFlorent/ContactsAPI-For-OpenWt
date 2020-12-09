using AutoMapper;
using MyContacts.API.Resources;
using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyContacts.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain(base de données) vers Resource
            CreateMap<Contact, ContactResource>();
            CreateMap<Skill, SkillResource>();
            CreateMap<Skill, SaveSkillResource>();
            CreateMap<Contact, SaveContactResource>();
            CreateMap<User, UserResource>();
            CreateMap<Expertise, ExpertiseResource>();
            CreateMap<Expertise, SaveExpertiseResource>();
            CreateMap<ContactSkillExpertise, ContactSkillExpertiseResource>();
            CreateMap<ContactSkillExpertise, SaveContactSkillExpertiseResource>();

            // Resources vers domain ou bdd
            CreateMap<ContactResource, Contact>();
            CreateMap<SkillResource, Skill>();
            CreateMap<SaveSkillResource, Skill>();
            CreateMap<SaveContactResource, Contact>();
            CreateMap<UserResource, User>();
            CreateMap<ExpertiseResource, Expertise>();
            CreateMap<SaveExpertiseResource, Expertise>();
            CreateMap<ContactSkillExpertiseResource, ContactSkillExpertise>();
            CreateMap<SaveContactSkillExpertiseResource, ContactSkillExpertise>();
        }
    }
}
