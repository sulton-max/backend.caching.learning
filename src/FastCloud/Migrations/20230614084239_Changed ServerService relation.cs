using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastCloud.Migrations
{
    /// <inheritdoc />
    public partial class ChangedServerServicerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServerServices_Servers_ServerId1",
                table: "ServerServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ServerServices_Services_ServiceId1",
                table: "ServerServices");

            migrationBuilder.DropIndex(
                name: "IX_ServerServices_ServerId1",
                table: "ServerServices");

            migrationBuilder.DropIndex(
                name: "IX_ServerServices_ServiceId1",
                table: "ServerServices");

            migrationBuilder.DropColumn(
                name: "ServerId1",
                table: "ServerServices");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "ServerServices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ServerId1",
                table: "ServerServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId1",
                table: "ServerServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ServerServices_ServerId1",
                table: "ServerServices",
                column: "ServerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServerServices_ServiceId1",
                table: "ServerServices",
                column: "ServiceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServerServices_Servers_ServerId1",
                table: "ServerServices",
                column: "ServerId1",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServerServices_Services_ServiceId1",
                table: "ServerServices",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
