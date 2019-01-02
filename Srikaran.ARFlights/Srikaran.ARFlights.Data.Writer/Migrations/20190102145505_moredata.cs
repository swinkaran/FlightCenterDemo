using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Srikaran.ARFlights.Data.Writer.Migrations
{
    public partial class moredata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1L,
                column: "BookingDate",
                value: new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2L,
                columns: new[] { "BookingDate", "PassengerId" },
                values: new object[] { new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), 113 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "FlightNo", "PassengerId" },
                values: new object[,]
                {
                    { 11L, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), "QA11", 112 },
                    { 12L, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), "QA201", 114 }
                });

            migrationBuilder.UpdateData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 114,
                column: "PassengerName",
                value: "Ella");

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "PassengerName" },
                values: new object[,]
                {
                    { 129, "Chris" },
                    { 128, "Zara" },
                    { 127, "Rafael" },
                    { 126, "Julie" },
                    { 125, "Precious" },
                    { 124, "Deshawn" },
                    { 123, "Jamiya" },
                    { 120, "Joy" },
                    { 121, "Luke" },
                    { 130, "Jesse" },
                    { 119, "Devon" },
                    { 118, "Brian" },
                    { 117, "Ada" },
                    { 116, "Rayna" },
                    { 115, "Chris" },
                    { 122, "Mohammad" },
                    { 131, "Angelica" }
                });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 3L,
                columns: new[] { "BookingDate", "PassengerId" },
                values: new object[] { new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), 115 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "FlightNo", "PassengerId" },
                values: new object[,]
                {
                    { 13L, new DateTime(2019, 2, 3, 0, 0, 0, 0, DateTimeKind.Local), "QA11", 116 },
                    { 4L, new DateTime(2019, 2, 2, 0, 0, 0, 0, DateTimeKind.Local), "VM24", 117 },
                    { 14L, new DateTime(2019, 2, 3, 0, 0, 0, 0, DateTimeKind.Local), "QA201", 118 },
                    { 5L, new DateTime(2019, 2, 3, 0, 0, 0, 0, DateTimeKind.Local), "VM24", 119 },
                    { 15L, new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "QA11", 120 },
                    { 6L, new DateTime(2019, 2, 3, 0, 0, 0, 0, DateTimeKind.Local), "VM24", 121 },
                    { 16L, new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "QA201", 122 },
                    { 7L, new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "QA201", 123 },
                    { 17L, new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "QA201", 124 },
                    { 8L, new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "VM24", 125 },
                    { 18L, new DateTime(2019, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), "QA201", 126 },
                    { 9L, new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "VM24", 127 },
                    { 19L, new DateTime(2019, 2, 7, 0, 0, 0, 0, DateTimeKind.Local), "QA11", 128 },
                    { 10L, new DateTime(2019, 2, 5, 0, 0, 0, 0, DateTimeKind.Local), "QA201", 129 },
                    { 20L, new DateTime(2019, 2, 7, 0, 0, 0, 0, DateTimeKind.Local), "QA201", 130 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 130);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1L,
                column: "BookingDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 2L,
                columns: new[] { "BookingDate", "PassengerId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112 });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 3L,
                columns: new[] { "BookingDate", "PassengerId" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113 });

            migrationBuilder.UpdateData(
                table: "Passengers",
                keyColumn: "PassengerId",
                keyValue: 114,
                column: "PassengerName",
                value: "Chris");
        }
    }
}
