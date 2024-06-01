using FloraSense.Entities.Guards;
using FloraSense.Resources;
using FloraSense.ViewModels.PageViewModels;
using FloraService.Abstractions.Pages;
using System.Resources;

namespace FloraSense.Pages;

public partial class LoginPage : ContentPage, IEntityWithGuards
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

		var resourceManager = new ResourceManager(typeof(MobileResources));

		Title = resourceManager.GetString("Login");
	}

    public IEnumerable<Guard> Guards => [Guard.OnlyIfLogout];
}