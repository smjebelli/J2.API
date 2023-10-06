using J2.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace J2.API.Configurations
{
    public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            //builder.HasData(
            //    new { Name = "جاری", Description = "هزینه های جاری مانند خوارک و جابجایی و ...", CreatedBy = Guid.Empty, CreatedOn = DateTime.Now },
            //    new { Name = "درمانی و بیمه", Description = "پزشکی و بهداشتی و بیمه", CreatedBy = Guid.Empty, CreatedOn = DateTime.Now },
            //    new { Name = "خودرو", Description = "تعمیر، سرویس و نگهداری", CreatedBy = Guid.Empty, CreatedOn = DateTime.Now },
            //    new { Name = "تفریح و سلامتی", Description = "سفر، تفریح، ورزش و مرتبط با آن", CreatedBy = Guid.Empty, CreatedOn = DateTime.Now },
            //    new { Name = "خانه و نگهداری آن", Description = "اجاره، تعمیرات، خرجهای اساسی منزل", CreatedBy = Guid.Empty, CreatedOn = DateTime.Now },
            //    new { Name = "کودکان", Description = "هزینه های تحصیل، لوازم التحریر، اسباب بازی و ... کودکان", CreatedBy = Guid.Empty, CreatedOn = DateTime.Now });


        }
    }
}
