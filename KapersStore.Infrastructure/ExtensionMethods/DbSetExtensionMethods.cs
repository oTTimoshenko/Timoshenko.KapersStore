using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.Infrastructure.ExtensionMethods
{
    public static class DbSetExtensionMethods
    {
        public static Entity Get<Entity>(this DbSet<Entity> entities, int id) where Entity: class
        {
            var entity = entities.Find(id);

            if (entity is null)
                throw new ArgumentException($"{typeof(Entity).Name} with id specified was not found", nameof(id));

            return entity;
        }
            
    }
}
