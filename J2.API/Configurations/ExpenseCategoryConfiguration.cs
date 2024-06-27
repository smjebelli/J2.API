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
            builder.HasData(
                new
                {
                    Id = 1,
                    Name = "جاری",
                    Description = "هزینه های جاری مانند خوارک و جابجایی و ...",
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now
                },
                new
                {
                    Id = 2,
                    Name = "درمانی و بیمه",
                    Description = "پزشکی و بهداشتی و بیمه",
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now
                },
                new
                {
                    Id = 3,
                    Name = "خودرو",
                    Description = "تعمیر، سرویس و نگهداری",
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now
                },
                new
                {
                    Id = 4,
                    Name = "تفریح و سلامتی",
                    Description = "سفر، تفریح، ورزش و مرتبط با آن",
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now
                },
                new
                {
                    Id = 5,
                    Name = "خانه و نگهداری آن",
                    Description = "اجاره، تعمیرات، خرجهای اساسی منزل",
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now
                },
                new
                {
                    Id = 6,
                    Name = "کودکان",
                    Description = "هزینه های تحصیل، لوازم التحریر، اسباب بازی و ... کودکان",
                    CreatedBy = Guid.Empty,
                    CreatedOn = DateTime.Now
                });


        }
    }
}
