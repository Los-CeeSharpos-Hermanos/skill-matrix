using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillMatrix.DataAccess.Migrations
{
    public partial class SkillRatingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillRating",
                columns: table => new
                {
                    SkillRatingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillRating", x => x.SkillRatingId);
                    table.ForeignKey(
                        name: "FK_SkillRating_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SkillRating",
                columns: new[] { "SkillRatingId", "Rating", "SkillId", "UserId" },
                values: new object[] { 1L, 3, 40L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_SkillRating_UserId",
                table: "SkillRating",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillRating");
        }
    }
}
