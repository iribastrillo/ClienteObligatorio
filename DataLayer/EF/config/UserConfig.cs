using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EF.config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(user => user.Username)
                .Property(username => username.Value)
                .HasColumnName("Username");
            builder.OwnsOne(user => user.Password)
                .Property(password => password.Value)
                .HasColumnName("Password");
            builder.OwnsOne(user => user.Email)
                .Property(email => email.Value)
                .HasColumnName("Email");
            builder.ToTable("Users");
        }
    }
}
