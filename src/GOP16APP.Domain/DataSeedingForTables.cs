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
      //  private readonly IWebHostEnvironment _webHostEnvironment;
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
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var dataSeedFolderPath = Path.Combine(rootPath,"DataSeed");
            var organizationCategoryFilePath = Path.Combine(dataSeedFolderPath, "OrganizationCategoryData.json");
            var qualificationFilePath = Path.Combine(dataSeedFolderPath, "QualificationData.json");
            var sectorFilePath = Path.Combine(dataSeedFolderPath, "SectorData.json");
            var levelRepresentationFilePath = Path.Combine(dataSeedFolderPath, "LevelRepresentationData.json");


            using (_currentTenant.Change(context?.TenantId))
            {

                await SeedOrganizationCategoryIfEmpty(organizationCategoryFilePath);
                await SeedQualificationIfEmpty(qualificationFilePath);
                await SeedSectorIfEmpty(sectorFilePath);
                await SeedLevelRepresentationIfEmpty(levelRepresentationFilePath);
              

            }  
        }



        //SeedOrganizationCategoryIfEmpty
        private async Task SeedOrganizationCategoryIfEmpty(string filePath)
        {
            
            if (await _Categoryrepository.GetCountAsync() > 0)
            {
                return;
            }

            var categoriesData = File.ReadAllText(filePath);
            var Categories = JsonSerializer.Deserialize<List<OrganizationCategory>>(categoriesData);
            if (Categories is not null && Categories.Count > 0)
            {
                foreach (var Categorie in Categories)
                {
                    await _Categoryrepository.InsertAsync(Categorie);
                }
            }


        }



        //SeedQualificationIfEmpty

        private async Task SeedQualificationIfEmpty(string filePath)
        {
            if (await _qualificationrepository.GetCountAsync() > 0)
            {
                return;
            }

            var qualificationsData = File.ReadAllText(filePath);
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

        private async Task SeedSectorIfEmpty(string filePath)
        {
            if (await _sectorrepository.GetCountAsync() > 0)
            {
                return;
            }

            var SectorData = File.ReadAllText(filePath);
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

        private async Task SeedLevelRepresentationIfEmpty(string filePath)
        {
            if (await _levelrepository.GetCountAsync() > 0)
            {
                return;
            }

            var LevelData = File.ReadAllText(filePath);
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
