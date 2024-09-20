using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestPostgres.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Region_RegionId",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "Schools");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");

            migrationBuilder.RenameIndex(
                name: "IX_School_RegionId",
                table: "Schools",
                newName: "IX_Schools_RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Regions_RegionId",
                table: "Schools",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Regions_RegionId",
                table: "Schools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "School");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Region");

            migrationBuilder.RenameIndex(
                name: "IX_Schools_RegionId",
                table: "School",
                newName: "IX_School_RegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "SchoolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Region_RegionId",
                table: "School",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
