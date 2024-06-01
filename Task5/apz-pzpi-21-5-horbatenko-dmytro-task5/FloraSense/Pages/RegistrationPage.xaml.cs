using FloraSense.Entities.Guards;
using FloraSense.Resources;
using FloraSense.ViewModels.PageViewModels;
using FloraService.Abstractions.Pages;
using System.Resources;

namespace FloraSense.Pages;

public partial class RegistrationPage : ContentPage, IEntityWithGuards
{
	public RegistrationPage(RegistrationViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }

    public IEnumerable<Guard> Guards => [Guard.OnlyIfLogout];
}