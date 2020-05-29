using Microsoft.EntityFrameworkCore.Migrations;

namespace ConstructoIT.Hotel.Accor.Infraestrutura.Repository.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Id_Condominio = table.Column<int>(nullable: false),
                    Apto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Familia_Condominio_Id_Condominio",
                        column: x => x.Id_Condominio,
                        principalTable: "Condominio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Morador",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Familia = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    QuantidadeBichosEstimacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Morador_Familia_Id_Familia",
                        column: x => x.Id_Familia,
                        principalTable: "Familia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Familia_Id_Condominio",
                table: "Familia",
                column: "Id_Condominio");

            migrationBuilder.CreateIndex(
                name: "IX_Morador_Id_Familia",
                table: "Morador",
                column: "Id_Familia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Morador");

            migrationBuilder.DropTable(
                name: "Familia");

            migrationBuilder.DropTable(
                name: "Condominio");
        }
    }
}
