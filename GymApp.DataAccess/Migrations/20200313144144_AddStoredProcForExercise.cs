using Microsoft.EntityFrameworkCore.Migrations;

namespace GymApp.DataAccess.Migrations
{
    public partial class AddStoredProcForExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetExercises 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.Exercises
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetExercise 
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.Exercises  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateExercise
	                                @Id int,
	                                @Name varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.Exercises
                                     SET  Name = @Name
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteExercise
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.Exercises
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateExercise
                                   @Name varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.Exercises(Name)
                                    VALUES (@Name)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetExercises");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetExercise");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateExercise");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteExercise");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateExercise");
        }
    }
}
