using DataLayer.EF.config;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.EF
{
    public class ClientContext : DbContext
    {
        public DbSet<User> Users;
        public DbSet<Rol> Roles;
        public DbSet<Roles> RolesDeUsuarios;

        public ClientContext(DbContextOptions<ClientContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new RolesConfig());
        }
    }
}
