using ClinicaApp.DataAccess;
using ClinicaApp.ViewModels;

namespace ClinicaApp.Pages
{
	public partial class AgendarCitaPage : ContentPage
	{
		private readonly AgendarCitaVM _viewModel;

		public AgendarCitaPage(AgendarCitaVM viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			BindingContext = _viewModel;
		}
	}
}