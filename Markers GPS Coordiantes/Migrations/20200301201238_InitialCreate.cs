using Microsoft.EntityFrameworkCore.Migrations;

namespace Markers_GPS_Coordiantes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markers",
                columns: table => new
                {
                    Markerid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Centre_No = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Centre_Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ID_Number = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Paper_No = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Postal_Code = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Mobile_No = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Work_Tel = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markers", x => x.Markerid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markers");
        }
    }
}
