using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyContacts.Data.Configuration
{
    /// <summary>
    /// Class used to defined the specificities of the ContactSkillExpertise's table
    /// </summary>
    class ContactSkillExpertiseConfiguration : IEntityTypeConfiguration<ContactSkillExpertise>
    {
        // --- Methods ---
            public void Configure(EntityTypeBuilder<ContactSkillExpertise> builder)
            {
                builder
                    .HasKey(x => x.Id);
                builder
                    .Property(x => x.Id)
                    .UseIdentityColumn();
                builder
                    .HasOne(x => x.Contact)
                    .WithMany(c => c.ContactSkillExpertises)
                    .HasForeignKey(x => x.ContactId);
                builder
                    .HasOne(x => x.Skill)
                    .WithMany(s => s.ContactSkillExpertises)
                    .HasForeignKey(x => x.SkillId);
                builder
                    .HasOne(x => x.Expertise)
                    .WithMany(e => e.ContactSkillExpertises)
                    .HasForeignKey(x => x.ExpertiseId);
                builder
                    .ToTable("ContactSkillExpertises");
            }
    }
}
