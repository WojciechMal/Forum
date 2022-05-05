using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option):base(option)
        {
            //Database.EnsureCreated();
        }
        public AppDbContext()
        {

        }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Topic> Topics { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            
            
            modelBuilder.Entity<Topic>()
                .HasOne<Segment>(t => t.Segment)
                .WithMany(u => u.Topics)
                
                .HasForeignKey(t => t.SegmentId);

            


        }

    }
}
