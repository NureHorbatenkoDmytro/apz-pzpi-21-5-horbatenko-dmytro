using AutoMapper;
using FloraSense.Entities.PlantTypes;
using FloraService.ApiLayer.Abstractions;

namespace FloraSense.ViewModels.PageViewModels
{
    public class PlantTypeViewModel : EntityBaseViewModel<PlantTypeModel, PlantTypeModelId, CreatePlantTypeModel, UpdatePlantTypeModel>
    {
        public PlantTypeViewModel(IEntityApiService<PlantTypeModel, PlantTypeModelId, CreatePlantTypeModel, UpdatePlantTypeModel> apiService, IMapper mapper) : base(apiService, mapper)
        {
        }
    }
}
