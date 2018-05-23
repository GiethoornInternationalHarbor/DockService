using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DockService.Infrastructure.Migrations
{
	public partial class Trackfix01 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_Ships",
				table: "Ships");

			migrationBuilder.AddColumn<Guid>(
				name: "DBKey",
				table: "Ships",
				nullable: false,
				defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

			migrationBuilder.AddPrimaryKey(
				name: "PK_Ships",
				table: "Ships",
				column: "DBKey");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_Ships",
				table: "Ships");

			migrationBuilder.DropColumn(
				name: "DBKey",
				table: "Ships");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Ships",
				table: "Ships",
				column: "Id");
		}
	}
}