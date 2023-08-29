using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropertEase_Database.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SizeInSqft = table.Column<int>(type: "int", nullable: false),
                    PricePerSqft = table.Column<double>(type: "float", nullable: false),
                    NoOfBedrooms = table.Column<int>(type: "int", nullable: false),
                    NoOfBathrooms = table.Column<int>(type: "int", nullable: false),
                    MaidRoom = table.Column<bool>(type: "bit", nullable: false),
                    UnFurnished = table.Column<bool>(type: "bit", nullable: false),
                    Balcony = table.Column<bool>(type: "bit", nullable: false),
                    BarbecueArea = table.Column<bool>(type: "bit", nullable: false),
                    BuiltInWardrobes = table.Column<bool>(type: "bit", nullable: false),
                    CentralAc = table.Column<bool>(type: "bit", nullable: false),
                    ChildrensPlayArea = table.Column<bool>(type: "bit", nullable: false),
                    ChildrensPool = table.Column<bool>(type: "bit", nullable: false),
                    Concierge = table.Column<bool>(type: "bit", nullable: false),
                    CoveredParking = table.Column<bool>(type: "bit", nullable: false),
                    KitchenAppliances = table.Column<bool>(type: "bit", nullable: false),
                    LobbyInBuilding = table.Column<bool>(type: "bit", nullable: false),
                    MaidService = table.Column<bool>(type: "bit", nullable: false),
                    Networked = table.Column<bool>(type: "bit", nullable: false),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    PrivateGarden = table.Column<bool>(type: "bit", nullable: false),
                    PrivateGym = table.Column<bool>(type: "bit", nullable: false),
                    PrivateJacuzzi = table.Column<bool>(type: "bit", nullable: false),
                    PrivatePool = table.Column<bool>(type: "bit", nullable: false),
                    Security = table.Column<bool>(type: "bit", nullable: false),
                    SharedGym = table.Column<bool>(type: "bit", nullable: false),
                    Study = table.Column<bool>(type: "bit", nullable: false),
                    SharedPool = table.Column<bool>(type: "bit", nullable: false),
                    SharedSpa = table.Column<bool>(type: "bit", nullable: false),
                    VastuCompliant = table.Column<bool>(type: "bit", nullable: false),
                    ViewOfLandmark = table.Column<bool>(type: "bit", nullable: false),
                    ViewOfWater = table.Column<bool>(type: "bit", nullable: false),
                    WalkInCloset = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
