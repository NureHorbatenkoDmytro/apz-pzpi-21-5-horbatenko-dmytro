using FloraSense.Entities.Guards;
using FloraSense.ViewModels.PageViewModels;
using FloraService.Abstractions.Pages;

namespace FloraSense.Pages;

public partial class PlantsPage : ContentPage, IEntityWithGuards
{
	public PlantsPage(PlantViewModel plantViewModel)
	{
		InitializeComponent();

		BindingContext = plantViewModel;
	}

    public IEnumerable<Guard> Guards => [Guard.LoginRequired];
}