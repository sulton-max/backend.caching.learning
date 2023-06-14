using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkForwarding.Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkPolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsShareable = table.Column<bool>(type: "bit", nullable: false),
                    ExpireTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkPolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortenedLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkPolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_LinkPolicies_LinkPolicyId",
                        column: x => x.LinkPolicyId,
                        principalTable: "LinkPolicies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Links_LinkPolicies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "LinkPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_LinkPolicyId",
                table: "Links",
                column: "LinkPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PolicyId",
                table: "Links",
                column: "PolicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "LinkPolicies");
        }
    }
}
