﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillMatrix.DataAccess.Migrations
{
    public partial class InitialWithAuthentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillCategories",
                columns: table => new
                {
                    SkillCategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategories", x => x.SkillCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_SkillCategories_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategories",
                        principalColumn: "SkillCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: true),
                    TeamId = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguageRating",
                columns: table => new
                {
                    LanguageRatingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageRating", x => x.LanguageRatingId);
                    table.ForeignKey(
                        name: "FK_LanguageRating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillRating",
                columns: table => new
                {
                    SkillRatingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillRating", x => x.SkillRatingId);
                    table.ForeignKey(
                        name: "FK_SkillRating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "UpdatedAt" },
                values: new object[,]
                {
                    { 3L, "Marketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Development", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1L, "Sales", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name", "NativeName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "ab", "Abkhaz", "аҧсуа", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 120L, "om", "Oromo", "Afaan Oromoo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 121L, "or", "Oriya", "ଓଡ଼ିଆ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 122L, "os", "Ossetian, Ossetic", "ирон æвзаг", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 123L, "pa", "Panjabi, Punjabi", "ਪੰਜਾਬੀ, پنجابی‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 124L, "pi", "Pāli", "पाऴि", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 125L, "fa", "Persian", "فارسی", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 126L, "pl", "Polish", "polski", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 127L, "ps", "Pashto, Pushto", "پښتو", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 128L, "pt", "Portuguese", "Português", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 130L, "rm", "Romansh", "rumantsch grischun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 119L, "cu", "Old Church Slavonic, Church Slavic, Church Slavonic, Old Bulgarian, Old Slavonic", "ѩзыкъ словѣньскъ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 131L, "rn", "Kirundi", "kiRundi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 132L, "ro", "Romanian, Moldavian, Moldovan", "română", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 133L, "ru", "Russian", "русский язык", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 134L, "sa", "Sanskrit (Saṁskṛta)", "संस्कृतम्", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 135L, "sc", "Sardinian", "sardu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 136L, "sd", "Sindhi", "सिन्धी, سنڌي، سندھی‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 137L, "se", "Northern Sami", "Davvisámegiella", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 129L, "qu", "Quechua", "Runa Simi, Kichwa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 118L, "oj", "Ojibwe, Ojibwa", "ᐊᓂᔑᓈᐯᒧᐎᓐ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 116L, "nr", "South Ndebele", "isiNdebele", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 138L, "sm", "Samoan", "gagana faa Samoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97L, "gv", "Manx", "Gaelg, Gailck", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98L, "mk", "Macedonian", "македонски јазик", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99L, "mg", "Malagasy", "Malagasy fiteny", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100L, "ms", "Malay", "bahasa Melayu, بهاس ملايو‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101L, "ml", "Malayalam", "മലയാളം", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 102L, "mt", "Maltese", "Malti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 103L, "mi", "Māori", "te reo Māori", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 104L, "mr", "Marathi (Marāṭhī)", "मराठी", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 105L, "mh", "Marshallese", "Kajin M̧ajeļ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 106L, "mn", "Mongolian", "монгол", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 107L, "na", "Nauru", "Ekakairũ Naoero", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 108L, "nv", "Navajo, Navaho", "Diné bizaad, Dinékʼehǰí", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 109L, "nb", "Norwegian Bokmål", "Norsk bokmål", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 110L, "nd", "North Ndebele", "isiNdebele", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111L, "ne", "Nepali", "नेपाली", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112L, "ng", "Ndonga", "Owambo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name", "NativeName", "UpdatedAt" },
                values: new object[,]
                {
                    { 113L, "nn", "Norwegian Nynorsk", "Norsk nynorsk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 114L, "no", "Norwegian", "Norsk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 115L, "ii", "Nuosu", "ꆈꌠ꒿ Nuosuhxop", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 117L, "oc", "Occitan", "Occitan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 139L, "sg", "Sango", "yângâ tî sängö", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 141L, "gd", "Scottish Gaelic; Gaelic", "Gàidhlig", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95L, "lu", "Luba-Katanga", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 165L, "tt", "Tatar", "татарча, tatarça, تاتارچا‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 166L, "tw", "Twi", "Twi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 167L, "ty", "Tahitian", "Reo Tahiti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 168L, "ug", "Uighur, Uyghur", "Uyƣurqə, ئۇيغۇرچە‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 169L, "uk", "Ukrainian", "українська", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 170L, "ur", "Urdu", "اردو", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 171L, "uz", "Uzbek", "zbek, Ўзбек, أۇزبېك‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 172L, "ve", "Venda", "Tshivenḓa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 164L, "ts", "Tsonga", "Xitsonga", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 173L, "vi", "Vietnamese", "Tiếng Việt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 175L, "wa", "Walloon", "Walon", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 176L, "cy", "Welsh", "Cymraeg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 177L, "wo", "Wolof", "Wollof", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 178L, "fy", "Western Frisian", "Frysk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 179L, "xh", "Xhosa", "isiXhosa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 180L, "yi", "Yiddish", "ייִדיש", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 181L, "yo", "Yoruba", "Yorùbá", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 182L, "za", "Zhuang, Chuang", "Saɯ cueŋƅ, Saw cuengh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 174L, "vo", "Volapük", "Volapük", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 163L, "tr", "Turkish", "Türkçe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 162L, "to", "Tonga (Tonga Islands)", "faka Tonga", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 161L, "tn", "Tswana", "Setswana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 142L, "sn", "Shona", "chiShona", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 143L, "si", "Sinhala, Sinhalese", "සිංහල", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 144L, "sk", "Slovak", "slovenčina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 145L, "sl", "Slovene", "slovenščina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 146L, "so", "Somali", "Soomaaliga, af Soomaali", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 147L, "st", "Southern Sotho", "Sesotho", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 148L, "es", "Spanish; Castilian", "español, castellano", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 149L, "su", "Sundanese", "Basa Sunda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 150L, "sw", "Swahili", "Kiswahili", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 151L, "ss", "Swati", "SiSwati", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 152L, "sv", "Swedish", "svenska", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 153L, "ta", "Tamil", "தமிழ்", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 154L, "te", "Telugu", "తెలుగు", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name", "NativeName", "UpdatedAt" },
                values: new object[,]
                {
                    { 155L, "tg", "Tajik", "тоҷикӣ, toğikī, تاجیکی‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 156L, "th", "Thai", "ไทย", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 157L, "ti", "Tigrinya", "ትግርኛ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 158L, "bo", "Tibetan Standard, Tibetan, Central", "བོད་ཡིག", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 159L, "tk", "Turkmen", "Türkmen, Түркмен", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 160L, "tl", "Tagalog", "Wikang Tagalog, ᜏᜒᜃᜅ᜔ ᜆᜄᜎᜓᜄ᜔", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 140L, "sr", "Serbian", "српски језик", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94L, "lt", "Lithuanian", "lietuvių kalba", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96L, "lv", "Latvian", "latviešu valoda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92L, "ln", "Lingala", "Lingála", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, "ca", "Catalan; Valencian", "Català", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, "ch", "Chamorro", "Chamoru", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, "ce", "Chechen", "нохчийн мотт", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, "ny", "Chichewa; Chewa; Nyanja", "chiCheŵa, chinyanja", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, "zh", "Chinese", "中文 (Zhōngwén), 汉语, 漢語", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31L, "cv", "Chuvash", "чӑваш чӗлхи", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32L, "kw", "Cornish", "Kernewek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33L, "co", "Corsican", "corsu, lingua corsa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34L, "cr", "Cree", "ᓀᐦᐃᔭᐍᐏᐣ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35L, "hr", "Croatian", "hrvatski", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36L, "cs", "Czech", "česky, čeština", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37L, "da", "Danish", "dansk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38L, "dv", "Divehi; Dhivehi; Maldivian;", "ދިވެހި", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39L, "nl", "Dutch", "Nederlands, Vlaams", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40L, "en", "English", "English", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41L, "eo", "Esperanto", "Esperanto", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42L, "et", "Estonian", "eesti, eesti keel", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43L, "ee", "Ewe", "Eʋegbe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93L, "lo", "Lao", "ພາສາລາວ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, "my", "Burmese", "ဗမာစာ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, "bg", "Bulgarian", "български език", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, "br", "Breton", "brezhoneg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, "bs", "Bosnian", "bosanski jezik", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "aa", "Afar", "Afaraf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "af", "Afrikaans", "Afrikaans", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "ak", "Akan", "Akan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, "sq", "Albanian", "Shqip", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, "am", "Amharic", "አማርኛ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, "ar", "Arabic", "العربية", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, "an", "Aragonese", "Aragonés", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, "hy", "Armenian", "Հայերեն", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, "as", "Assamese", "অসমীয়া", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name", "NativeName", "UpdatedAt" },
                values: new object[,]
                {
                    { 45L, "fj", "Fijian", "vosa Vakaviti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, "av", "Avaric", "авар мацӀ, магӀарул мацӀ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, "ay", "Aymara", "aymar aru", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, "az", "Azerbaijani", "azərbaycan dili", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, "bm", "Bambara", "bamanankan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, "ba", "Bashkir", "башҡорт теле", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, "eu", "Basque", "euskara, euskera", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, "be", "Belarusian", "Беларуская", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, "bn", "Bengali", "বাংলা", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, "bh", "Bihari", "भोजपुरी", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, "bi", "Bislama", "Bislama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, "ae", "Avestan", "avesta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46L, "fi", "Finnish", "suomi, suomen kieli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44L, "fo", "Faroese", "føroyskt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48L, "ff", "Fula; Fulah; Pulaar; Pular", "Fulfulde, Pulaar, Pular", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47L, "fr", "French", "français, langue française", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74L, "kl", "Kalaallisut, Greenlandic", "kalaallisut, kalaallit oqaasii", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75L, "kn", "Kannada", "ಕನ್ನಡ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76L, "kr", "Kanuri", "Kanuri", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77L, "ks", "Kashmiri", "कश्मीरी, كشميري‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78L, "kk", "Kazakh", "Қазақ тілі", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79L, "km", "Khmer", "ភាសាខ្មែរ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80L, "ki", "Kikuyu, Gikuyu", "Gĩkũyũ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81L, "rw", "Kinyarwanda", "Ikinyarwanda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82L, "ky", "Kirghiz, Kyrgyz", "кыргыз тили", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83L, "kv", "Komi", "коми кыв", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84L, "kg", "Kongo", "KiKongo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85L, "ko", "Korean", "한국어 (韓國語), 조선말 (朝鮮語)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86L, "ku", "Kurdish", "Kurdî, كوردی‎", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87L, "kj", "Kwanyama, Kuanyama", "Kuanyama", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88L, "la", "Latin", "latine, lingua latina", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89L, "lb", "Luxembourgish, Letzeburgesch", "Lëtzebuergesch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90L, "lg", "Luganda", "Luganda", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91L, "li", "Limburgish, Limburgan, Limburger", "Limburgs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72L, "ja", "Japanese", "日本語 (にほんご／にっぽんご)", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71L, "iu", "Inuktitut", "ᐃᓄᒃᑎᑐᑦ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73L, "jv", "Javanese", "basa Jawa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69L, "is", "Icelandic", "Íslenska", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49L, "gl", "Galician", "Galego", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50L, "ka", "Georgian", "ქართული", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51L, "de", "German", "Deutsch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52L, "el", "Greek, Modern", "Ελληνικά", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name", "NativeName", "UpdatedAt" },
                values: new object[,]
                {
                    { 53L, "gn", "Guaraní", "Avañeẽ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54L, "gu", "Gujarati", "ગુજરાતી", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70L, "it", "Italian", "Italiano", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56L, "ha", "Hausa", "Hausa, هَوُسَ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57L, "he", "Hebrew (modern)", "עברית", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58L, "hz", "Herero", "Otjiherero", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55L, "ht", "Haitian; Haitian Creole", "Kreyòl ayisyen", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60L, "ho", "Hiri Motu", "Hiri Motu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61L, "hu", "Hungarian", "Magyar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62L, "ia", "Interlingua", "Interlingua", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63L, "id", "Indonesian", "Bahasa Indonesia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64L, "ie", "Interlingue", "Originally called Occidental; then Interlingue after WWII", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65L, "ga", "Irish", "Gaeilge", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66L, "ig", "Igbo", "Asụsụ Igbo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68L, "io", "Ido", "Ido", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59L, "hi", "Hindi", "हिन्दी, हिंदी", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67L, "ik", "Inupiaq", "Iñupiaq, Iñupiatun", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SkillCategories",
                columns: new[] { "SkillCategoryId", "SkillCategoryName", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, "Soft Skills", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "SWOValue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1L, "Technical Skills", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "Sport", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "DepartmentId", "TeamName", "UpdatedAt" },
                values: new object[,]
                {
                    { 2L, null, "B-Team", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1L, null, "A-Team", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, null, "C-Team", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "JobTitle", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SurName", "TeamId", "Telephone", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "96fa3c64-5640-4ee9-a37a-bdacb8c43005", 0, "2a5af4d5-4ee0-4aa7-9554-e91c603e7e5b", 1L, "nico.marten@web.de", false, "Nico", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Software Architect", "Leipzig", false, null, null, null, null, null, false, "5ab46a1b-fa19-4ea7-b59c-e9eea679fc9f", "Marten", 1L, "0987654321", false, null },
                    { "9f39b3a5-9e09-465d-a63d-34c1eac909c4", 0, "3579e8f6-bbf2-4549-af28-e0d490a4cfed", 2L, "tim.ford@web.de", false, "Tim", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Developer", "Leipzig", false, null, null, null, null, null, false, "0d94b0ac-2c71-42a4-bf6a-4bcf28961e4b", "Ford", 3L, "0123548697", false, null },
                    { "90db1068-f144-4d86-9851-7473ff53d6e4", 0, "c89f7576-60a4-4e83-a36e-5c06dbbcc9e1", 2L, "c.burns@web.de", false, "C Montgomery", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "CEO", "Dresden", false, null, null, null, null, null, false, "4511e1c3-263d-4559-84b2-4daddd82702b", "Burns", 3L, "0125634789", false, null },
                    { "03902199-fb13-4f7d-b4d7-138bc849977f", 0, "790c4117-47e7-4ace-a5b2-cc58172e78e4", 2L, "m.mustermann@gmx.de", false, "Max", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Sailsman", "Leipzig", false, null, null, null, null, null, false, "10d7e744-7ae7-4408-a047-ffff3f58824c", "Mustermann", 3L, "017463589", false, null },
                    { "eb691e66-7037-4827-bf92-561f978acea7", 0, "05eef64d-34fe-4ced-a6b9-c58de521bb09", 2L, "n.mustermann@web.de", false, "Nancy", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Developer", "Dresden", false, null, null, null, null, null, false, "7f1395c1-ac3c-46c3-b611-8aaf26bbe51e", "Mustermann", 2L, "0125896743", false, null },
                    { "e78986c7-9c10-4c87-b639-ba38fc64e10b", 0, "85ac155b-e067-4db6-bdb9-f39ae61faee1", 1L, "tom.tompson@web.de", false, "Tom", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Sailsman", "Leipzig", false, null, null, null, null, null, false, "70f9ae33-6b24-4f73-a867-4dce84cccc6f", "Tompson", 2L, "0123456789", false, null },
                    { "d26fba96-da21-43ac-8250-6b42374cc529", 0, "b5bbb31e-1279-4620-81d0-53b9f8c79a80", 2L, "mandy.meyer@gmail.com", false, "Mandy", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Developer", "Munich", false, null, null, null, null, null, false, "ccc248d3-96ec-4532-ae21-1de75428b2d8", "Meyer", 1L, "0128764539", false, null },
                    { "5a248924-7e9a-4de5-ad8b-86fc25163458", 0, "a3650c5e-8b01-4ba5-9e5f-2640fa36e56a", 3L, "s.muller@web.de", false, "Susi", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Marketing Expert", "Leipzig", false, null, null, null, null, null, false, "b68a62e6-bf27-4a27-93ad-104314cb3197", "Muller", 3L, "0321456789", false, null },
                    { "85947f68-31e2-441c-983d-5b8df633835f", 0, "de49fe77-cb52-497c-8f38-2a12d898957f", 3L, "m.meier@web.de", false, "Mary", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Marketing Expert", "Leipzig", false, null, null, null, null, null, false, "7e56b2db-fa75-4e36-8314-ca57a64bac99", "Meier", 3L, "0213456789", false, null },
                    { "2647ef6e-3a78-4f27-8cd0-7e9478e9e8ef", 0, "35af1af4-848a-4d76-8806-c572b20f8451", 2L, "martin.schmidt@web.de", false, "Martin", "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png", "Developer", "Leipzig", false, null, null, null, null, null, false, "ae6b568e-d304-45cb-83eb-e166f326b496", "Schmidt", 1L, "0845679123", false, null }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "SkillCategoryId", "SkillName", "UpdatedAt" },
                values: new object[,]
                {
                    { 7L, 4L, "Soccer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 3L, "Speed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 2L, "Team Play", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 1L, "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 1L, "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 1L, "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1L, 1L, "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LanguageRating",
                columns: new[] { "LanguageRatingId", "Language", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1L, "german", 3, "2647ef6e-3a78-4f27-8cd0-7e9478e9e8ef" },
                    { 19L, "german", 3, "85947f68-31e2-441c-983d-5b8df633835f" },
                    { 18L, "english", 2, "85947f68-31e2-441c-983d-5b8df633835f" },
                    { 21L, "german", 3, "5a248924-7e9a-4de5-ad8b-86fc25163458" },
                    { 20L, "english", 2, "5a248924-7e9a-4de5-ad8b-86fc25163458" },
                    { 16L, "german", 3, "5a248924-7e9a-4de5-ad8b-86fc25163458" },
                    { 17L, "english", 2, "5a248924-7e9a-4de5-ad8b-86fc25163458" },
                    { 15L, "german", 3, "9f39b3a5-9e09-465d-a63d-34c1eac909c4" },
                    { 14L, "english", 2, "9f39b3a5-9e09-465d-a63d-34c1eac909c4" },
                    { 13L, "german", 3, "90db1068-f144-4d86-9851-7473ff53d6e4" },
                    { 12L, "english", 2, "90db1068-f144-4d86-9851-7473ff53d6e4" },
                    { 11L, "german", 3, "03902199-fb13-4f7d-b4d7-138bc849977f" },
                    { 7L, "latin", 1, "eb691e66-7037-4827-bf92-561f978acea7" },
                    { 6L, "french", 2, "eb691e66-7037-4827-bf92-561f978acea7" },
                    { 5L, "english", 3, "eb691e66-7037-4827-bf92-561f978acea7" },
                    { 4L, "german", 3, "eb691e66-7037-4827-bf92-561f978acea7" },
                    { 10L, "english", 2, "03902199-fb13-4f7d-b4d7-138bc849977f" },
                    { 8L, "english", 2, "d26fba96-da21-43ac-8250-6b42374cc529" },
                    { 2L, "english", 2, "2647ef6e-3a78-4f27-8cd0-7e9478e9e8ef" },
                    { 3L, "german", 3, "e78986c7-9c10-4c87-b639-ba38fc64e10b" },
                    { 9L, "german", 3, "d26fba96-da21-43ac-8250-6b42374cc529" }
                });

            migrationBuilder.InsertData(
                table: "SkillRating",
                columns: new[] { "SkillRatingId", "Rating", "SkillName", "UserId" },
                values: new object[,]
                {
                    { 9L, 3, "Java", "85947f68-31e2-441c-983d-5b8df633835f" },
                    { 1L, 3, "C#", "2647ef6e-3a78-4f27-8cd0-7e9478e9e8ef" },
                    { 18L, 3, "HTML", "5a248924-7e9a-4de5-ad8b-86fc25163458" },
                    { 8L, 2, "Java", "5a248924-7e9a-4de5-ad8b-86fc25163458" },
                    { 5L, 2, "Java", "2647ef6e-3a78-4f27-8cd0-7e9478e9e8ef" },
                    { 10L, 2, "HTML", "2647ef6e-3a78-4f27-8cd0-7e9478e9e8ef" },
                    { 24L, 1, "C", "2647ef6e-3a78-4f27-8cd0-7e9478e9e8ef" },
                    { 2L, 3, "C#", "96fa3c64-5640-4ee9-a37a-bdacb8c43005" },
                    { 23L, 1, "C++", "9f39b3a5-9e09-465d-a63d-34c1eac909c4" },
                    { 17L, 2, "HTML", "9f39b3a5-9e09-465d-a63d-34c1eac909c4" },
                    { 7L, 1, "Java", "9f39b3a5-9e09-465d-a63d-34c1eac909c4" },
                    { 11L, 1, "HTML", "96fa3c64-5640-4ee9-a37a-bdacb8c43005" },
                    { 12L, 2, "HTML", "e78986c7-9c10-4c87-b639-ba38fc64e10b" },
                    { 26L, 2, "C", "90db1068-f144-4d86-9851-7473ff53d6e4" },
                    { 16L, 3, "HTML", "90db1068-f144-4d86-9851-7473ff53d6e4" },
                    { 14L, 2, "HTML", "d26fba96-da21-43ac-8250-6b42374cc529" },
                    { 25L, 3, "C", "03902199-fb13-4f7d-b4d7-138bc849977f" },
                    { 22L, 3, "C++", "03902199-fb13-4f7d-b4d7-138bc849977f" },
                    { 15L, 1, "HTML", "03902199-fb13-4f7d-b4d7-138bc849977f" },
                    { 21L, 3, "C++", "d26fba96-da21-43ac-8250-6b42374cc529" },
                    { 19L, 1, "HTML", "85947f68-31e2-441c-983d-5b8df633835f" }
                });

            migrationBuilder.InsertData(
                table: "SkillRating",
                columns: new[] { "SkillRatingId", "Rating", "SkillName", "UserId" },
                values: new object[,]
                {
                    { 13L, 3, "HTML", "eb691e66-7037-4827-bf92-561f978acea7" },
                    { 4L, 3, "C#", "eb691e66-7037-4827-bf92-561f978acea7" },
                    { 3L, 3, "C#", "e78986c7-9c10-4c87-b639-ba38fc64e10b" },
                    { 6L, 2, "Java", "e78986c7-9c10-4c87-b639-ba38fc64e10b" },
                    { 20L, 2, "C++", "e78986c7-9c10-4c87-b639-ba38fc64e10b" },
                    { 27L, 3, "C", "85947f68-31e2-441c-983d-5b8df633835f" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamId",
                table: "AspNetUsers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageRating_UserId",
                table: "LanguageRating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillRating_UserId",
                table: "SkillRating",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DepartmentId",
                table: "Teams",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LanguageRating");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "SkillRating");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SkillCategories");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}