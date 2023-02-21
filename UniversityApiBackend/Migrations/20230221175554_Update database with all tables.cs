using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApiBackend.Migrations
{
    public partial class Updatedatabasewithalltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "BaseEntity");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "BaseEntity",
                newName: "Discriminator");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Course_Name",
                table: "BaseEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedByID",
                table: "BaseEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeletedByID",
                table: "BaseEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                table: "BaseEntity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "BaseEntity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "List",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "BaseEntity",
                type: "nvarchar(280)",
                maxLength: 280,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Student_Name",
                table: "BaseEntity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByID",
                table: "BaseEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "User_LastName",
                table: "BaseEntity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "BaseEntity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CategoryCourse",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCourse", x => new { x.CategoriesId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CategoryCourse_BaseEntity_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCourse_BaseEntity_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_BaseEntity_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_BaseEntity_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CourseID",
                table: "BaseEntity",
                column: "CourseID",
                unique: true,
                filter: "[CourseID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CreatedByID",
                table: "BaseEntity",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_DeletedByID",
                table: "BaseEntity",
                column: "DeletedByID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UpdatedByID",
                table: "BaseEntity",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCourse_CoursesId",
                table: "CategoryCourse",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_CourseID",
                table: "BaseEntity",
                column: "CourseID",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_CreatedByID",
                table: "BaseEntity",
                column: "CreatedByID",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_DeletedByID",
                table: "BaseEntity",
                column: "DeletedByID",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_UpdatedByID",
                table: "BaseEntity",
                column: "UpdatedByID",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_CourseID",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_CreatedByID",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_DeletedByID",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_UpdatedByID",
                table: "BaseEntity");

            migrationBuilder.DropTable(
                name: "CategoryCourse");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_CourseID",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_CreatedByID",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_DeletedByID",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_UpdatedByID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Course_Name",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "DeletedByID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Dob",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "List",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Student_Name",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedByID",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "User_LastName",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Users",
                newName: "UpdatedBy");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objectives = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });
        }
    }
}
