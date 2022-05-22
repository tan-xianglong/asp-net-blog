using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CreateDate", "Email", "Message", "Name", "PhoneNumber" },
                values: new object[] { 1, new DateTime(2022, 5, 22, 15, 12, 29, 854, DateTimeKind.Local).AddTicks(3218), "john@mail.com", "Please contact me.", "John Piper", "12345" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "CreateDate", "Subtitle", "Title" },
                values: new object[,]
                {
                    { 1, "Loren Ipsum", new DateTime(2022, 5, 22, 15, 12, 29, 850, DateTimeKind.Local).AddTicks(6012), "Problems look mighty small from 150 miles up", "Man must explore, and this is exploration at its greatest" },
                    { 2, "Loren Ipsum", new DateTime(2022, 5, 22, 15, 12, 29, 854, DateTimeKind.Local).AddTicks(711), null, "I believe every human has a finite number of heartbeats. I don't intend to waste any of mine." },
                    { 3, "Loren Ipsum", new DateTime(2022, 5, 22, 15, 12, 29, 854, DateTimeKind.Local).AddTicks(875), "We predict too much for the next year and yet far too little for the next ten.", "Science has not yet mastered prophecy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
