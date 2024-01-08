using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoClase.Migrations
{
    /// <inheritdoc />
    public partial class Librerie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "editoriales",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEdictorial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editoriales", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    IdLibro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaRegitro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    URLLibro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    idAutor = table.Column<int>(type: "int", nullable: false),
                    idEditorial = table.Column<int>(type: "int", nullable: false),
                    autorIdAutor = table.Column<int>(type: "int", nullable: false),
                    editorialIdEditorial = table.Column<int>(type: "int", nullable: false),
                    categoriaIdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_libros_Autores_autorIdAutor",
                        column: x => x.autorIdAutor,
                        principalTable: "Autores",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libros_Categorias_categoriaIdCategoria",
                        column: x => x.categoriaIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_libros_editoriales_editorialIdEditorial",
                        column: x => x.editorialIdEditorial,
                        principalTable: "editoriales",
                        principalColumn: "IdEditorial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idRol = table.Column<int>(type: "int", nullable: false),
                    rolesIdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_rolesIdRol",
                        column: x => x.rolesIdRol,
                        principalTable: "roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    IdVentas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    usuarioIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.IdVentas);
                    table.ForeignKey(
                        name: "FK_ventas_usuarios_usuarioIdUsuario",
                        column: x => x.usuarioIdUsuario,
                        principalTable: "usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalleVentas",
                columns: table => new
                {
                    IdDetalleVetan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    idVenta = table.Column<int>(type: "int", nullable: false),
                    idLibro = table.Column<int>(type: "int", nullable: false),
                    ventasIdVentas = table.Column<int>(type: "int", nullable: false),
                    libroIdLibro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleVentas", x => x.IdDetalleVetan);
                    table.ForeignKey(
                        name: "FK_detalleVentas_libros_libroIdLibro",
                        column: x => x.libroIdLibro,
                        principalTable: "libros",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleVentas_ventas_ventasIdVentas",
                        column: x => x.ventasIdVentas,
                        principalTable: "ventas",
                        principalColumn: "IdVentas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalleVentas_libroIdLibro",
                table: "detalleVentas",
                column: "libroIdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_detalleVentas_ventasIdVentas",
                table: "detalleVentas",
                column: "ventasIdVentas");

            migrationBuilder.CreateIndex(
                name: "IX_libros_autorIdAutor",
                table: "libros",
                column: "autorIdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_libros_categoriaIdCategoria",
                table: "libros",
                column: "categoriaIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_libros_editorialIdEditorial",
                table: "libros",
                column: "editorialIdEditorial");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_rolesIdRol",
                table: "usuarios",
                column: "rolesIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_ventas_usuarioIdUsuario",
                table: "ventas",
                column: "usuarioIdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleVentas");

            migrationBuilder.DropTable(
                name: "libros");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "editoriales");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
