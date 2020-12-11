using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyContacts.Data.Configuration
{
    /// <summary>
    /// Class used to defined the specificities of the User's table
    /// </summary>
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        // --- Methods ---
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder
                    .HasKey(u => u.Id);
                builder
                    .Property(u => u.Id)
                    .UseIdentityColumn();
                builder
                    .Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                builder
                    .HasOne(u => u.Contact)
                    .WithOne(c => c.User);
                builder
                    .ToTable("Users");
            }
    }
}
