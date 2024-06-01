using FloraSense.Entities.Guards;
using FloraSense.Resources;
using FloraSense.ViewModels.PageViewModels;
using FloraService.Abstractions.Pages;
using System.Resources;

namespace FloraSense.Pages;

public partial class LogoutPage : ContentPage, IEntityWithGuards
{
	public LogoutPage(LogoutViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

        var resourceManager = new ResourceManager(typeof(MobileResources));

        Title = resourceManager.GetString("Logout");
    }

    public IEnumerable<Guard> Guards => [Guard.LoginRequired];
}