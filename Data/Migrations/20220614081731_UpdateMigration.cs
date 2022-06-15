using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Author", "Body", "CreateDate", "Email", "PostId" },
                values: new object[,]
                {
                    { 1, "John Piper", "Nice blog.", new DateTime(2022, 6, 14, 16, 17, 31, 57, DateTimeKind.Local).AddTicks(466), "john@mail.com", 1 },
                    { 2, "John Jill", "Nice blog 2.", new DateTime(2022, 6, 14, 16, 17, 31, 57, DateTimeKind.Local).AddTicks(1067), "john@mail.com", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 6, 14, 16, 17, 31, 56, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 6, 14, 16, 17, 31, 52, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 6, 14, 16, 17, 31, 56, DateTimeKind.Local).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 6, 14, 16, 17, 31, 56, DateTimeKind.Local).AddTicks(7033));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 6, 14, 15, 58, 41, 771, DateTimeKind.Local).AddTicks(6685));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 6, 14, 15, 58, 41, 768, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 6, 14, 15, 58, 41, 771, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 6, 14, 15, 58, 41, 771, DateTimeKind.Local).AddTicks(4329));
        }
    }
}
