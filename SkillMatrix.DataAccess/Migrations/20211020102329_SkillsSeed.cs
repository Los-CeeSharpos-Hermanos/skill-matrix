using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillMatrix.DataAccess.Migrations
{
    public partial class SkillsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SkillCategories",
                columns: new[] { "SkillCategoryId", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "Technical Skills", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Soft Skills", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "SWOValue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "Sport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name", "SkillCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "C#", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Java", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "JavaScript", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "Python", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, "Team Play", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, "Speed", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, "Soccer", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "SkillId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "SkillCategories",
                keyColumn: "SkillCategoryId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SkillCategories",
                keyColumn: "SkillCategoryId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SkillCategories",
                keyColumn: "SkillCategoryId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SkillCategories",
                keyColumn: "SkillCategoryId",
                keyValue: 4L);
        }
    }
}
