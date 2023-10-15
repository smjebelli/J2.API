using J2.API.Configurations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace J2.API.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> FamilyMembers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseSubCategory> ExpenseSubCategories { get; set; }
        public DbSet<Family> Families { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new UserRoleConfiguration())
                .ApplyConfiguration(new ExpenseCategoryConfiguration());



            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").IsRequired(true);
                    modelBuilder.Entity(entityType.Name).Property<Guid>("CreatedBy").IsRequired(true);
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("LastModifiedOn").IsRequired(false);
                    modelBuilder.Entity(entityType.Name).Property<Guid?>("LastModifiedBy").IsRequired(false);

                }
            }
            //Seeding data

            //Guid defaultUserId = Guid.NewGuid();
            //Guid defaultFamilyId = Guid.NewGuid();

            //var defaultUser = new
            //{
            //    Id = defaultUserId,
            //    Email = "s.m.jebelli@gmail.com",
            //    FirstName = "admin",
            //    LastName = "admin",
            //    MobileNumber = "09355270270",
            //    UserName = "admin",
            //    FamilyId = defaultFamilyId,
            //    CreatedBy = defaultUserId,
            //    CreatedOn = DateTime.Now
            //};
            //var user = new FamilyMember()
            //{
            //    FamilyId = defaultUser.FamilyId,               
            //    Id = defaultUserId,
            //};

            //var defaultFamily = new 
            //{
            //    Id = defaultFamilyId,
            //    FamilyName = "Test",
            //   // Users = new List<User>() { user},
            //    CreatedBy = defaultUserId,
            //    CreatedOn = DateTime.Now
            //};

            //modelBuilder.Entity<Family>().HasData(defaultFamily);
            //modelBuilder.Entity<FamilyMember>().HasData(defaultUser);


        }
        public override int SaveChanges()
        {
            HandleInsertUpdateTime();
            return base.SaveChanges();
        }

        private void HandleInsertUpdateTime()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity.GetType().GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("LastModifiedOn").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedOn").CurrentValue = DateTime.Now;
                    }
                }
            }
        }

        private void HandleUserId(string userid)
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity.GetType().GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("LastModifiedBy").CurrentValue = new Guid(userid);
                    }

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedBy").CurrentValue = new Guid(userid);
                    }
                }
            }
        }

        public int SaveChanges(string userId)
        {
            HandleInsertUpdateTime();
            HandleUserId(userId);
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(string userId)
        {
            HandleInsertUpdateTime();
            HandleUserId(userId);
            return await base.SaveChangesAsync();
        }



        #region ______ Methods ______

        public async Task<int> SaveChangesAsync()
        {
            HandleInsertUpdateTime();
            return await base.SaveChangesAsync();
        }


        public bool AddEntity<TEntity>(TEntity entity)
        {
            base.Entry(entity).State = EntityState.Added;
            return true;
        }

        public bool AddEntityAsync<TEntity>(TEntity entity)
        {
            AddEntityAsync(entity);

            return true;
        }

        public int Rollback()
        {

            return 0;
        }

        public void UpdateEntity<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void RemoveEntity<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Deleted;
        }

        #endregion

    }
}
