﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpotzerMediaPro.Domain.Helpers;

namespace SpotzerMediaPro.Domain.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.AuditTrail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActionBy")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ActionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ActionType")
                        .HasMaxLength(100)
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Endpoint")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("HostAddress")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("IPAddress")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AuditTrails");
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ApiCode")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ApiKey")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Channels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7f107726-562e-4b6e-9ebe-722d2b0959de"),
                            ApiCode = new Guid("4ee50142-0e46-400b-b665-32767b1f6c56"),
                            ApiKey = new Guid("bec30ac8-260f-499a-b421-f1813b687f29"),
                            IsActive = true,
                            Name = "Partner A"
                        },
                        new
                        {
                            Id = new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"),
                            ApiCode = new Guid("ed36abff-aa46-46dd-a20f-c3566df41289"),
                            ApiKey = new Guid("aaac4232-b56d-4add-b508-17b15c39fefc"),
                            IsActive = true,
                            Name = "Partner B"
                        },
                        new
                        {
                            Id = new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"),
                            ApiCode = new Guid("6899ffa8-d0da-4e22-87c5-534ad1e468ee"),
                            ApiKey = new Guid("2f60912a-333d-4e77-aa58-0d3693d1335b"),
                            IsActive = true,
                            Name = "Partner C"
                        },
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991890"),
                            ApiCode = new Guid("c9d4c053-49b6-410c-bc78-2d54a9977777"),
                            ApiKey = new Guid("c9d4c053-49b6-410c-bc78-2d54a9966666"),
                            IsActive = true,
                            Name = "Partner D"
                        });
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.ChannelProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ChannelProducts");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ChannelId = new Guid("7f107726-562e-4b6e-9ebe-722d2b0959de"),
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 122, DateTimeKind.Unspecified).AddTicks(8405), new TimeSpan(0, 1, 0, 0, 0)),
                            IsActive = true,
                            IsDeleted = false,
                            ProductId = new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2")
                        },
                        new
                        {
                            Id = 2L,
                            ChannelId = new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"),
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(281), new TimeSpan(0, 1, 0, 0, 0)),
                            IsActive = true,
                            IsDeleted = false,
                            ProductId = new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2")
                        },
                        new
                        {
                            Id = 3L,
                            ChannelId = new Guid("3be6a48b-47d4-4cdd-89d5-c02419dd73a9"),
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(295), new TimeSpan(0, 1, 0, 0, 0)),
                            IsActive = true,
                            IsDeleted = false,
                            ProductId = new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77")
                        },
                        new
                        {
                            Id = 4L,
                            ChannelId = new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"),
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(301), new TimeSpan(0, 1, 0, 0, 0)),
                            IsActive = true,
                            IsDeleted = false,
                            ProductId = new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2")
                        },
                        new
                        {
                            Id = 5L,
                            ChannelId = new Guid("8bc3f28c-e64b-4546-9083-b0dad58d1b40"),
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(307), new TimeSpan(0, 1, 0, 0, 0)),
                            IsActive = true,
                            IsDeleted = false,
                            ProductId = new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77")
                        },
                        new
                        {
                            Id = 6L,
                            ChannelId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991890"),
                            CreatedOn = new DateTimeOffset(new DateTime(2022, 1, 30, 13, 10, 24, 123, DateTimeKind.Unspecified).AddTicks(312), new TimeSpan(0, 1, 0, 0, 0)),
                            IsActive = true,
                            IsDeleted = false,
                            ProductId = new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77")
                        });
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyID")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MetaData")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubmittedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeOfOrder")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.OrderLineItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLineItems");
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.OrderLineItemAdwordCampaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CampaignAddressLine1")
                        .HasColumnType("TEXT");

                    b.Property<string>("CampaignName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CampaignPostCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("CampaignRadius")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("DestinationURL")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LeadPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Offer")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderLineItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SMSPhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("UniqueSellingPoint1")
                        .HasColumnType("TEXT");

                    b.Property<string>("UniqueSellingPoint2")
                        .HasColumnType("TEXT");

                    b.Property<string>("UniqueSellingPoint3")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OrderLineItemAdwordCampaigns");
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.OrderLineItemWebSiteDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("OrderLineItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TemplateId")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteAddressLine1")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteAddressLine2")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteBusinessName")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteMobile")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsitePhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsitePostCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteState")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OrderLineItemWebSiteDetails");
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = new Guid("62d85b57-db26-4742-a5ba-fb695c8cc9a2"),
                            Description = "Website Product",
                            DisplayName = "Website",
                            IsActive = true,
                            ProductName = "Website",
                            ProductType = "Websites"
                        },
                        new
                        {
                            ProductId = new Guid("909b9bcc-a9a2-4ed1-b130-3e9bba11ab77"),
                            Description = "Paid Search Campaigns Product",
                            DisplayName = "Paid Search Campaigns",
                            IsActive = true,
                            ProductName = "Paid Search Campaigns",
                            ProductType = "PaidSearchCampaigns"
                        });
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.OrderLineItem", b =>
                {
                    b.HasOne("SpotzerMediaPro.Domain.Entities.Order", null)
                        .WithMany("OrderLineItem")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("SpotzerMediaPro.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderLineItem");
                });
#pragma warning restore 612, 618
        }
    }
}
