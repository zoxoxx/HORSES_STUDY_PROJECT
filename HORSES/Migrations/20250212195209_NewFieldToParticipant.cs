using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HORSES.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldToParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("city_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clothes_set",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    helmet_form = table.Column<string>(type: "character varying", nullable: true),
                    helmet_color = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clothes_set_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("company_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "competition",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    date_start = table.Column<DateOnly>(type: "date", nullable: true),
                    time_start = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("competition_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("gender_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "place_birth",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("place_birth_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "track",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("track_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "typ_horse",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("typ_horse_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_check_in",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("type_check_in_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phyo = table.Column<string>(type: "character varying", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: true),
                    company_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("owner_pkey", x => x.id);
                    table.ForeignKey(
                        name: "owner_company_id_fkey",
                        column: x => x.company_id,
                        principalTable: "company",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_is",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: true),
                    phyo = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    gender_id = table.Column<int>(type: "integer", nullable: true),
                    login = table.Column<string>(type: "character varying", nullable: true),
                    password = table.Column<string>(type: "character varying", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: true),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    weight = table.Column<decimal>(type: "numeric", nullable: true),
                    category_id = table.Column<int>(type: "integer", nullable: true),
                    city_id = table.Column<int>(type: "integer", nullable: true),
                    distinct_code = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_is_pkey", x => x.id);
                    table.ForeignKey(
                        name: "user_is_category_id_fkey",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_is_city_id_fkey",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_is_gender_id_fkey",
                        column: x => x.gender_id,
                        principalTable: "gender",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "user_is_role_id_fkey",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "check_in",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_check_in_id = table.Column<int>(type: "integer", nullable: true),
                    sequence_number = table.Column<int>(type: "integer", nullable: true),
                    prize_fund = table.Column<decimal>(type: "numeric", nullable: true),
                    time_start = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    date_start = table.Column<DateOnly>(type: "date", nullable: true),
                    distance = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    type_horse_id_collection = table.Column<string>(type: "character varying", nullable: true),
                    age = table.Column<string>(type: "character varying", nullable: true),
                    place_birth_id_collection = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("check_in_pkey", x => x.id);
                    table.ForeignKey(
                        name: "check_in_type_check_in_id_fkey",
                        column: x => x.type_check_in_id,
                        principalTable: "type_check_in",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "horse",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gender_id = table.Column<int>(type: "integer", nullable: true),
                    typ_id = table.Column<int>(type: "integer", nullable: true),
                    phyo_trener = table.Column<string>(type: "character varying", nullable: true),
                    owner_id = table.Column<int>(type: "integer", nullable: true),
                    birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    name = table.Column<string>(type: "character varying", nullable: true),
                    place_birth_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("horse_pkey", x => x.id);
                    table.ForeignKey(
                        name: "horse_gender_id_fkey",
                        column: x => x.gender_id,
                        principalTable: "gender",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "horse_owner_id_fkey",
                        column: x => x.owner_id,
                        principalTable: "owner",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "horse_place_birth_id_fkey",
                        column: x => x.place_birth_id,
                        principalTable: "place_birth",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "horse_typ_id_fkey",
                        column: x => x.typ_id,
                        principalTable: "typ_horse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "donation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    donation_summ = table.Column<int>(type: "integer", nullable: true),
                    horse_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("donation_pkey", x => x.id);
                    table.ForeignKey(
                        name: "donation_horse_id_fkey",
                        column: x => x.horse_id,
                        principalTable: "horse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "participant",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    disqualification = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    clothes_set_id = table.Column<int>(type: "integer", nullable: true),
                    horse_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("participant_pkey", x => x.id);
                    table.ForeignKey(
                        name: "participant_clothes_set_id_fkey",
                        column: x => x.clothes_set_id,
                        principalTable: "clothes_set",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "participant_horse_id_fkey",
                        column: x => x.horse_id,
                        principalTable: "horse",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "participant_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "user_is",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "check_in_result",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    check_in_id = table.Column<int>(type: "integer", nullable: true),
                    indicator = table.Column<string>(type: "character varying", nullable: true),
                    result = table.Column<decimal>(type: "numeric", nullable: true),
                    participant_id = table.Column<int>(type: "integer", nullable: true),
                    time_end = table.Column<TimeOnly>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("check_in_result_pkey", x => x.id);
                    table.ForeignKey(
                        name: "check_in_result_check_in_id_fkey",
                        column: x => x.check_in_id,
                        principalTable: "check_in",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "check_in_result_participant_id_fkey",
                        column: x => x.participant_id,
                        principalTable: "participant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "competition_and_check_in",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    competition_id = table.Column<int>(type: "integer", nullable: true),
                    check_in_id = table.Column<int>(type: "integer", nullable: true),
                    participant_id = table.Column<int>(type: "integer", nullable: true),
                    track_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("competition_and_check_in_pkey", x => x.id);
                    table.ForeignKey(
                        name: "competition_and_check_in_check_in_id_fkey",
                        column: x => x.check_in_id,
                        principalTable: "check_in",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "competition_and_check_in_competition_id_fkey",
                        column: x => x.competition_id,
                        principalTable: "competition",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "competition_and_check_in_participant_id_fkey",
                        column: x => x.participant_id,
                        principalTable: "participant",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "competition_and_check_in_track_id_fkey",
                        column: x => x.track_id,
                        principalTable: "track",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "violation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    violations = table.Column<string>(type: "character varying", nullable: true),
                    participant_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("violation_pkey", x => x.id);
                    table.ForeignKey(
                        name: "violation_participant_id_fkey",
                        column: x => x.participant_id,
                        principalTable: "participant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_check_in_type_check_in_id",
                table: "check_in",
                column: "type_check_in_id");

            migrationBuilder.CreateIndex(
                name: "IX_check_in_result_check_in_id",
                table: "check_in_result",
                column: "check_in_id");

            migrationBuilder.CreateIndex(
                name: "IX_check_in_result_participant_id",
                table: "check_in_result",
                column: "participant_id");

            migrationBuilder.CreateIndex(
                name: "IX_competition_and_check_in_check_in_id",
                table: "competition_and_check_in",
                column: "check_in_id");

            migrationBuilder.CreateIndex(
                name: "IX_competition_and_check_in_competition_id",
                table: "competition_and_check_in",
                column: "competition_id");

            migrationBuilder.CreateIndex(
                name: "IX_competition_and_check_in_participant_id",
                table: "competition_and_check_in",
                column: "participant_id");

            migrationBuilder.CreateIndex(
                name: "IX_competition_and_check_in_track_id",
                table: "competition_and_check_in",
                column: "track_id");

            migrationBuilder.CreateIndex(
                name: "IX_donation_horse_id",
                table: "donation",
                column: "horse_id");

            migrationBuilder.CreateIndex(
                name: "IX_horse_gender_id",
                table: "horse",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_horse_owner_id",
                table: "horse",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_horse_place_birth_id",
                table: "horse",
                column: "place_birth_id");

            migrationBuilder.CreateIndex(
                name: "IX_horse_typ_id",
                table: "horse",
                column: "typ_id");

            migrationBuilder.CreateIndex(
                name: "IX_owner_company_id",
                table: "owner",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_participant_clothes_set_id",
                table: "participant",
                column: "clothes_set_id");

            migrationBuilder.CreateIndex(
                name: "IX_participant_horse_id",
                table: "participant",
                column: "horse_id");

            migrationBuilder.CreateIndex(
                name: "IX_participant_user_id",
                table: "participant",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_is_category_id",
                table: "user_is",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_is_city_id",
                table: "user_is",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_is_gender_id",
                table: "user_is",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_is_role_id",
                table: "user_is",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_violation_participant_id",
                table: "violation",
                column: "participant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "check_in_result");

            migrationBuilder.DropTable(
                name: "competition_and_check_in");

            migrationBuilder.DropTable(
                name: "donation");

            migrationBuilder.DropTable(
                name: "violation");

            migrationBuilder.DropTable(
                name: "check_in");

            migrationBuilder.DropTable(
                name: "competition");

            migrationBuilder.DropTable(
                name: "track");

            migrationBuilder.DropTable(
                name: "participant");

            migrationBuilder.DropTable(
                name: "type_check_in");

            migrationBuilder.DropTable(
                name: "clothes_set");

            migrationBuilder.DropTable(
                name: "horse");

            migrationBuilder.DropTable(
                name: "user_is");

            migrationBuilder.DropTable(
                name: "owner");

            migrationBuilder.DropTable(
                name: "place_birth");

            migrationBuilder.DropTable(
                name: "typ_horse");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
