using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Domain.Entities;

namespace Villa.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Vila> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vila>().HasData(
                new Vila { 
                Id=1,
                Name="Tiger palace",
                Description="Bhairuwa,AirPort,Nepal",
                ImageUrl= "https://cf.bstatic.com/xdata/images/hotel/max1024x768/615097616.jpg?k=d3e34f137ebfb9de984a067006063753fb96a633cc96db9e5691f05df03e67d9&o=&hp=1",
                Occupancy=4,
                Price=200,
                Sqft=500
                },
                 new Vila
                 {
                     Id = 2,
                     Name = "darbar Palace",
                     Description = "Kathmandu,Nepal",
                     ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/615097642.jpg?k=dab2a4497b657504196a17c8cb8baaa08fec94ce43abe9dffa8795ac829b4913&o=&hp=1",
                     Occupancy = 4,
                     Price = 300,
                     Sqft = 600
                 },
                  new Vila
                  {
                      Id = 3,
                      Name = "Manigram Palace",
                      Description = "manigram,Butwal,Nepal",
                      ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/16/73/41/a5/lobby-reception.jpg?w=700&h=-1&s=1",
                      Occupancy = 5,
                      Price = 100,
                      Sqft = 400
                  }
                );
        }
    }
}
