using ClinicaApp.Pages;
using Microsoft.Extensions.Logging;
using ClinicaApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using ClinicaApp.DataAccess;
using ClinicaApp.Utilidades;
using System.IO;

namespace ClinicaApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			// Registrar páginas y ViewModels
			builder.Services.AddTransient<InventarioMedicamentosPage>(); 

			builder.Services.AddTransient<MedicamentoVM>();

			builder.Services.AddTransient<MainPage>();
			builder.Services.AddTransient<MainPageVM>();

			builder.Services.AddTransient<MedicoVM>();

			builder.Services.AddTransient<LoginPage>();

			builder.Services.AddTransient<HistorialCitasPage>();
			builder.Services.AddTransient<HistorialCitasVM>();
			builder.Services.AddTransient<HorariosPage>();
			


			builder.Services.AddTransient<MainPage>();

			builder.Services.AddTransient<AgendarCitaPage>();
			builder.Services.AddTransient<AgendarCitaVM>();



			builder.Services.AddTransient<HistorialCitasVM>();
			builder.Services.AddDbContext<ClinicaDbContext>(options =>
			{
				options.UseSqlite($"Filename={Path.Combine(FileSystem.AppDataDirectory, "ClinicaApp.db")}");
			});



			// Configurar la base de datos SQLite
			string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clinica.db");
			builder.Services.AddDbContext<ClinicaDbContext>(options =>
			{
				options.UseSqlite($"Filename={dbPath}");
			});

			// Registrar rutas
			Routing.RegisterRoute(nameof(AgendarCitaPage), typeof(AgendarCitaPage));

			return builder.Build();
		}
	}
}
