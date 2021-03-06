// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using emigrant.App.Persistencia;

namespace emigrant.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContextDb))]
    partial class AppContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("emigrant.App.Dominio.AmigoFamiliar", b =>
                {
                    b.Property<int>("AmigoFamiliarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FamAmigId")
                        .HasColumnType("int");

                    b.Property<int?>("MigranteId")
                        .HasColumnType("int");

                    b.HasKey("AmigoFamiliarId");

                    b.HasIndex("MigranteId");

                    b.ToTable("AmigoFamiliars");
                });

            modelBuilder.Entity("emigrant.App.Dominio.Emergencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaEmergencia")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMigrante")
                        .HasColumnType("int");

                    b.Property<string>("NombreMigrante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumetoMigrante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoEmergencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Emergencias");
                });

            modelBuilder.Entity("emigrant.App.Dominio.EntidadColaboradora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ciudad")
                        .HasColumnType("int");

                    b.Property<int>("Departamento")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Pais")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Nit")
                        .IsUnique();

                    b.ToTable("EntidadColaboradora");
                });

            modelBuilder.Entity("emigrant.App.Dominio.Migrante", b =>
                {
                    b.Property<int>("MigranteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CiudadResidencia")
                        .HasColumnType("int");

                    b.Property<string>("DireccionActual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirrecionElectronica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaNacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisOrigen")
                        .HasColumnType("int");

                    b.Property<bool>("SituacionLaboral")
                        .HasColumnType("bit");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MigranteId");

                    b.HasIndex("NumeroDocumento")
                        .IsUnique();

                    b.ToTable("Migrantes");
                });

            modelBuilder.Entity("emigrant.App.Dominio.Servicio", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntidadId")
                        .HasColumnType("int");

                    b.Property<string>("EntidadNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoServicio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaFinal")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInicio")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("MaximoMigrantes")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicioId");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("emigrant.App.Dominio.ServicioAsignacion", b =>
                {
                    b.Property<int>("ServicioAsignacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntidadId")
                        .HasColumnType("int");

                    b.Property<string>("EntidadNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MigranteId")
                        .HasColumnType("int");

                    b.Property<string>("MigranteNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.Property<string>("ServicioNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicioAsignacionId");

                    b.ToTable("ServicioAsignaciones");
                });

            modelBuilder.Entity("emigrant.App.Dominio.ServicioEnUso", b =>
                {
                    b.Property<int>("ServicioEnUsoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntidadId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MigranteId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("ServicioEnUsoId");

                    b.ToTable("ServicioEnUsos");
                });

            modelBuilder.Entity("emigrant.App.Dominio.ServicioSolicitud", b =>
                {
                    b.Property<int>("ServicioSolicitudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntidadId")
                        .HasColumnType("int");

                    b.Property<string>("EntidadNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MigranteId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MigranteNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.Property<string>("ServicioNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicioSolicitudId");

                    b.ToTable("ServicioSolicitudes");
                });

            modelBuilder.Entity("emigrant.App.Dominio.AmigoFamiliar", b =>
                {
                    b.HasOne("emigrant.App.Dominio.Migrante", "Migrante")
                        .WithMany("AmigoFamiliar")
                        .HasForeignKey("MigranteId");

                    b.Navigation("Migrante");
                });

            modelBuilder.Entity("emigrant.App.Dominio.Migrante", b =>
                {
                    b.Navigation("AmigoFamiliar");
                });
#pragma warning restore 612, 618
        }
    }
}
