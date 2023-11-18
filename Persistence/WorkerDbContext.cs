using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;

namespace Persistence
{
    public class WorkerDbContext : DbContext, IWorkerDbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public WorkerDbContext(DbContextOptions<WorkerDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
