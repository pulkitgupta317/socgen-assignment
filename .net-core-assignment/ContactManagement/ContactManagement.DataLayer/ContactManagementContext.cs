using ContactManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagement.DataLayer
{
    public class ContactManagementContext: DbContext
    {
        public ContactManagementContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
