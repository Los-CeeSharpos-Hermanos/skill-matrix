using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillMatrix.DataAccess.Migrations
{
    public partial class ChangeSkillCategoryNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SkillCategories",
                newName: "SkillCategoryName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SkillCategoryName",
                table: "SkillCategories",
                newName: "Name");
        }
    }
}
