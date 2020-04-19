using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tweetbook.Data.Migrations
{
    public partial class ModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Posts");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Posts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Iin",
                table: "Posts",
                maxLength: 12,
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Posts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Iin",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Posts",
                nullable: true);
        }
    }
}
