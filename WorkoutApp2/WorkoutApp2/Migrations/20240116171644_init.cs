using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutApp2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isTimed = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleGroup = table.Column<int>(type: "int", nullable: false),
                    rounds = table.Column<int>(type: "int", nullable: false),
                    exercisesCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuscleGroup = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Workout_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workout",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RepsWorkout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    reps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepsWorkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepsWorkout_Workout_Id",
                        column: x => x.Id,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimedWorkout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    workTime = table.Column<int>(type: "int", nullable: false),
                    restTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimedWorkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimedWorkout_Workout_Id",
                        column: x => x.Id,
                        principalTable: "Workout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_WorkoutId",
                table: "Exercise",
                column: "WorkoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "RepsWorkout");

            migrationBuilder.DropTable(
                name: "TimedWorkout");

            migrationBuilder.DropTable(
                name: "Workout");
        }
    }
}
