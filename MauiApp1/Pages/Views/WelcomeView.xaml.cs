using MauiApp1.Pages.ViewModels;

namespace MauiApp1.Pages.Views;

public partial class WelcomeView : ContentPage
{

	private WelcomeViewModel vm;
	public WelcomeView(WelcomeViewModel vm)
	{
		InitializeComponent();

		this.vm = vm;
		this.vm.map = map;
		BindingContext = this.vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await this.vm.SetLocation();
    }


}