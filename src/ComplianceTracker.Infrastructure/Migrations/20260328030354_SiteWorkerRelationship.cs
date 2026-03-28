using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SiteWorkerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workers_sites_site_id",
                table: "workers");

            migrationBuilder.AddForeignKey(
                name: "fk_workers_sites_site_id",
                table: "workers",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_workers_sites_site_id",
                table: "workers");

            migrationBuilder.AddForeignKey(
                name: "fk_workers_sites_site_id",
                table: "workers",
                column: "site_id",
                principalTable: "sites",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
