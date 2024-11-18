using Microsoft.EntityFrameworkCore;
using WebAPIproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebAPIproject.Migrations;

namespace WebAPIproject.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; } 

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanPayment> LoanPayments { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BankerInfo> BankerInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Account entity
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");

            // Branch entity
            modelBuilder.Entity<Branch>()
                .Property(b => b.Assets)
                .HasColumnType("decimal(18,2)");

            // CreditCard entity
            modelBuilder.Entity<CreditCard>()
                .Property(c => c.CardLimit)
                .HasColumnType("decimal(18,2)");

            // Loan entity
            modelBuilder.Entity<Loan>()
                .Property(l => l.IssuedAmount)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Loan>()
                .Property(l => l.RemainingAmount)
                .HasColumnType("decimal(18,2)");

            // LoanPayment entity
            modelBuilder.Entity<LoanPayment>()
                .Property(lp => lp.Amount)
                .HasColumnType("decimal(18,2)");

            // Transaction entity
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            // Configure relationships if needed

            base.OnModelCreating(modelBuilder);
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name="Admin",
                    NormalizedName="ADMIN"
                },

                new IdentityRole{
                    Name="User",
                    NormalizedName="USER"
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
        
    }
}
