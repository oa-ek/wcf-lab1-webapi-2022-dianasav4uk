using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Server.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Server.Core
{
    public static class PharmacyDbContextExtension
    {
        public static void Seed1(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategoryMedicaments>()
            .HasKey(bc => new { bc.MedicamentsId, bc.SubCategoryId });
            modelBuilder.Entity<SubCategoryMedicaments>()
                .HasOne(bc => bc.Medicaments)
                .WithMany(b => b.SubCategories)
                .HasForeignKey(bc => bc.MedicamentsId);
            modelBuilder.Entity<SubCategoryMedicaments>()
                .HasOne(bc => bc.SubCategory)
                .WithMany(c => c.Medicaments)
                .HasForeignKey(bc => bc.SubCategoryId);
        }

            /*modelBuilder.Entity<User>()
           .HasOne(u => u.ShoppingCart)
           .WithOne(p => p.User)
           .HasForeignKey<ShopCart>(p => p.UserId);

        }
        /*public static void Seed1(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Medicaments>()
                        .HasMany<SubCategory>(s => s.SubCategory)
                        .WithMany(c => c.Medicaments)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("MedicamentRefId");
                            cs.MapRightKey("SubCategoryRefId");
                            cs.ToTable("SubCategoryMedicaments");
                        });
        modelBuilder.Entity<SubCategoryMedicaments>()
        .HasKey(bc => new { bc.MedicamentsId, bc.SubCategoryId });
            modelBuilder.Entity<SubCategoryMedicaments>()
                .HasOne(bc => bc.Medicaments)
                .WithMany(b => b.SubCategoryMedicaments)
                .HasForeignKey(bc => bc.MedicamentsId);
            modelBuilder.Entity<SubCategoryMedicaments>()
                .HasOne(bc => bc.SubCategory)
                .WithMany(c => c.SubCategoryMedicaments)
                .HasForeignKey(bc => bc.SubCategoryId);

        }*/

        public static void Seed(this ModelBuilder builder)
        {
            
            var catalog1 = new Catalog
            {
                Id = 1,
                Name = "Лікарські засоби",
            };
            var catalog2 = new Catalog
            {
                Id = 2,
                Name = "Краса та догляд",
            };
            builder.Entity<Catalog>().HasData(catalog1, catalog2);

            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Застуда і грип",
                    Image = "img\\catalogue\\flu.jpg",
                },
                new Category
                {
                    Id = 2,
                    Name = "Серцево-судинна система",
                    Image = "img\\catalogue\\heart.jpg",
                },
                new Category
                {
                    Id = 3,
                    Name = "Кровотворення та кров",
                    Image = "img\\catalogue\\blood.jpg",
                },
                new Category
                {
                    Id = 4,
                    Name = "Противірусні",
                    Image = "img\\catalogue\\8000131.jpg",
                }
                );

            var subCategory1 = new SubCategory
            {
                SubCategoryId = 1,
                Name = "Від кашлю", //1
            };
            var subCategory2 = new SubCategory
            {
                SubCategoryId = 2,
                Name = "Ліки від грипу", //1
            };
            var subCategory3 = new SubCategory
            {
                SubCategoryId = 3,
                Name = "Від підвищеного тиску", //2
            };
            builder.Entity<SubCategory>().HasData(subCategory1, subCategory2, subCategory3);

           


            var medicaments = new Medicaments
            {
                MedicamentsId = 1,
                Name = "Синупрет табл. в/о №50",
                Code = "4882",
                Dosage = "",
                Price = (float)125.62,
                ReleaseForm = "таблетки для внутрішнього застосування",
                Image = "img\\catalogue\\sinupret.jpg",
            };
            var medicaments1 = new Medicaments
            {
                MedicamentsId = 2,
                Name = "Синупрет",
                Code = "2345",
                Dosage = "12",
                Price = (float)89.75,
                ReleaseForm = "таблетки для внутрішнього застосування",
                Image = "img\\catalogue\\sinupret.jpg",
            };
            var medicaments2 = new Medicaments
            {
                MedicamentsId = 3,
                Name = "Мілістан мультисимптомний каплети, в/о блістер №12",
                Code = "2434",
                Dosage = "12",
                Price = (float)175,
                ReleaseForm = "таблетки для внутрішнього застосування",
                Image = "img\\catalogue\\milistan.jpg",
            };
            var medicaments3 = new Medicaments
            {
                MedicamentsId = 4,
                Name = "Каптопрес 12,5-Дарниця",
                Code = "2487",
                Dosage = "15",
                Price = (float)89.75,
                ReleaseForm = "таблетки",
                Image = "img\\catalogue\\captopres.jpg",
            };
            var medicaments4 = new Medicaments
            {
                MedicamentsId =5,
                Name = "Стоптусин-Тева",
                Code = "4715",
                Dosage = "16",
                Price = (float)89.75,
                ReleaseForm = "таблетки",
                Image = "img\\catalogue\\stoptys.jpg",
            };
            var SubCategoryMedicaments = new SubCategoryMedicaments
            {
                MedicamentsId = medicaments.MedicamentsId,
                SubCategoryId = subCategory1.SubCategoryId,
                Medicaments = null,
                SubCategory = null,              
            };
            var SubCategoryMedicaments1 = new SubCategoryMedicaments
            {
                MedicamentsId = medicaments1.MedicamentsId,
                SubCategoryId = subCategory1.SubCategoryId,
                Medicaments = null,
                SubCategory = null,
            };
            var SubCategoryMedicaments2 = new SubCategoryMedicaments
            {
                MedicamentsId = medicaments2.MedicamentsId,
                SubCategoryId = subCategory2.SubCategoryId,
                Medicaments = null,
                SubCategory = null,
            };
            var SubCategoryMedicaments3 = new SubCategoryMedicaments
            {
                MedicamentsId = medicaments3.MedicamentsId,
                SubCategoryId = subCategory3.SubCategoryId,
                Medicaments = null,
                SubCategory = null,
            };
            var SubCategoryMedicaments4 = new SubCategoryMedicaments
            {
                MedicamentsId = medicaments4.MedicamentsId,
                SubCategoryId = subCategory1.SubCategoryId,
                Medicaments = null,
                SubCategory = null,
            };
            //medicaments.SubCategories = new List<SubCategoryMedicaments> { SubCategoryMedicaments };
            builder.Entity<Medicaments>().HasData(medicaments,medicaments1,medicaments2,medicaments3,medicaments4);
            builder.Entity<SubCategoryMedicaments>().HasData(SubCategoryMedicaments,SubCategoryMedicaments1, SubCategoryMedicaments2,SubCategoryMedicaments3,SubCategoryMedicaments4);

        }
    }
}
