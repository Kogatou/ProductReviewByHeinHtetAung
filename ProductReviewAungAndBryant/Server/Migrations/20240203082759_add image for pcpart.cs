using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductReviewAungAndBryant.Server.Migrations
{
    /// <inheritdoc />
    public partial class addimageforpcpart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PcPartImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    base64data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PcPartId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcPartImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PcPartImage_PcParts_PcPartId",
                        column: x => x.PcPartId,
                        principalTable: "PcParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(2091), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(2092) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(2093), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(2094) });

            migrationBuilder.UpdateData(
                table: "PcParts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1765), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "PcParts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1768), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1768) });

            migrationBuilder.UpdateData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1450), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1473), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1474) });

            migrationBuilder.UpdateData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1475), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1476) });

            migrationBuilder.UpdateData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1477), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated", "ReviewDate" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1932), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1933), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1931) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated", "ReviewDate" },
                values: new object[] { new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1935), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1936), new DateTime(2024, 2, 3, 16, 27, 59, 718, DateTimeKind.Local).AddTicks(1934) });

            migrationBuilder.CreateIndex(
                name: "IX_PcPartImage_PcPartId",
                table: "PcPartImage",
                column: "PcPartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PcPartImage");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(811), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(812) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(814), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(814) });

            migrationBuilder.UpdateData(
                table: "PcParts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(484), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(484) });

            migrationBuilder.UpdateData(
                table: "PcParts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(486), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(188), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(202) });

            migrationBuilder.UpdateData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(206), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(206) });

            migrationBuilder.UpdateData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(208), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(208) });

            migrationBuilder.UpdateData(
                table: "Reviewers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(210), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(211) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated", "ReviewDate" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(660), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(661), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(659) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated", "ReviewDate" },
                values: new object[] { new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(664), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(664), new DateTime(2024, 1, 29, 23, 17, 22, 346, DateTimeKind.Local).AddTicks(663) });
        }
    }
}
