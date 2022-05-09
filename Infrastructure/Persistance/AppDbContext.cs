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
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            /*modelBuilder.Entity<Topic>()
                 .OwnsOne(t => t.Segment);*/

            modelBuilder.Entity<Topic>()
                .HasOne<Segment>(t => t.Segment)
                .WithMany(s => s.Topics)
                .HasForeignKey(t => t.SegmentId);
             
            modelBuilder.Entity<Comment>()
                .HasOne<Topic>(c => c.Topic)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TopicId);
                

            //modelBuilder.Entity<Segment>()
            //    .HasMany(s => s.Topics)
            //    .WithOne(t => t.Segment);

            //modelBuilder.Entity<Topic>()
            //.HasOne<Segment>(t => t.Segment)
            //.WithMany(u => u.Topics)
            //.HasForeignKey(t => t.SegmentId);





        }

    }
}
