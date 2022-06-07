
using Microsoft.EntityFrameworkCore;
using Prueba.DTO;


namespace Prueba.Entity
{
    public class DataConte : DbContext
    {
        public DataConte(DbContextOptions<DataConte> options) : base(options) { }

        public static Action<object> Log { get; internal set; }
        public DbSet<Usuario> UsuarioDB { get; set; }
        public DbSet<Medicos> MedicoDB { get; set; }
        public DbSet<Paciente> PacienteDB { get; set; }
        public DbSet<Diagnostico> DiagnosticoDB { get; set; }
        public DbSet<Cita> CitaDB { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var users = modelBuilder.Entity<Usuario>();
            users.ToTable("Usuario");
            users.HasKey(u => u.Id);
            users.HasAlternateKey(u => u.User);

            var medicos = modelBuilder.Entity<Medicos>();
            medicos.ToTable("Medico");

            var pacientes = modelBuilder.Entity<Paciente>();
            pacientes.ToTable("Paciente");

            var diagnosticos = modelBuilder.Entity<Diagnostico>();
            diagnosticos.ToTable("Diagnostico");
            diagnosticos.HasKey(d => d.Id);

            var citas = modelBuilder.Entity<Cita>();
            citas.ToTable("Cita");
            citas.HasKey(c => c.Id);

            /* citas.HasOne(c => c.Diagnostico)
                  .WithOne(d => d.Cita);*/
        }

    }
}
