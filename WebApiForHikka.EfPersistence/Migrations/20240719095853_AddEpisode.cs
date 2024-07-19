﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiForHikka.EfPersistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEpisode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TagAnimes_FirstId",
                table: "TagAnimes");

            migrationBuilder.DropIndex(
                name: "IX_Relateds_FirstId",
                table: "Relateds");

            migrationBuilder.DropIndex(
                name: "IX_DubAnimes_FirstId",
                table: "DubAnimes");

            migrationBuilder.DropIndex(
                name: "IX_CountryAnimes_FirstId",
                table: "CountryAnimes");

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    AirDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsFiller = table.Column<bool>(type: "boolean", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SeoAdditionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_SeoAdditions_SeoAdditionId",
                        column: x => x.SeoAdditionId,
                        principalTable: "SeoAdditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    FirstId = table.Column<Guid>(type: "uuid", nullable: false),
                    SecondId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_AnimeGroups_SecondId",
                        column: x => x.SecondId,
                        principalTable: "AnimeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seasons_Animes_FirstId",
                        column: x => x.FirstId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagAnimes_FirstId_SecondId",
                table: "TagAnimes",
                columns: new[] { "FirstId", "SecondId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Relateds_FirstId_SecondId",
                table: "Relateds",
                columns: new[] { "FirstId", "SecondId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DubAnimes_FirstId_SecondId",
                table: "DubAnimes",
                columns: new[] { "FirstId", "SecondId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryAnimes_FirstId_SecondId",
                table: "CountryAnimes",
                columns: new[] { "FirstId", "SecondId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeoAdditionId",
                table: "Episodes",
                column: "SeoAdditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_FirstId_SecondId",
                table: "Seasons",
                columns: new[] { "FirstId", "SecondId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SecondId",
                table: "Seasons",
                column: "SecondId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_TagAnimes_FirstId_SecondId",
                table: "TagAnimes");

            migrationBuilder.DropIndex(
                name: "IX_Relateds_FirstId_SecondId",
                table: "Relateds");

            migrationBuilder.DropIndex(
                name: "IX_DubAnimes_FirstId_SecondId",
                table: "DubAnimes");

            migrationBuilder.DropIndex(
                name: "IX_CountryAnimes_FirstId_SecondId",
                table: "CountryAnimes");

            migrationBuilder.CreateIndex(
                name: "IX_TagAnimes_FirstId",
                table: "TagAnimes",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Relateds_FirstId",
                table: "Relateds",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_DubAnimes_FirstId",
                table: "DubAnimes",
                column: "FirstId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryAnimes_FirstId",
                table: "CountryAnimes",
                column: "FirstId");
        }
    }
}
