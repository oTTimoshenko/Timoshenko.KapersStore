using KapersStore.Domain.UserManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KapersStore.DataAccess
{
    public interface IDataContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
