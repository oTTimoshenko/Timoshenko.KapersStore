using KapersStore.Domain.UserManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.DataAccess
{
    public static class EntityMappingConfig
    {
        public static void BuildUser(this ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<User>();

            userEntity.HasKey(entity => entity.Id);

            userEntity.Property(entity => entity.Nickname).HasMaxLength(18);
            userEntity.Property(entity => entity.Nickname).IsRequired();
            
            userEntity.Property(entity => entity.Email).HasMaxLength(50);
            userEntity.Property(entity => entity.Email).IsRequired();

            userEntity.Property(entity => entity.Status).HasMaxLength(20);
            userEntity.Property(entity => entity.Email).IsRequired();
        }
    }
}
