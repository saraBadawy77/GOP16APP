using AutoMapper;
using GOP16APP.Dtos;
using GOP16APP.Dtos.Information1Dto;
using GOP16APP.Dtos.Information2Dto;
using GOP16APP.Dtos.Information3Dto;
using GOP16APP.Entities;
using GOP16APP.Entities.Information1;
using GOP16APP.Entities.Information2;
using GOP16APP.Entities.Information3;
using GOP16APP.Models;
namespace GOP16APP;

public class GOP16APPApplicationAutoMapperProfile : Profile
{
    public GOP16APPApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        //Qualification


        CreateMap<Qualification, QualificationDto>();
        CreateMap<QualificationDto, Qualification>();

        //OrganizationCategory

        CreateMap<OrganizationCategory, OrganizationCategoryDto>();
        CreateMap<OrganizationCategoryDto, OrganizationCategory>();

        //EventUser

        CreateMap<EventUser, EventUserDto>();
        CreateMap<EventUserDto, EventUser>();

        CreateMap<EventUser, EventUserModel>();
        CreateMap<EventUserModel, EventUser>();

        //Sector
        CreateMap<Sector, SectorDto>();
        CreateMap<SectorDto, Sector>();


        

        //EntityInformation

        CreateMap<EntityInformation, EntityInformationDto>();
        CreateMap<EntityInformationDto, EntityInformation>();

        CreateMap<EntityInformation, EntityInformationModel>();
        CreateMap<EntityInformationModel, EntityInformation>();


        //Level
        CreateMap<Level, LevelDto>();
        CreateMap<LevelDto, Level>();

        //RequestedPavilion

        CreateMap<RequestedPavilion, RequestedPavilionDto>();
        CreateMap<RequestedPavilionDto, RequestedPavilion>();

        //ContactDetails

        CreateMap<ContactDetails, ContactDetailsDto>();
        CreateMap<ContactDetailsDto, ContactDetails>();
    }

}
