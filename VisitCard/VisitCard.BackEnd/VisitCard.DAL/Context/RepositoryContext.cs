using Microsoft.EntityFrameworkCore;
using VisitCard.DAL.Models;

namespace VisitCard.DAL.Context
{
    public sealed class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        private DbSet<Card> Cards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}