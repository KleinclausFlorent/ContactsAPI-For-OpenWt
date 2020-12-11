using Microsoft.EntityFrameworkCore;
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
    class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        // --- Methods ---
            public void Configure(EntityTypeBuilder<Contact> builder)
            {
                builder
                    .HasKey(c => c.Id);
                builder
                    .Property(c => c.Id)
                    .UseIdentityColumn();
                builder
                    .Property(c => c.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);
                builder
                    .Property(c => c.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);
                builder
                    .Property(c => c.Fullname)
                    .IsRequired()
                    .HasMaxLength(200);
                builder
                    .Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(200);
                builder
                    .Property(c => c.Adress)
                    .IsRequired()
                    .HasMaxLength(200);
                builder
                    .Property(c => c.Mobile)
                    .IsRequired()
                    .HasMaxLength(20);
                builder
                    .ToTable("Contacts");
            }
    }
}
