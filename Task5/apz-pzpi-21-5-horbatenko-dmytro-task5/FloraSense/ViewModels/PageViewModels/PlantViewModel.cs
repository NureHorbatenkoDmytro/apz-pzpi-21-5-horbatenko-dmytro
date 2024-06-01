using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using FloraSense.ApiLayer.EntityApiServices;
using FloraSense.Entities.PlantDataItems;
using FloraSense.Entities.Plants;
using FloraSense.Entities.PlantTypes;
using FloraService.ApiLayer.Abstractions;
using System.Collections.ObjectModel;

namespace FloraSense.ViewModels.PageViewModels
{
    public partial class PlantViewModel : EntityBaseViewModel<PlantModel, PlantModelId, CreatePlantModel, UpdatePlantModel>
    {
        private readonly IEntityApiService<PlantTypeModel, PlantTypeModelId, CreatePlantTypeModel, UpdatePlantTypeModel> _plantTypeApiService;
        private readonly PlantDataApiService _plantDataApiService;
        [ObservableProperty]
        private ObservableCollection<Guid> _plantTypeModels = new ObservableCollection<Guid>();
        [ObservableProperty]
        private ObservableCollection<PlantDataModel> _plantDataItems = new ObservableCollection<PlantDataModel>();
        [ObservableProperty]
        private int _currentPlantTypeModelIndex;

        public PlantViewModel(
            IEntityApiService<PlantTypeModel, PlantTypeModelId, CreatePlantTypeModel, UpdatePlantTypeModel> plantTypeApiService,
            PlantDataApiService plantDataApiService,
            IEntityApiService<PlantModel, PlantModelId, CreatePlantModel, UpdatePlantModel> apiService, IMapper mapper) : base(apiService, mapper)
        {
            _plantTypeApiService = plantTypeApiService;
            _plantDataApiService = plantDataApiService;
        }

        protected override async Task LoadAsync()
        {
            PlantTypeModels = new ObservableCollection<Guid>((await _plantTypeApiService.GetAllAsync()).Select(at => at.Id));

            await base.LoadAsync();
        }

        protected override async Task GetCurrentEntityAsync(SelectedItemChangedEventArgs? args)
        {
            await base.GetCurrentEntityAsync(args);

            if (CurrentEntity is null)
            {
                return;
            }

            PlantDataItems = new ObservableCollection<PlantDataModel>(await _plantDataApiService.GetAllPlantsAsync(CurrentEntity.Id));
            CurrentPlantTypeModelIndex = PlantTypeModels.IndexOf(CurrentEntity.PlantTypeId);
        }
    }
}
