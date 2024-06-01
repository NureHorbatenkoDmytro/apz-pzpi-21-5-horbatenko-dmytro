using FloraSense.Entities.Guards;
using FloraSense.ViewModels.PageViewModels;
using FloraService.Abstractions.Pages;

namespace FloraSense.Pages;

public partial class PlantTypesPage : ContentPage, IEntityWithGuards
{
	public PlantTypesPage(PlantTypeViewModel plantTypeViewModel)
	{
		InitializeComponent();

		BindingContext = plantTypeViewModel;
	}

    public IEnumerable<Guard> Guards => [Guard.LoginRequired];
}