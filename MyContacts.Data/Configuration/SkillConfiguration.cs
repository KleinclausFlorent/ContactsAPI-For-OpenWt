using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyContacts.Data.Configuration
{
    /// <summary>
    /// Class used to defined the specificities of the Skill's table
    /// </summary>
    class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        // --- Methods ---
            public void Configure(EntityTypeBuilder<Skill> builder)
            {
                builder
                    .HasKey(s => s.Id);
                builder
                    .Property(s => s.Id)
                    .UseIdentityColumn();
                builder
                    .Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(50);          
                builder
                    .ToTable("Skills");
            }
    }
}
