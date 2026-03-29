using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuditOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "workers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "updated_by",
                table: "workers",
                type: "nvarchar(61)",
                maxLength: 61,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(61)",
                oldMaxLength: 61);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "sites",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "updated_by",
                table: "sites",
                type: "nvarchar(61)",
                maxLength: 61,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(61)",
                oldMaxLength: 61);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "compliance_documents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "updated_by",
                table: "compliance_documents",
                type: "nvarchar(61)",
                maxLength: 61,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(61)",
                oldMaxLength: 61);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "workers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updated_by",
                table: "workers",
                type: "nvarchar(61)",
                maxLength: 61,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(61)",
                oldMaxLength: 61,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "sites",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updated_by",
                table: "sites",
                type: "nvarchar(61)",
                maxLength: 61,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(61)",
                oldMaxLength: 61,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_on",
                table: "compliance_documents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "updated_by",
                table: "compliance_documents",
                type: "nvarchar(61)",
                maxLength: 61,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(61)",
                oldMaxLength: 61,
                oldNullable: true);
        }
    }
}
