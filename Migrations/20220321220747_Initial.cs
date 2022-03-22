using Microsoft.EntityFrameworkCore.Migrations;

namespace TempleSignup_Mission12_.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    TimeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeSlot = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.TimeId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Slots = table.Column<int>(nullable: false),
                    TimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "TimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignUps",
                columns: table => new
                {
                    SignUpId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupSize = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    AppointmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUps", x => x.SignUpId);
                    table.ForeignKey(
                        name: "FK_SignUps_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 1, "8:00am-9:00am" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 2, "9:00am-10:00am" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 3, "10:00am-11:00am" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 4, "11:00am-12:00pm" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 5, "12:00pm-1:00pm" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 6, "1:00pm-2:00pm" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 7, "2:00pm-3:00pm" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 8, "3:00pm-4:00pm" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 9, "4:00pm-5:00pm" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 10, "5:00pm-6:00pm" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 11, "6:00pm-7:00pm" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "TimeId", "TimeSlot" },
                values: new object[] { 12, "7:00pm-8:00pm" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "Date", "Location", "Slots", "TimeId" },
                values: new object[] { 1, "3/21/2022", "Layton Temple Visitors Center", 10, 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "Date", "Location", "Slots", "TimeId" },
                values: new object[] { 2, "3/22/2022", "Layton Temple Visitors Center", 10, 2 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "Date", "Location", "Slots", "TimeId" },
                values: new object[] { 3, "3/22/2022", "Layton Temple Visitors Center", 20, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeId",
                table: "Appointments",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_SignUps_AppointmentId",
                table: "SignUps",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignUps");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Times");
        }
    }
}
