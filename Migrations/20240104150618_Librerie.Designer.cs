﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoClase.Models;

#nullable disable

namespace ProyectoClase.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    [Migration("20240104150618_Librerie")]
    partial class Librerie
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAutor"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAutor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.DetalleVentas", b =>
                {
                    b.Property<int>("IdDetalleVetan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleVetan"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("idLibro")
                        .HasColumnType("int");

                    b.Property<int>("idVenta")
                        .HasColumnType("int");

                    b.Property<int>("libroIdLibro")
                        .HasColumnType("int");

                    b.Property<int>("ventasIdVentas")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleVetan");

                    b.HasIndex("libroIdLibro");

                    b.HasIndex("ventasIdVentas");

                    b.ToTable("detalleVentas");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Editorial", b =>
                {
                    b.Property<int>("IdEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEditorial"));

                    b.Property<string>("NombreEdictorial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEditorial");

                    b.ToTable("editoriales");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Libro", b =>
                {
                    b.Property<int>("IdLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLibro"));

                    b.Property<int>("Año")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegitro")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URLLibro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("autorIdAutor")
                        .HasColumnType("int");

                    b.Property<int>("categoriaIdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("editorialIdEditorial")
                        .HasColumnType("int");

                    b.Property<int>("idAutor")
                        .HasColumnType("int");

                    b.Property<int>("idCategoria")
                        .HasColumnType("int");

                    b.Property<int>("idEditorial")
                        .HasColumnType("int");

                    b.HasKey("IdLibro");

                    b.HasIndex("autorIdAutor");

                    b.HasIndex("categoriaIdCategoria");

                    b.HasIndex("editorialIdEditorial");

                    b.ToTable("libros");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Roles", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRol");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idRol")
                        .HasColumnType("int");

                    b.Property<int>("rolesIdRol")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("rolesIdRol");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Ventas", b =>
                {
                    b.Property<int>("IdVentas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVentas"));

                    b.Property<decimal>("Descuento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IVA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<int>("usuarioIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdVentas");

                    b.HasIndex("usuarioIdUsuario");

                    b.ToTable("ventas");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.DetalleVentas", b =>
                {
                    b.HasOne("ProyectoClase.Models.Entidades.Libro", "libro")
                        .WithMany()
                        .HasForeignKey("libroIdLibro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoClase.Models.Entidades.Ventas", "ventas")
                        .WithMany()
                        .HasForeignKey("ventasIdVentas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("libro");

                    b.Navigation("ventas");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Libro", b =>
                {
                    b.HasOne("ProyectoClase.Models.Entidades.Autor", "autor")
                        .WithMany()
                        .HasForeignKey("autorIdAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoClase.Models.Entidades.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaIdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoClase.Models.Entidades.Editorial", "editorial")
                        .WithMany()
                        .HasForeignKey("editorialIdEditorial")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("autor");

                    b.Navigation("categoria");

                    b.Navigation("editorial");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Usuario", b =>
                {
                    b.HasOne("ProyectoClase.Models.Entidades.Roles", "roles")
                        .WithMany()
                        .HasForeignKey("rolesIdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roles");
                });

            modelBuilder.Entity("ProyectoClase.Models.Entidades.Ventas", b =>
                {
                    b.HasOne("ProyectoClase.Models.Entidades.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
