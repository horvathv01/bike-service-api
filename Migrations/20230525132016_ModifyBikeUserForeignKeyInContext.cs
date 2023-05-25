using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModifyBikeUserForeignKeyInContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Users_OwnerId",
                table: "Bikes");

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "Bikes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Users_OwnerId",
                table: "Bikes",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Users_OwnerId",
                table: "Bikes");

            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "Bikes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Users_OwnerId",
                table: "Bikes",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
