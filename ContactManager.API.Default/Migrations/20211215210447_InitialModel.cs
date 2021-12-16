using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsManager.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    StreetName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("074f4741-d41f-4058-af2c-2aa253296129"), "Lake Norwoodfurt", "Virgin Islands, British", "Thad_Moises@hotmail.com", "Thad", "Thad Moises", "Moises", "(208)-626-9720", "Wyoming", "America Dam", "08229" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("4c00f799-8391-4f36-b874-77f50f0444fa"), "North Mable", "Mexico", "Tatyana.Brody@yahoo.com", "Tatyana", "Tatyana Brody", "Brody", "(972)-956-0561", "Kansas", "Naomi Square", "89395-8246" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("81aeec6d-f8da-4ccd-b23a-0eb8d1c5c508"), "Myronmouth", "Norway", "Katelyn64@hotmail.com", "Katelyn", "Katelyn Sabrina", "Sabrina", "(008)-855-8647", "South Carolina", "Schimmel Loop", "60085" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("a25adf3c-7915-442e-b334-8ad434c2e8ce"), "Smithammouth", "Monaco", "Jaydon_Bella@yahoo.com", "Jaydon", "Jaydon Bella", "Bella", "(825)-416-5760", "West Virginia", "Cayla Corners", "00019" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("cb8ddd3b-23b5-411f-b79b-8d013c14cd31"), "East Rickie", "Germany", "Ben_Cristian@hotmail.com", "Ben", "Ben Cristian", "Cristian", "(460)-402-8378", "Mississippi", "Estella Prairie", "16964" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("cd3a0849-231c-4b0e-b8e7-854634e98ca8"), "East Laverneburgh", "Montenegro", "Daisy86@yahoo.com", "Daisy", "Daisy Faye", "Faye", "(069)-341-2149", "New Jersey", "Legros Villages", "63110-9501" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("e6173ebc-31c0-4753-840b-48cf507ad60e"), "Quitzonshire", "Greece", "Jake3@hotmail.com", "Jake", "Jake Rolando", "Rolando", "(176)-263-3486", "South Carolina", "Dee Grove", "55596" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("eae05c1c-d450-4220-a495-d95e0f0dc765"), "Port Ona", "Honduras", "Kendra.Myra74@gmail.com", "Kendra", "Kendra Myra", "Myra", "(993)-272-2011", "Ohio", "Ed Squares", "36479-1513" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("ee605bb4-4a87-4f4e-b286-a0bb48b4b17b"), "Port Sylvia", "Puerto Rico", "Jocelyn93@yahoo.com", "Jocelyn", "Jocelyn Johanna", "Johanna", "(421)-910-5548", "Louisiana", "Ellie Meadow", "92533" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "City", "Country", "Email", "FirstName", "FullName", "LastName", "Phone", "State", "StreetName", "ZipCode" },
                values: new object[] { new Guid("fa035e8b-7ee3-42a8-96d5-38bffee9b93c"), "West Kaylahland", "Iceland", "Lessie23@yahoo.com", "Lessie", "Lessie Evie", "Evie", "(795)-791-7733", "Vermont", "Bell Shoals", "54599" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
