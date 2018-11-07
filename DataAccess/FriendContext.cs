using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class FriendContext : DbContext
    {
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<User> Users { get; set; }

        public FriendContext() : base("name=FriendContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agenda>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<User>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Agenda>().HasMany(x => x.Contacts).WithMany();
            
        }
    }
}
