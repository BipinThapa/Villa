using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Villa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDataToVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "Bhairuwa,AirPort,Nepal", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/615097616.jpg?k=d3e34f137ebfb9de984a067006063753fb96a633cc96db9e5691f05df03e67d9&o=&hp=1", "Tiger palace", 4, 200.0, 500, null },
                    { 2, null, "Kathmandu,Nepal", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/615097642.jpg?k=dab2a4497b657504196a17c8cb8baaa08fec94ce43abe9dffa8795ac829b4913&o=&hp=1", "darbar Palace", 4, 300.0, 600, null },
                    { 3, null, "manigram,Butwal,Nepal", "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/16/73/41/a5/lobby-reception.jpg?w=700&h=-1&s=1", "Manigram Palace", 5, 100.0, 400, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
