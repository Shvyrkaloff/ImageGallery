﻿// <auto-generated />
using System;
using ImageGallery.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImageGallery.Persistence.Migrations
{
    [DbContext(typeof(ImageGalleryDbContext))]
    partial class ImageGalleryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ImageGallery.Application.Entities.Files.Domains.ImageFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserUpdated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("ImageFiles");
                });

            modelBuilder.Entity("ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser", b =>
                {
                    b.Property<int>("FirstFriendId")
                        .HasColumnType("int");

                    b.Property<int>("SecondFriendId")
                        .HasColumnType("int");

                    b.HasKey("FirstFriendId", "SecondFriendId");

                    b.HasIndex("SecondFriendId");

                    b.ToTable("FriendUser");
                });

            modelBuilder.Entity("ImageGallery.Application.Entities.Users.Domains.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCreated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserUpdated")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ImageGallery.Application.Entities.Files.Domains.ImageFile", b =>
                {
                    b.HasOne("ImageGallery.Application.Entities.Users.Domains.User", "Owner")
                        .WithMany("ImageFiles")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser", b =>
                {
                    b.HasOne("ImageGallery.Application.Entities.Users.Domains.User", "FirstFriend")
                        .WithMany("FirstFriendUsers")
                        .HasForeignKey("FirstFriendId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ImageGallery.Application.Entities.Users.Domains.User", "SecondFriend")
                        .WithMany("SecondFriendUsers")
                        .HasForeignKey("SecondFriendId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FirstFriend");

                    b.Navigation("SecondFriend");
                });

            modelBuilder.Entity("ImageGallery.Application.Entities.Users.Domains.User", b =>
                {
                    b.Navigation("FirstFriendUsers");

                    b.Navigation("ImageFiles");

                    b.Navigation("SecondFriendUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
