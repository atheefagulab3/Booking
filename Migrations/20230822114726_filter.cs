using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HBooking.Migrations
{
    /// <inheritdoc />
    public partial class filter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryMonth = table.Column<int>(type: "int", nullable: false),
                    ExpiryYear = table.Column<int>(type: "int", nullable: false),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVVNumber = table.Column<int>(type: "int", nullable: false),
                    HGuestGuestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_HGuests_HGuestGuestId",
                        column: x => x.HGuestGuestId,
                        principalTable: "HGuests",
                        principalColumn: "GuestId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_HGuestGuestId",
                table: "Payments",
                column: "HGuestGuestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
