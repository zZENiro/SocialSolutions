﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialSolutions.Repositories.Data;

namespace SocialSolutions.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201031084014_permitionAdded")]
    partial class permitionAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocialSolutions.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SocialSolutions.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("SocialSolutions.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int?>("ModeratorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LocationId");

                    b.HasIndex("ModeratorId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SocialSolutions.Models.EventAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventAlbum");
                });

            modelBuilder.Entity("SocialSolutions.Models.EventImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventAlbumId")
                        .HasColumnType("int");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventAlbumId");

                    b.HasIndex("ImageId");

                    b.ToTable("EventImage");
                });

            modelBuilder.Entity("SocialSolutions.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("SocialSolutions.Models.HobbiesEvents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("HobbyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("HobbyId");

                    b.ToTable("HobbiesEvents");
                });

            modelBuilder.Entity("SocialSolutions.Models.Hobby", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hobby");
                });

            modelBuilder.Entity("SocialSolutions.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Value")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("SocialSolutions.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("SocialSolutions.Models.Permit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permit");
                });

            modelBuilder.Entity("SocialSolutions.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SocialSolutions.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("SocialSolutions.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialSolutions.Models.UserAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAlbum");
                });

            modelBuilder.Entity("SocialSolutions.Models.UserImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int?>("UserAlbumId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("UserAlbumId");

                    b.ToTable("UserImage");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersEvents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersEvents");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersGroups");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersHobbies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HobbyId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HobbyId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersHobbies");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersPermits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PermitId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermitId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersPermits");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersRoles");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersSkills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SkillId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersSkills");
                });

            modelBuilder.Entity("SocialSolutions.Models.Account", b =>
                {
                    b.HasOne("SocialSolutions.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialSolutions.Models.Document", b =>
                {
                    b.HasOne("SocialSolutions.Models.User", null)
                        .WithMany("Documents")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialSolutions.Models.Event", b =>
                {
                    b.HasOne("SocialSolutions.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("SocialSolutions.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("SocialSolutions.Models.User", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId");
                });

            modelBuilder.Entity("SocialSolutions.Models.EventAlbum", b =>
                {
                    b.HasOne("SocialSolutions.Models.Event", "Event")
                        .WithMany("EventAlbums")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("SocialSolutions.Models.EventImage", b =>
                {
                    b.HasOne("SocialSolutions.Models.EventAlbum", null)
                        .WithMany("Images")
                        .HasForeignKey("EventAlbumId");

                    b.HasOne("SocialSolutions.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("SocialSolutions.Models.Group", b =>
                {
                    b.HasOne("SocialSolutions.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("SocialSolutions.Models.HobbiesEvents", b =>
                {
                    b.HasOne("SocialSolutions.Models.Event", "Event")
                        .WithMany("HobbiesEvents")
                        .HasForeignKey("EventId");

                    b.HasOne("SocialSolutions.Models.Hobby", "Hobby")
                        .WithMany("HobbiesEvents")
                        .HasForeignKey("HobbyId");
                });

            modelBuilder.Entity("SocialSolutions.Models.UserAlbum", b =>
                {
                    b.HasOne("SocialSolutions.Models.User", "User")
                        .WithMany("UserAlbums")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialSolutions.Models.UserImage", b =>
                {
                    b.HasOne("SocialSolutions.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.HasOne("SocialSolutions.Models.UserAlbum", null)
                        .WithMany("Images")
                        .HasForeignKey("UserAlbumId");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersEvents", b =>
                {
                    b.HasOne("SocialSolutions.Models.Event", "Event")
                        .WithMany("UsersEvents")
                        .HasForeignKey("EventId");

                    b.HasOne("SocialSolutions.Models.User", "User")
                        .WithMany("UsersEvents")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersGroups", b =>
                {
                    b.HasOne("SocialSolutions.Models.Group", "Group")
                        .WithMany("UsersGroups")
                        .HasForeignKey("GroupId");

                    b.HasOne("SocialSolutions.Models.User", "User")
                        .WithMany("UsersGroups")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersHobbies", b =>
                {
                    b.HasOne("SocialSolutions.Models.Hobby", "Hobby")
                        .WithMany("UsersHobbies")
                        .HasForeignKey("HobbyId");

                    b.HasOne("SocialSolutions.Models.User", "User")
                        .WithMany("UsersHobbies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersPermits", b =>
                {
                    b.HasOne("SocialSolutions.Models.Permit", "Permit")
                        .WithMany()
                        .HasForeignKey("PermitId");

                    b.HasOne("SocialSolutions.Models.User", "User")
                        .WithMany("UsersPermits")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersRoles", b =>
                {
                    b.HasOne("SocialSolutions.Models.Role", "Role")
                        .WithMany("UsersRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("SocialSolutions.Models.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialSolutions.Models.UsersSkills", b =>
                {
                    b.HasOne("SocialSolutions.Models.Skill", "Skill")
                        .WithMany("UsersSkills")
                        .HasForeignKey("SkillId");

                    b.HasOne("SocialSolutions.Models.User", "User")
                        .WithMany("UsersSkills")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
