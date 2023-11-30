using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace daily_diet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_userId",
                table: "Meals",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Users_userId",
                table: "Meals",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Users_userId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_userId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Meals");
        }
    }
}
