﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DriverNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RaceWins = table.Column<int>(type: "INTEGER", nullable: false),
                    PolePositions = table.Column<int>(type: "INTEGER", nullable: false),
                    FastestLap = table.Column<int>(type: "INTEGER", nullable: false),
                    WorldChampionShip = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.id);
                    table.ForeignKey(
                        name: "FK_Achievements_Driver",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_DriverId",
                table: "Achievements",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
