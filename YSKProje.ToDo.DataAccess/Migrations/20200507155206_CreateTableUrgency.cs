using Microsoft.EntityFrameworkCore.Migrations;

namespace YSKProje.ToDo.DataAccess.Migrations
{
    public partial class CreateTableUrgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrgencyId",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Urgency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UrgencyId",
                table: "Tasks",
                column: "UrgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Urgency_UrgencyId",
                table: "Tasks",
                column: "UrgencyId",
                principalTable: "Urgency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Urgency_UrgencyId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Urgency");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UrgencyId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UrgencyId",
                table: "Tasks");
        }
    }
}
