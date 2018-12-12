using Microsoft.EntityFrameworkCore;
using SelfControlPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfControlPrototype.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<Notification> Notification { get; set; }
    }
}
