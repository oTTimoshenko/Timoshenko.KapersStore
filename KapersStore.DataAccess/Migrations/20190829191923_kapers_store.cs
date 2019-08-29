using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KapersStore.DataAccess.Migrations
{
    public partial class kapers_store : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kapers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    ImageSource = table.Column<string>(maxLength: 500, nullable: false),
                    ImageAltText = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kapers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nickname = table.Column<string>(maxLength: 18, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Days = table.Column<int>(nullable: false, defaultValue: 1),
                    KaperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Kapers_KaperId",
                        column: x => x.KaperId,
                        principalTable: "Kapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    KaperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Kapers_KaperId",
                        column: x => x.KaperId,
                        principalTable: "Kapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kapers",
                columns: new[] { "Id", "Description", "ImageAltText", "ImageSource", "Name" },
                values: new object[,]
                {
                    { 1, "Description of Kaper1", "Kaper1", "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", "Kaper1" },
                    { 2, "Description of Kaper2", "Kaper2", "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", "Kaper2" },
                    { 3, "Description of Kaper3", "Kaper3", "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", "Kaper3" },
                    { 4, "Description of Kaper4", "Kaper4", "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", "Kaper4" },
                    { 5, "Description of Kaper5", "Kaper5", "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", "Kaper5" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Days", "Description", "KaperId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 7, "Description1", 1, "Subscription1", 1200m },
                    { 2, 1, "Description2", 1, "Subscription2", 1999m },
                    { 3, 10, "Description3", 1, "Subscription3", 1500m },
                    { 4, 31, "Description4", 2, "Subscription4", 1200m },
                    { 5, 21, "Description5", 2, "Subscription5", 1200m },
                    { 6, 14, "Description6", 2, "Subscription6", 1999m },
                    { 7, 1, "Description7", 3, "Subscription7", 1500m },
                    { 8, 7, "Description8", 3, "Subscription8", 1500m },
                    { 9, 7, "Description9", 3, "Subscription9", 2000m },
                    { 10, 14, "Description10", 4, "Subscription10", 1200m },
                    { 11, 1, "Description11", 4, "Subscription11", 1999m },
                    { 12, 7, "Description12", 4, "Subscription12", 1200m },
                    { 13, 21, "Description13", 5, "Subscription13", 1500m },
                    { 14, 7, "Description14", 5, "Subscription14", 2000m },
                    { 15, 1, "Description15", 5, "Subscription15", 1200m },
                    { 16, 7, "Description16", 5, "Subscription16", 1500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_KaperId",
                table: "Comments",
                column: "KaperId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_KaperId",
                table: "Subscriptions",
                column: "KaperId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Kapers");
        }
    }
}
