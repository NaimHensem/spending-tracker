using System.Data.Entity;

namespace SpendingTracker.Models
{
    public class SpendingContext : DbContext
    {
        public SpendingContext() : base("DefaultConnection") { }

        public DbSet<SpendingRecord> SpendingRecords { get; set; }
    }
}
