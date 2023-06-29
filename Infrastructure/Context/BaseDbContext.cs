using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class BaseDbContext : IdentityDbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }

    }


}
