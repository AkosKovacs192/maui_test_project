using MauiApp1.Pages.ViewModels;

namespace MauiApp1.Pages.Views;

public partial class DogsView : ContentPage
{
	public DogsView(DogsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}