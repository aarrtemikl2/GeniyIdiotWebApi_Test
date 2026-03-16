using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeniyIdiotWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserAnswer = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCorrect = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    Rank = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Answer = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Answer", "Title" },
                values: new object[,]
                {
                    { 1, 6, "Сколько будет два плюс два умноженное на два?" },
                    { 2, 9, "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?" },
                    { 3, 25, "На двух руках 10 пальцев. Сколько пальцев на 5 руках?" },
                    { 4, 60, "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?" },
                    { 5, 2, "Пять свечей горело, две потухли. Сколько свечей осталось?" }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Идиот" },
                    { 2, "Кретин" },
                    { 3, "Дурак" },
                    { 4, "Нормальный" },
                    { 5, "Талант" },
                    { 6, "Гений" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerAttempts");

            migrationBuilder.DropTable(
                name: "GameResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
