using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectBackendDevelopment.Configuration;
using ProjectBackendDevelopment.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBackendDevelopment.Data
{
    public interface IOutlawContext
    {
        DbSet<Outlaw> Outlaws { get; set; }
        DbSet<DeathCause> DeathCauses { get; set; }
        DbSet<Gang> Gangs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
    }

    public class OutlawContext : DbContext, IOutlawContext
    {
        public DbSet<Outlaw> Outlaws { get; set; }
        public DbSet<DeathCause> DeathCauses { get; set; }
        public DbSet<Gang> Gangs { get; set; }

        private ConnectionStrings _connectionStrings;
        public OutlawContext(DbContextOptions<OutlawContext> options, IOptions<ConnectionStrings> connectionstrings)
        {
            _connectionStrings = connectionstrings.Value;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionStrings.SQL);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GangOutlaw>()
                .HasKey(cs => new { cs.GangId, cs.OutlawId});

            modelBuilder.Entity<DeathCause>().HasData(new DeathCause() {
                 DeathCauseId = Guid.NewGuid(), Description = "Gunshot wound", 
                 DeathUri = "http://dbpedia.org/resource/Gunshot_wounds" 
                 });
                 
            modelBuilder.Entity<Gang>().HasData(new Gang() {
                 GangId = Guid.NewGuid(), GangName = "Butch Cassidy's Wild Bunch", 
                 GangUri = "http://dbpedia.org/resource/Butch_Cassidy's_Wild_Bunch" 
                 });

            modelBuilder.Entity<Gang>().HasData(new Gang() {
                 GangId = Guid.NewGuid(), GangName = "James–Younger Gang", 
                 GangUri = "https://dbpedia.org/resource/James-Younger_Gang" 
                 });


        }

    }
}
