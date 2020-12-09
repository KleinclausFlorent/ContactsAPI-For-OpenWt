using Microsoft.EntityFrameworkCore;
using MyContacts.Core.Models;
using MyContacts.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyContacts.Data
{
    public class MyContactsDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Expertise> Expertises {get; set;}

        public DbSet<ContactSkillExpertise> ContactSkillExpertises { get; set; }

        public MyContactsDbContext(DbContextOptions<MyContactsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder
                .ApplyConfiguration(new SkillConfiguration());
            builder
                .ApplyConfiguration(new ContactConfiguration());
            builder
                .ApplyConfiguration(new UserConfiguration());
            builder
                .ApplyConfiguration(new ExpertiseConfiguration());
            builder
                .ApplyConfiguration(new ContactSkillExpertiseConfiguration());
        }
    }
}
