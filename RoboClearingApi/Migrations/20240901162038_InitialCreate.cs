using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RoboClearingApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "robostatuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("robostatus_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("room_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("type_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "week_days",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    day = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("week_day_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "robots",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("robot_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_robots_robostatuses_status_id",
                        column: x => x.status_id,
                        principalTable: "robostatuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    RobotId = table.Column<int>(type: "integer", nullable: false),
                    clearing_id = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    week_day_id = table.Column<List<int>>(type: "integer[]", nullable: false),
                    start_clearing = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    end_clearing = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("schadule_pkey", x => x.id);
                    table.ForeignKey(
                        name: "FK_schedules_robots_RobotId",
                        column: x => x.RobotId,
                        principalTable: "robots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedules_rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedules_types_clearing_id",
                        column: x => x.clearing_id,
                        principalTable: "types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleWeekDay",
                columns: table => new
                {
                    SchedulesId = table.Column<int>(type: "integer", nullable: false),
                    WeekDayListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleWeekDay", x => new { x.SchedulesId, x.WeekDayListId });
                    table.ForeignKey(
                        name: "FK_ScheduleWeekDay_schedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "schedules",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleWeekDay_week_days_WeekDayListId",
                        column: x => x.WeekDayListId,
                        principalTable: "week_days",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_robostatuses_title",
                table: "robostatuses",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_robots_status_id",
                table: "robots",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_clearing_id",
                table: "schedules",
                column: "clearing_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_RobotId",
                table: "schedules",
                column: "RobotId");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_RoomId",
                table: "schedules",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWeekDay_WeekDayListId",
                table: "ScheduleWeekDay",
                column: "WeekDayListId");

            migrationBuilder.CreateIndex(
                name: "IX_types_title",
                table: "types",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_week_days_day",
                table: "week_days",
                column: "day",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleWeekDay");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "week_days");

            migrationBuilder.DropTable(
                name: "robots");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "types");

            migrationBuilder.DropTable(
                name: "robostatuses");
        }
    }
}
