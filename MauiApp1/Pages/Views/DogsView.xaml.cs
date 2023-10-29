using MauiApp1.Pages.ViewModels;

namespace MauiApp1.Pages.Views;

public partial class DogsView : ContentPage
{

    private readonly DogsViewModel vm;
	public DogsView(DogsViewModel vm)
	{
		InitializeComponent();

		this.vm = vm;
		BindingContext = this.vm;
	}



    protected override async void OnAppearing()
    {
        base.OnAppearing();

        this.vm.LoadImageOnAppear();
    }

}