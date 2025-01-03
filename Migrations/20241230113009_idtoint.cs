using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScrapBook.Migrations
{
    /// <inheritdoc />
    public partial class idtoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyImages_Journeys_JourneyId1",
                table: "JourneyImages");

            migrationBuilder.DropIndex(
                name: "IX_JourneyImages_JourneyId1",
                table: "JourneyImages");

            migrationBuilder.DropColumn(
                name: "JourneyId1",
                table: "JourneyImages");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Journeys",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_JourneyImages_JourneyId",
                table: "JourneyImages",
                column: "JourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyImages_Journeys_JourneyId",
                table: "JourneyImages",
                column: "JourneyId",
                principalTable: "Journeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyImages_Journeys_JourneyId",
                table: "JourneyImages");

            migrationBuilder.DropIndex(
                name: "IX_JourneyImages_JourneyId",
                table: "JourneyImages");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Journeys",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "JourneyId1",
                table: "JourneyImages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JourneyImages_JourneyId1",
                table: "JourneyImages",
                column: "JourneyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyImages_Journeys_JourneyId1",
                table: "JourneyImages",
                column: "JourneyId1",
                principalTable: "Journeys",
                principalColumn: "Id");
        }
    }
}
