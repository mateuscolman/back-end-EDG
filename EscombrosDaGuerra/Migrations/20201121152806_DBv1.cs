using Microsoft.EntityFrameworkCore.Migrations;

namespace EscombrosDaGuerra.Migrations
{
    public partial class DBv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    SpellId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpellName = table.Column<string>(type: "TEXT", nullable: true),
                    SpellConjurationTime = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellConjurationTimer = table.Column<short>(type: "INTEGER", nullable: false),
                    SpellRange = table.Column<string>(type: "TEXT", nullable: true),
                    SpellComponentVerbal = table.Column<short>(type: "INTEGER", nullable: false),
                    SpellComponentSomatic = table.Column<short>(type: "INTEGER", nullable: false),
                    SpellComponentMaterial = table.Column<short>(type: "INTEGER", nullable: false),
                    SpellComponentMaterialDesc = table.Column<string>(type: "TEXT", nullable: true),
                    SpellConcentration = table.Column<short>(type: "INTEGER", nullable: false),
                    SpellDuration = table.Column<string>(type: "TEXT", nullable: true),
                    SpellLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    SpellSchool = table.Column<string>(type: "TEXT", nullable: true),
                    SpellRitual = table.Column<short>(type: "INTEGER", nullable: false),
                    SpellDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.SpellId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spells");
        }
    }
}
