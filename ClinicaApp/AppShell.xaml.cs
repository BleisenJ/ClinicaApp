using ClinicaApp.ViewModels;
using ClinicaApp.Pages;

namespace ClinicaApp
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute("HistorialCitasPage", typeof(HistorialCitasPage));
			Routing.RegisterRoute("MainPage", typeof(MainPage));
		}
	}
}
