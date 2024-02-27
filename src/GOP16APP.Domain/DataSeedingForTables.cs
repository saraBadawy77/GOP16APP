using GOP16APP.Entities;
using GOP16APP.Entities.Information1;
using GOP16APP.Entities.Information2;
using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace GOP16APP
{
    public class DataSeedingForTables : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<OrganizationCategory, Guid> _Categoryrepository;
        private readonly IRepository<Qualification, Guid> _qualificationrepository;
        private readonly IRepository<Sector, Guid> _sectorrepository;
        private readonly IRepository<Level, Guid> _levelrepository;
        private readonly ICurrentTenant _currentTenant;

        public DataSeedingForTables(IRepository<OrganizationCategory, Guid> categoryrepository, IRepository<Qualification, Guid> qualificationrepository, ICurrentTenant currentTenant, IRepository<Sector, Guid> sectorrepository, IRepository<Level, Guid> levelrepository)
        {
            _Categoryrepository = categoryrepository;
            _qualificationrepository = qualificationrepository;
            _currentTenant = currentTenant;
            _sectorrepository = sectorrepository;
            _levelrepository = levelrepository;
        }



        public async  Task SeedAsync(DataSeedContext context)
        {
            using (_currentTenant.Change(context?.TenantId))
            {

                await SeedOrganizationCategoryIfEmpty();
                await SeedQualificationIfEmpty();
                await SeedSectorIfEmpty();
                await SeedLevelRepresentationIfEmpty();

            }  
        }



        //SeedOrganizationCategoryIfEmpty
        private async Task SeedOrganizationCategoryIfEmpty()
        {
            if (await _Categoryrepository.GetCountAsync() > 0)
            {
                return;
            }

            var CategoriesData = File.ReadAllText("C:/Users/sara/Desktop/Innovascop/GOP16APP/GOP16APP/aspnet-core/src/GOP16APP.EntityFrameworkCore/DataSeed/OrganizationCategoryData.json");

            var Categories = JsonSerializer.Deserialize<List<OrganizationCategory>>(CategoriesData);
            if (Categories is not null && Categories.Count > 0)
            {
                foreach (var Categorie in Categories)
                {
                    await _Categoryrepository.InsertAsync(Categorie);
                }
            }


        }



        //SeedQualificationIfEmpty

        private async Task SeedQualificationIfEmpty()
        {
            if (await _qualificationrepository.GetCountAsync() > 0)
            {
                return;
            }

            var qualificationsData = File.ReadAllText("C:/Users/sara/Desktop/Innovascop/GOP16APP/GOP16APP/aspnet-core/src/GOP16APP.EntityFrameworkCore/DataSeed/QualificationData.json");

            var qualifications = JsonSerializer.Deserialize<List<Qualification>>(qualificationsData);
            if (qualifications is not null && qualifications.Count > 0)
            {
                foreach (var qualification in qualifications)
                {
                    await _qualificationrepository.InsertAsync(qualification);
                }
            }


        }



        //SeedSectorIfEmpty

        private async Task SeedSectorIfEmpty()
        {
            if (await _sectorrepository.GetCountAsync() > 0)
            {
                return;
            }

            var SectorData = File.ReadAllText("C:/Users/sara/Desktop/Innovascop/GOP16APP/GOP16APP/aspnet-core/src/GOP16APP.EntityFrameworkCore/DataSeed/SectorData.json");

            var Sectors = JsonSerializer.Deserialize<List<Sector>>(SectorData);
            if (Sectors is not null && Sectors.Count > 0)
            {
                foreach (var Sector in Sectors)
                {
                    await _sectorrepository.InsertAsync(Sector);
                }
            }


        }



        //SeedLevelRepresentationIfEmpty

        private async Task SeedLevelRepresentationIfEmpty()
        {
            if (await _levelrepository.GetCountAsync() > 0)
            {
                return;
            }

            var LevelData = File.ReadAllText("C:/Users/sara/Desktop/Innovascop/GOP16APP/GOP16APP/aspnet-core/src/GOP16APP.EntityFrameworkCore/DataSeed/LevelRepresentationData.json");

            var levels = JsonSerializer.Deserialize<List<Level>>(LevelData);
            if (levels is not null && levels.Count > 0)
            {
                foreach (var level in levels)
                {
                    await _levelrepository.InsertAsync(level);
                }
            }


        }



    }
}
