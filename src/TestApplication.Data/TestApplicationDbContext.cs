using Microsoft.EntityFrameworkCore;
using TestApplication.Data.Entities;

namespace TestApplication.Data
{
    public class TestApplicationDbContext : DbContext
    {
        public TestApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentState> PaymentStates { get; set; }
    }
}
