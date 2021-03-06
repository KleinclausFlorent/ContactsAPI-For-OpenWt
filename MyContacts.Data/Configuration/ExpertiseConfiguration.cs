﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyContacts.Data.Configuration
{
    /// <summary>
    /// Class used to defined the specificities of the Contact's table
    /// </summary>
    class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
    {
        // --- Methods ---
            public void Configure(EntityTypeBuilder<Expertise> builder)
            {
                builder
                    .HasKey(e => e.Id);
                builder
                    .Property(s => s.Id)
                    .UseIdentityColumn();
                builder
                    .Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                builder
                    .ToTable("Expertises");
            }
    }
}
