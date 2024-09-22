using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClinicaApp.Modelos;
using ClinicaApp.DTOs;
using ClinicaApp.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.ViewModels
{
	public partial class MedicamentoVM : ObservableObject
	{
		private readonly ClinicaDbContext _context;

		// Constructor público sin parámetros
		public MedicamentoVM() { }

		// Constructor principal con inyección de dependencias
		public MedicamentoVM(ClinicaDbContext context)
		{
			_context = context;
			MainThread.BeginInvokeOnMainThread(async () => await ObtenerMedicamentos());
		}

		[ObservableProperty]
		private ObservableCollection<MedicamentoDTO> listaMedicamentos;

		[ObservableProperty]
		private MedicamentoDTO medicamentoSeleccionado;

		[ObservableProperty]
		private string nombre;

		[ObservableProperty]
		private string descripcion;

		[ObservableProperty]
		private int cantidadDisponible;

		[ObservableProperty]
		private int cantidadMinima;

		[ObservableProperty]
		private bool loadingEsVisible = false;

		[ObservableProperty]
		private bool alertaVisible = false;

		// Método para obtener todos los medicamentos del inventario
		public async Task ObtenerMedicamentos()
		{
			LoadingEsVisible = true;

			await Task.Run(async () =>
			{
				var medicamentosDb = await _context.Medicamentos.ToListAsync();
				var listaTemp = new ObservableCollection<MedicamentoDTO>();

				foreach (var medicamento in medicamentosDb)
				{
					listaTemp.Add(new MedicamentoDTO
					{
						IdMedicamento = medicamento.IdMedicamento,
						Nombre = medicamento.Nombre,
						Descripcion = medicamento.Descripcion,
						CantidadDisponible = medicamento.CantidadDisponible,
						CantidadMinima = medicamento.CantidadMinima
					});

					// Verificamos si alguno de los medicamentos tiene cantidad por debajo del mínimo
					if (medicamento.CantidadDisponible < medicamento.CantidadMinima)
					{
						AlertaVisible = true;
					}
				}

				ListaMedicamentos = listaTemp;
				LoadingEsVisible = false;
			});
		}

		// Comando para agregar medicamento
		[RelayCommand]
		public async Task AgregarMedicamento()
		{
			if (!string.IsNullOrEmpty(Nombre) && CantidadDisponible >= 0 && CantidadMinima >= 0)
			{
				LoadingEsVisible = true;

				var nuevoMedicamento = new Medicamento
				{
					Nombre = Nombre,
					Descripcion = Descripcion,
					CantidadDisponible = CantidadDisponible,
					CantidadMinima = CantidadMinima
				};

				_context.Medicamentos.Add(nuevoMedicamento);
				await _context.SaveChangesAsync();

				ListaMedicamentos.Add(new MedicamentoDTO
				{
					IdMedicamento = nuevoMedicamento.IdMedicamento,
					Nombre = nuevoMedicamento.Nombre,
					Descripcion = nuevoMedicamento.Descripcion,
					CantidadDisponible = nuevoMedicamento.CantidadDisponible,
					CantidadMinima = nuevoMedicamento.CantidadMinima
				});

				LimpiarCampos();
				LoadingEsVisible = false;
			}
		}

		// Comando para editar medicamento
		[RelayCommand]
		public async Task EditarMedicamento()
		{
			if (MedicamentoSeleccionado != null)
			{
				LoadingEsVisible = true;

				var medicamentoAEditar = await _context.Medicamentos.FindAsync(MedicamentoSeleccionado.IdMedicamento);
				medicamentoAEditar.Nombre = Nombre;
				medicamentoAEditar.Descripcion = Descripcion;
				medicamentoAEditar.CantidadDisponible = CantidadDisponible;
				medicamentoAEditar.CantidadMinima = CantidadMinima;

				_context.Medicamentos.Update(medicamentoAEditar);
				await _context.SaveChangesAsync();

				MedicamentoSeleccionado.Nombre = Nombre;
				MedicamentoSeleccionado.Descripcion = Descripcion;
				MedicamentoSeleccionado.CantidadDisponible = CantidadDisponible;
				MedicamentoSeleccionado.CantidadMinima = CantidadMinima;

				LimpiarCampos();
				LoadingEsVisible = false;
			}
		}

		// Comando para eliminar medicamento
		[RelayCommand]
		public async Task EliminarMedicamento()
		{
			if (MedicamentoSeleccionado != null)
			{
				LoadingEsVisible = true;

				var medicamentoAEliminar = await _context.Medicamentos.FindAsync(MedicamentoSeleccionado.IdMedicamento);
				_context.Medicamentos.Remove(medicamentoAEliminar);
				await _context.SaveChangesAsync();

				ListaMedicamentos.Remove(MedicamentoSeleccionado);
				LimpiarCampos();
				LoadingEsVisible = false;
			}
		}

		// Método para limpiar los campos
		private void LimpiarCampos()
		{
			Nombre = string.Empty;
			Descripcion = string.Empty;
			CantidadDisponible = 0;
			CantidadMinima = 0;
			MedicamentoSeleccionado = null;
		}
	}
}
