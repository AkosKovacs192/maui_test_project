using MauiApp1.Pages.ViewModels;

namespace MauiApp1.Pages.Views;

public partial class WelcomeView : ContentPage
{
	public WelcomeView(WelcomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}