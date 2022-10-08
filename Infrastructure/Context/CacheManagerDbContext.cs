using Domain.Constants;
using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static Domain.Constants.Constants;

namespace Infrastructure.Context
{
    public class CacheManagerDbContext : DbContext
    {
        public CacheManagerDbContext(DbContextOptions<CacheManagerDbContext> options) : base(options) { }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberShipPlan> MemberShipPlans { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfigurations());
            modelBuilder.ApplyConfiguration(new CommentConfigurations());
            modelBuilder.ApplyConfiguration(new ImageConfigurations());
            modelBuilder.ApplyConfiguration(new MemberConfigurations());
            modelBuilder.ApplyConfiguration(new MemberShipPlansConfigurations());
            modelBuilder.ApplyConfiguration(new NewsConfigurations());
            modelBuilder.ApplyConfiguration(new PropertyConfigurations());
            modelBuilder.ApplyConfiguration(new TagConfigurations());
            base.OnModelCreating(modelBuilder);
        }
    }
}
