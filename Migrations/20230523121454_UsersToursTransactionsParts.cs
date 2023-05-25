using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class UsersToursTransactionsParts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_Transaction_TransactionId",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Users_UserId",
                table: "Tour");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Users_UserId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tour",
                table: "Tour");

            migrationBuilder.DropIndex(
                name: "IX_Tour_UserId",
                table: "Tour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Part",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tour");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Tour",
                newName: "Tours");

            migrationBuilder.RenameTable(
                name: "Part",
                newName: "Parts");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_UserId",
                table: "Transactions",
                newName: "IX_Transactions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Part_TransactionId",
                table: "Parts",
                newName: "IX_Parts_TransactionId");

            migrationBuilder.AlterColumn<long>(
                name: "TransactionId",
                table: "Parts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tours",
                table: "Tours",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TourUser",
                columns: table => new
                {
                    ParticipantsId = table.Column<long>(type: "bigint", nullable: false),
                    ToursId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourUser", x => new { x.ParticipantsId, x.ToursId });
                    table.ForeignKey(
                        name: "FK_TourUser_Tours_ToursId",
                        column: x => x.ToursId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourUser_Users_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourUser_ToursId",
                table: "TourUser",
                column: "ToursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Transactions_TransactionId",
                table: "Parts",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Transactions_TransactionId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_UserId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "TourUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tours",
                table: "Tours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Tours",
                newName: "Tour");

            migrationBuilder.RenameTable(
                name: "Parts",
                newName: "Part");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_UserId",
                table: "Transaction",
                newName: "IX_Transaction_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Parts_TransactionId",
                table: "Part",
                newName: "IX_Part_TransactionId");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Tour",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TransactionId",
                table: "Part",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tour",
                table: "Tour",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Part",
                table: "Part",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_UserId",
                table: "Tour",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Transaction_TransactionId",
                table: "Part",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Users_UserId",
                table: "Tour",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Users_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
