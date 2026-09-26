using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proforientation_Quiz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAttemptNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAttemptNumber",
                table: "QuizAttempts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAttemptNumber",
                table: "QuizAttempts");
        }
    }
}
