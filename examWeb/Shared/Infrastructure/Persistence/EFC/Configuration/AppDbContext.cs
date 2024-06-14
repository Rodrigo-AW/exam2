using System.Text.RegularExpressions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using examWeb.Inventories.Domain.Model.Aggregates;
using examWeb.Inventories.Domain.Model.Entities;
using examWeb.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace examWeb.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public DbSet<Groupsa> Groups { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuración de la entidad Group
            builder.Entity<Groupsa>(entity =>
            {
                entity.ToTable("Groups");
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Id se generará automáticamente
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                // Seed Data
                entity.HasData(
                    new Groupsa
                    {
                        Id = 1,
                        Name = "Forestry"
                    },
                    new Groupsa
                    {
                        Id = 2,
                        Name = "Farming"
                    },
                    new Groupsa
                    {
                        Id = 3,
                        Name = "Livestock"
                    }
                );
            });


                //BORRAR TODAS LAS TABLAS ANTES DE CREAR NUEVAS, PARA QUE SE ACTUALICE
            // Configuración de la entidad Farm

            /*

            builder.Entity<Farm>().ToTable("Farms");
            builder.Entity<Farm>().HasKey(f => f.Id);
            builder.Entity<Farm>().Property(f => f.Location);
            builder.Entity<Farm>().Property(f => f.Type);
            builder.Entity<Farm>().Property(f => f.Infrastructure);
            builder.Entity<Farm>().Property(f => f.Certificate);
            builder.Entity<Farm>().Property(f => f.Product);
            builder.UseSnakeCaseNamingConvention();

*/
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(c => c.Id);
            builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Category>().Property(c => c.Description).HasMaxLength(360);
            builder.Entity<Category>().Property(c => c.ReferenceImageUrl).HasMaxLength(500);
            builder.Entity<Category>().HasOne(c => c.Group).WithMany().HasForeignKey(c => c.GroupId);
            builder.UseSnakeCaseNamingConvention();
    
        }
    }
}