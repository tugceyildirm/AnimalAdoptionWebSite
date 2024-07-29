using EntityLayer.Concrete;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.Models;

namespace DataAccessLayer.Concrete
{
   public class Context: DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PetShop> PetShops { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get;set; }
        public DbSet<Request> Requests { get; set; }
    }
}
