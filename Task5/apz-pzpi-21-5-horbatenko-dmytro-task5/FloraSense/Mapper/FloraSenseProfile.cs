using AutoMapper;
using FloraSense.Entities.PlantDataItems;
using FloraSense.Entities.Plants;
using FloraSense.Entities.PlantTypes;

namespace VetAutoMobile.Mapper
{
    public class FloraSenseProfile : Profile
    {
        public FloraSenseProfile()
        {
            CreateMap<PlantModel, PlantModelId>().ReverseMap();
            CreateMap<PlantModel, UpdatePlantModel>().ReverseMap();
            CreateMap<PlantModel, CreatePlantModel>().ReverseMap();

            CreateMap<PlantTypeModel, PlantTypeModelId>().ReverseMap();
            CreateMap<PlantTypeModel, UpdatePlantTypeModel>().ReverseMap();
            CreateMap<PlantTypeModel, CreatePlantTypeModel>().ReverseMap();

            CreateMap<PlantDataModel, PlantDataModelId>().ReverseMap();
            CreateMap<PlantDataModel, UpdatePlantDataModel>().ReverseMap();
            CreateMap<PlantDataModel, CreatePlantDataModel>().ReverseMap();
        }
    }
}
