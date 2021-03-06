// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Taxi24.Servicios.Conductores.Data;

namespace Taxi24.Servicios.Conductores.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210506032828_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Taxi24.Servicios.Conductores.Entities.Conductor", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Disponible")
                        .HasColumnType("boolean");

                    b.Property<long>("EmpresaID")
                        .HasColumnType("bigint");

                    b.Property<double>("Latitud")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitud")
                        .HasColumnType("double precision");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Conductores");
                });
#pragma warning restore 612, 618
        }
    }
}
