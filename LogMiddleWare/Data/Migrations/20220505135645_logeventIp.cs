using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogMiddleWare.Data.Migrations
{
    public partial class logeventIp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Ip",
            //    table: "LogEvents",
            //    type: "nvarchar(max)",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ip",
                table: "LogEvents");
        }
    }
}
