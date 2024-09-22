using ClinicaApp.Pages;
using ClinicaApp.ViewModels;

namespace ClinicaApp.Pages
{
	public partial class MainPage : ContentPage
	{
		private readonly MainPageVM _viewModel;

		public MainPage(MainPageVM viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			BindingContext = _viewModel;
		}
	}
}
