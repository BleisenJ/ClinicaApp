using Microsoft.EntityFrameworkCore;
using ClinicaApp.Modelos;

namespace ClinicaApp.DataAccess
{
	public class ClinicaDbContext : DbContext
	{
		public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options) : base(options) { }

		public DbSet<Medico> Medicos { get; set; }
		public DbSet<Paciente> Pacientes { get; set; }
		public DbSet<Cita> Citas { get; set; }
		public DbSet<Horarios> Horarios { get; set; }
		public DbSet<Medicamento> Medicamentos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Configuración de relaciones
			modelBuilder.Entity<Cita>()
				.HasOne(c => c.Medico)
				.WithMany(m => m.Citas)
				.HasForeignKey(c => c.IdMedico);

			modelBuilder.Entity<Cita>()
				.HasOne(c => c.Paciente)
				.WithMany(p => p.Citas)
				.HasForeignKey(c => c.IdPaciente);

			modelBuilder.Entity<Horarios>()
				.HasOne(h => h.Medico)
				.WithMany(m => m.Horarios)
				.HasForeignKey(h => h.IdMedico);
		}
	}
}
