using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopApp.Migrations
{
    public partial class addedcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a19567c6-2322-422d-84a9-dda824ebe07a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f2d64dad-efaa-47ce-b618-d1a70e83a6f1", "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2d64dad-efaa-47ce-b618-d1a70e83a6f1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0");

            migrationBuilder.RenameColumn(
                name: "ProductImageURL",
                table: "Products",
                newName: "ProductImageUrl");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc49271b-f452-4ddf-aafe-a058033e5d27", "2696c682-9c77-4648-b75a-fb93569a5c7b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b3b7665-c2d5-485b-8efc-3551de13f260", "00905f8d-47b8-47c2-81f6-f83baee1afcf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de746d53-80b6-4030-a399-d074c197c798", 0, "cb95cf9f-14f0-4cdd-a1e7-ae86148809a1", "admin@admin.com", false, "Admin Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEJy483rLOCEzpDDHw/ly/URMUAkzFD/l03AgdlOJ572yKSlzJltIqytb8MIbiccHng==", "031-84468", false, "dc8d5a52-7202-491f-b003-f3aab818cdd3", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "199499d1-57f7-435a-8487-261999aa8f03", 0, "8548196b-858f-4d6e-9e68-495d22080cc6", "customer@customer.com", false, "customer customer", false, null, "CUSTOMER@CUSTOMER.COM", "CUSTOMER", "AQAAAAEAACcQAAAAEJX22RkTcKrqfMPav6/Kdv8PpsIDX9ChvGPxii3ZlwKTsjt+INtky9Rihumpb7xeSQ==", "031-32321", false, "5af1d67d-7e6d-4e1b-9c3b-4f245f1e1fc9", false, "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc49271b-f452-4ddf-aafe-a058033e5d27", "de746d53-80b6-4030-a399-d074c197c798" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc49271b-f452-4ddf-aafe-a058033e5d27", "199499d1-57f7-435a-8487-261999aa8f03" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BillingAddress", "City", "Country", "DefaultShippingAddress", "ZipCode" },
                values: new object[] { "de746d53-80b6-4030-a399-d074c197c798", null, "Göteborg", "Sweden", "Götgatan 9", "41105" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BillingAddress", "City", "Country", "DefaultShippingAddress", "ZipCode" },
                values: new object[] { "199499d1-57f7-435a-8487-261999aa8f03", null, "Uppsala", "Sweden", "dasdwas 9", "321532" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerId", "OrderDate" },
                values: new object[] { "199499d1-57f7-435a-8487-261999aa8f03", new DateTime(2022, 1, 19, 10, 36, 41, 235, DateTimeKind.Local).AddTicks(1443) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b3b7665-c2d5-485b-8efc-3551de13f260");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc49271b-f452-4ddf-aafe-a058033e5d27", "199499d1-57f7-435a-8487-261999aa8f03" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc49271b-f452-4ddf-aafe-a058033e5d27", "de746d53-80b6-4030-a399-d074c197c798" });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "199499d1-57f7-435a-8487-261999aa8f03");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "de746d53-80b6-4030-a399-d074c197c798");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc49271b-f452-4ddf-aafe-a058033e5d27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "199499d1-57f7-435a-8487-261999aa8f03");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de746d53-80b6-4030-a399-d074c197c798");

            migrationBuilder.RenameColumn(
                name: "ProductImageUrl",
                table: "Products",
                newName: "ProductImageURL");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2d64dad-efaa-47ce-b618-d1a70e83a6f1", "020c222c-8f1f-4a8b-9ebf-1c1d582b0d58", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a19567c6-2322-422d-84a9-dda824ebe07a", "30a97a05-7638-44fd-bfd8-6799bcafba17", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0", 0, "77574b49-1596-4dda-85ac-0e27762aac0b", "admin@admin.com", false, "Admin Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEFHYpwZPEarB/dxMxW7cpTTk3oLVTLIZAVHWGUFkmmr9eXbtvNrygcM2fTs/ox6+7A==", "031-84468", false, "f4712909-33b4-4dad-a698-3116ad50c3b9", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f2d64dad-efaa-47ce-b618-d1a70e83a6f1", "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BillingAddress", "City", "Country", "DefaultShippingAddress", "ZipCode" },
                values: new object[] { "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0", null, "Göteborg", "Sweden", "Götgatan 9", "41105" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerId", "OrderDate" },
                values: new object[] { "fd30f528-9416-4dbf-85b0-e7ba31b7c2f0", new DateTime(2022, 1, 10, 10, 55, 46, 733, DateTimeKind.Local).AddTicks(436) });
        }
    }
}
