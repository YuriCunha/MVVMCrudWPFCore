using Microsoft.EntityFrameworkCore;
using System;

namespace CrudWpfCore.Data
{
    public class SongDbContext : DbContext
    {
        public SongDbContext() : base()
        {
            Database.EnsureCreated();
        }
    
        public DbSet<SongDb> Songs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CrudSongs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                );
            
        }
    }
}
