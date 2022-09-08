using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace src.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlacaMae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemoriaRam = table.Column<int>(type: "int", nullable: false),
                    Armazenamento = table.Column<int>(type: "int", nullable: false),
                    VelocidadeProcessador = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "Id", "Armazenamento", "Marca", "MemoriaRam", "Modelo", "PlacaMae", "VelocidadeProcessador" },
                values: new object[] { 1, 512, "Acer", 8, "Nitro 5 AN515-44", "RO Stonic RNS", 4.2999999999999998 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
