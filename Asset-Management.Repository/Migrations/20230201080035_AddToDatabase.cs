using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(name: "full_name", type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asset",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assetname = table.Column<string>(name: "asset_name", type: "nvarchar(max)", nullable: false),
                    specification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serialnumber = table.Column<string>(name: "serial_number", type: "nvarchar(max)", nullable: false),
                    purchaseyear = table.Column<int>(name: "purchase_year", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pic",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(name: "full_name", type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pic", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "request_asset",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    picname = table.Column<string>(name: "pic_name", type: "nvarchar(max)", nullable: false),
                    picaddress = table.Column<string>(name: "pic_address", type: "nvarchar(max)", nullable: false),
                    specification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestdate = table.Column<DateTime>(name: "request_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_request_asset", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asset_history",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assetid = table.Column<long>(name: "asset_id", type: "bigint", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    picid = table.Column<long>(name: "pic_id", type: "bigint", nullable: false),
                    senddate = table.Column<DateTime>(name: "send_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset_history", x => x.id);
                    table.ForeignKey(
                        name: "FK_asset_history_asset_asset_id",
                        column: x => x.assetid,
                        principalTable: "asset",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asset_history_pic_pic_id",
                        column: x => x.picid,
                        principalTable: "pic",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "approval",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestassetid = table.Column<long>(name: "request_asset_id", type: "bigint", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approval", x => x.id);
                    table.ForeignKey(
                        name: "FK_approval_request_asset_request_asset_id",
                        column: x => x.requestassetid,
                        principalTable: "request_asset",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "audit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assethistoryid = table.Column<long>(name: "asset_history_id", type: "bigint", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typewindows = table.Column<string>(name: "type_windows", type: "nvarchar(max)", nullable: false),
                    windowslicenseurl = table.Column<string>(name: "windows_license_url", type: "nvarchar(max)", nullable: false),
                    typeoffice = table.Column<string>(name: "type_office", type: "nvarchar(max)", nullable: false),
                    officelicenseurl = table.Column<string>(name: "office_license_url", type: "nvarchar(max)", nullable: false),
                    antivirus = table.Column<bool>(type: "bit", nullable: false),
                    assetphotourl = table.Column<string>(name: "asset_photo_url", type: "nvarchar(max)", nullable: false),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_audit", x => x.id);
                    table.ForeignKey(
                        name: "FK_audit_asset_history_asset_history_id",
                        column: x => x.assethistoryid,
                        principalTable: "asset_history",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_approval_request_asset_id",
                table: "approval",
                column: "request_asset_id");

            migrationBuilder.CreateIndex(
                name: "IX_asset_history_asset_id",
                table: "asset_history",
                column: "asset_id");

            migrationBuilder.CreateIndex(
                name: "IX_asset_history_pic_id",
                table: "asset_history",
                column: "pic_id");

            migrationBuilder.CreateIndex(
                name: "IX_audit_asset_history_id",
                table: "audit",
                column: "asset_history_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "approval");

            migrationBuilder.DropTable(
                name: "audit");

            migrationBuilder.DropTable(
                name: "request_asset");

            migrationBuilder.DropTable(
                name: "asset_history");

            migrationBuilder.DropTable(
                name: "asset");

            migrationBuilder.DropTable(
                name: "pic");
        }
    }
}
