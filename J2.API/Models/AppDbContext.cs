using Infrastructure.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace J2.API.Models
{
    public class AppDbContext : BaseDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseSubCategory> ExpenseSubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Seeding data

            //Guid orwellId = Guid.NewGuid();
            //Guid AstenId = Guid.NewGuid();
            //Guid AdminGuid = Guid.NewGuid();

            //var adminUser  = new User() { Id = AdminGuid, UserName = "admin" ,
            //    Email="admin@example.com", FirstName="admin",
            //    LastName = "admin", MembershipNumber= "1"
            //,PhoneNumber ="1213"};
            //var orwellAuthor = new { Id = orwellId, FirstName = "جورج", LastName = "اورول", CreatedOn = DateTime.Now, CreatedBy = AdminGuid };

            //modelBuilder.Entity<User>().HasData(adminUser);

            //modelBuilder.Entity<Author>().HasData(orwellAuthor);
            //modelBuilder.Entity<Author>().HasData(new { Id = AstenId, FirstName = "جین", LastName = "آستن", CreatedOn = DateTime.Now, CreatedBy = AdminGuid });

            //modelBuilder.Entity<Book>().HasData(new
            //{
            //    Id = Guid.NewGuid(),
            //    Title = "غرور و تعصب",
            //    Genre = "رمان",
            //    Isbn = "38298329",
            //    DatePublished = new DateTime(2013, 1, 1),
            //    AuthorId = AstenId,
            //    CreatedOn = DateTime.Now,
            //    CreatedBy = AdminGuid
            //});

            //modelBuilder.Entity<Book>().HasData(new
            //{
            //    Id = Guid.NewGuid(),
            //    Title = "1984",
            //    Genre = "رمان",
            //    Isbn = "12344",
            //    DatePublished = new DateTime(2013, 1, 1),
            //    AuthorId = orwellId,
            //    CreatedOn = DateTime.Now,
            //    CreatedBy = AdminGuid
            //});


            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity.GetType().GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    entry.Property("LastModifiedOn").CurrentValue = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedOn").CurrentValue = DateTime.Now;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
