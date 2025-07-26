using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookEF
{
    public class PhoneBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } //tells EF to make a table named Contacts.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use SQLServer database for the phone book
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-1UGATPN9;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Packet Size=4096;Application Name=""SQL Server Management Studio"";Command Timeout=0");
        }

    }
}
