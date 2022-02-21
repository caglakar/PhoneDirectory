using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Services.Contact.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.DbContexts
{
    public class ContactDbDontext : DbContext
    {
        public ContactDbDontext(DbContextOptions<ContactDbDontext> options)
           : base(options)
    {
    }

    public DbSet<Entities.Contact> Contacts { get; set; }
    public DbSet<ContactDetail> ContactDetails { get; set; }
 //   public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Contact>()
                .Property(p => p.IsActive)
                .HasDefaultValue(true);
        }
    }
}
