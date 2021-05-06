﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Taxi24.Servicios.Viajes.Data;

namespace Taxi24.Servicios.Viajes.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210506193959_rename")]
    partial class rename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Taxi24.Servicios.Viajes.Entities.Viaje", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("EmpresaID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Final")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Inicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("PasajeroID")
                        .HasColumnType("bigint");

                    b.Property<long>("PilotoID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Viajes");
                });
#pragma warning restore 612, 618
        }
    }
}
