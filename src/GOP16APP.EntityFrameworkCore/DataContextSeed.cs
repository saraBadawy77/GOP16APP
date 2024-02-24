using GOP16APP.Entities;
using GOP16APP.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GOP16APP
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(GOP16APPDbContext context)
        {
            if (!context.organizationCategories.Any())
            {

                var CategoriesData = File.ReadAllText("C:/Users/sara/Desktop/Innovascop/GOP16APP/GOP16APP/aspnet-core/src/GOP16APP.EntityFrameworkCore/DataSeed/OrganizationCategoryData.json");

                var Categories = JsonSerializer.Deserialize<List<OrganizationCategory>>(CategoriesData);
                if (Categories is not null && Categories.Count > 0)
                {
                    foreach (var Categorie in Categories)
                        await context.Set<OrganizationCategory>().AddAsync(Categorie);
                    await context.SaveChangesAsync();
                }


            }

            if (!context.qualifications.Any())
            {

                var qualificationsData = File.ReadAllText("C:/Users/sara/Desktop/Innovascop/GOP16APP/GOP16APP/aspnet-core/src/GOP16APP.EntityFrameworkCore/DataSeed/QualificationData.json");

                var qualifications = JsonSerializer.Deserialize<List<Qualification>>(qualificationsData);
                if (qualifications is not null && qualifications.Count > 0)
                {
                    foreach (var qualification in qualifications)
                        await context.Set<Qualification>().AddAsync(qualification);
                    await context.SaveChangesAsync();
                }


            }

        }
    } 
}
