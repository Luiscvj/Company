using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    Dept_NoId = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dept_Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.Dept_NoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Emp_NoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Birth_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    First_Name = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Last_Name = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Hire_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Emp_NoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.RoleId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dept_emp",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartamentId = table.Column<string>(type: "char(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    From_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dept_emp", x => new { x.DepartamentId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_dept_emp_department_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "department",
                        principalColumn: "Dept_NoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dept_emp_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Emp_NoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detp_manager",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(type: "char(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    From_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detp_manager", x => new { x.DepartmentId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_detp_manager_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "department",
                        principalColumn: "Dept_NoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detp_manager_employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employee",
                        principalColumn: "Emp_NoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "salary",
                columns: table => new
                {
                    From_DateId = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Emp_Salary = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    To_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Emp_NoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary", x => x.From_DateId);
                    table.ForeignKey(
                        name: "FK_salary_employee_Emp_NoId",
                        column: x => x.Emp_NoId,
                        principalTable: "employee",
                        principalColumn: "Emp_NoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "title",
                columns: table => new
                {
                    Title_Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    From_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Emp_NoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_title", x => new { x.Title_Id, x.From_Date });
                    table.ForeignKey(
                        name: "FK_title_employee_Emp_NoId",
                        column: x => x.Emp_NoId,
                        principalTable: "employee",
                        principalColumn: "Emp_NoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_user_roles_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_roles_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_dept_emp_EmployeeId",
                table: "dept_emp",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_detp_manager_EmployeeId",
                table: "detp_manager",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_salary_Emp_NoId",
                table: "salary",
                column: "Emp_NoId");

            migrationBuilder.CreateIndex(
                name: "IX_title_Emp_NoId",
                table: "title",
                column: "Emp_NoId");

            migrationBuilder.CreateIndex(
                name: "IX_user_Email",
                table: "user",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_UserId",
                table: "user_roles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dept_emp");

            migrationBuilder.DropTable(
                name: "detp_manager");

            migrationBuilder.DropTable(
                name: "salary");

            migrationBuilder.DropTable(
                name: "title");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
