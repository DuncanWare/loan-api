using Microsoft.EntityFrameworkCore;

namespace YouLendApi.Models
{
    public class LoanContext : DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options)
            : base(options)
        {
        }

        public DbSet<LoanFile> LoanFiles { get; set; }
    }
}