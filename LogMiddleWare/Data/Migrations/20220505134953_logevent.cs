using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogMiddleWare.Data.Migrations
{
    public partial class logevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "LogEvents",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        MessageTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Event = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        QueryString = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LogEvents", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEvents");
        }
    }
}
