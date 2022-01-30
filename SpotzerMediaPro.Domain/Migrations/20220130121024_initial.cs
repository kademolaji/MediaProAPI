using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpotzerMediaPro.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditTrails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ActionBy = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Details = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    IPAddress = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    HostAddress = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Endpoint = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ActionType = table.Column<int>(type: "INTEGER", maxLength: 100, nullable: false),
                    ChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChannelProducts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApiKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApiCode = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeOfOrder = table.Column<string>(type: "TEXT", nullable: true),
                    SubmittedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyID = table.Column<string>(type: "TEXT", nullable: true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: true),
                    MetaData = table.Column<string>(type: "TEXT", nullable: true),
                    ChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItemAdwordCampaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderLineItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CampaignName = table.Column<string>(type: "TEXT", nullable: true),
                    CampaignAddressLine1 = table.Column<string>(type: "TEXT", nullable: true),
                    CampaignPostCode = table.Column<string>(type: "TEXT", nullable: true),
                    CampaignRadius = table.Column<string>(type: "TEXT", nullable: true),
                    LeadPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    SMSPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueSellingPoint1 = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueSellingPoint2 = table.Column<string>(type: "TEXT", nullable: true),
                    UniqueSellingPoint3 = table.Column<string>(type: "TEXT", nullable: true),
                    Offer = table.Column<string>(type: "TEXT", nullable: true),
                    DestinationURL = table.Column<string>(type: "TEXT", nullable: true),
                    ChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItemAdwordCampaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItemWebSiteDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderLineItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TemplateId = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteBusinessName = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteAddressLine1 = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteAddressLine2 = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteCity = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteState = table.Column<string>(type: "TEXT", nullable: true),
                    WebsitePostCode = table.Column<string>(type: "TEXT", nullable: true),
                    WebsitePhone = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteEmail = table.Column<string>(type: "TEXT", nullable: true),
                    WebsiteMobile = table.Column<string>(type: "TEXT", nullable: true),
                    ChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItemWebSiteDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ProductType = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductID = table.Column<string>(type: "TEXT", nullable: true),
                    ProductType = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ChannelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLineItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ChannelProducts",
                columns: new[] { "Id", "ChannelId", "CreatedOn", "IsActive", "IsDeleted", "ProductId" },
                values: new object[] { 1L, new Guid("7f107726-562e-4b6e-9ebe-722d2b0959de"), new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 122, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 1, 0, 0, 0)), true, false, new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2") });

            migrationBuilder.InsertData(
                table: "ChannelProducts",
                columns: new[] { "Id", "ChannelId", "CreatedOn", "IsActive", "IsDeleted", "ProductId" },
                values: new object[] { 2L, new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"), new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(281), new TimeSpan(0, 1, 0, 0, 0)), true, false, new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2") });

            migrationBuilder.InsertData(
                table: "ChannelProducts",
                columns: new[] { "Id", "ChannelId", "CreatedOn", "IsActive", "IsDeleted", "ProductId" },
                values: new object[] { 3L, new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"), new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(295), new TimeSpan(0, 1, 0, 0, 0)), true, false, new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77") });

            migrationBuilder.InsertData(
                table: "ChannelProducts",
                columns: new[] { "Id", "ChannelId", "CreatedOn", "IsActive", "IsDeleted", "ProductId" },
                values: new object[] { 4L, new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"), new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(301), new TimeSpan(0, 1, 0, 0, 0)), true, false, new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2") });

            migrationBuilder.InsertData(
                table: "ChannelProducts",
                columns: new[] { "Id", "ChannelId", "CreatedOn", "IsActive", "IsDeleted", "ProductId" },
                values: new object[] { 5L, new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"), new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(307), new TimeSpan(0, 1, 0, 0, 0)), true, false, new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77") });

            migrationBuilder.InsertData(
                table: "ChannelProducts",
                columns: new[] { "Id", "ChannelId", "CreatedOn", "IsActive", "IsDeleted", "ProductId" },
                values: new object[] { 6L, new Guid("c9d4c053-49b6-410c-bc78-2d54a9991890"), new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(312), new TimeSpan(0, 1, 0, 0, 0)), true, false, new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77") });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ApiCode", "ApiKey", "IsActive", "Name" },
                values: new object[] { new Guid("7f107726-562e-4b6e-9ebe-722d2b0959de"), new Guid("4ee50142-0e46-400b-b665-32767b1f6c56"), new Guid("bec30ac8-260f-499a-b421-f1813b687f29"), true, "Partner A" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ApiCode", "ApiKey", "IsActive", "Name" },
                values: new object[] { new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"), new Guid("ed36abff-aa46-46dd-a20f-c3566df41289"), new Guid("aaac4232-b56d-4add-b508-17b15c39fefc"), true, "Partner B" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ApiCode", "ApiKey", "IsActive", "Name" },
                values: new object[] { new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"), new Guid("6899ffa8-d0da-4e22-87c5-534ad1e468ee"), new Guid("2f60912a-333d-4e77-aa58-0d3693d1335b"), true, "Partner C" });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Id", "ApiCode", "ApiKey", "IsActive", "Name" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991890"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9977777"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9966666"), true, "Partner D" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "DisplayName", "IsActive", "ProductName", "ProductType" },
                values: new object[] { new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2"), "Website Product", "Website", true, "Website", "Websites" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "DisplayName", "IsActive", "ProductName", "ProductType" },
                values: new object[] { new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77"), "Paid Search Campaigns Product", "Paid Search Campaigns", true, "Paid Search Campaigns", "PaidSearchCampaigns" });

            migrationBuilder.CreateIndex(
                name: "IX_Channels_Id",
                table: "Channels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItems_OrderId",
                table: "OrderLineItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTrails");

            migrationBuilder.DropTable(
                name: "ChannelProducts");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "OrderLineItemAdwordCampaigns");

            migrationBuilder.DropTable(
                name: "OrderLineItems");

            migrationBuilder.DropTable(
                name: "OrderLineItemWebSiteDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
