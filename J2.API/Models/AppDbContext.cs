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

        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseSubCategory> ExpenseSubCategories { get; set; }
        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Seeding data

            Guid defaultUserId = Guid.NewGuid();
            Guid defaultFamilyId = Guid.NewGuid();

            var defaultUser = new
            {
                Id = defaultUserId,
                Email = "s.m.jebelli@gmail.com",
                FirstName = "admin",
                LastName = "admin",
                MobileNumber = "09355270270",
                UserName = "admin",
                FamilyId = defaultFamilyId,
                CreatedBy = defaultUserId,
                CreatedOn = DateTime.Now
            };
            var user = new FamilyMember()
            {
                FamilyId = defaultUser.FamilyId,               
                Id = defaultUserId,
            };

            var defaultFamily = new 
            {
                Id = defaultFamilyId,
                FamilyName = "Test",
               // Users = new List<User>() { user},
                CreatedBy = defaultUserId,
                CreatedOn = DateTime.Now
            };

            modelBuilder.Entity<Family>().HasData(defaultFamily);
            modelBuilder.Entity<FamilyMember>().HasData(defaultUser);

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
