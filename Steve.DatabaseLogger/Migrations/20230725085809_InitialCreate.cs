using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Steve.DatabaseLogger.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parameters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
                    LoggedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoggedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallerInfo_Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallerInfo_FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallerInfo_LineNumber = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: true),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
