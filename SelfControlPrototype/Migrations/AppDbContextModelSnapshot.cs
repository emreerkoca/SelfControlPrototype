﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfControlPrototype.DataContext;

namespace SelfControlPrototype.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SelfControlPrototype.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("WordContentId");

                    b.HasKey("Id");

                    b.HasIndex("WordContentId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("SelfControlPrototype.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SelfControlPrototype.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.Property<int?>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SelfControlPrototype.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OriginalWord")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Sentence");

                    b.Property<string>("TranslatedWord")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("SelfControlPrototype.Models.Notification", b =>
                {
                    b.HasOne("SelfControlPrototype.Models.Word", "WordContent")
                        .WithMany()
                        .HasForeignKey("WordContentId");
                });

            modelBuilder.Entity("SelfControlPrototype.Models.User", b =>
                {
                    b.HasOne("SelfControlPrototype.Models.Role", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId");
                });
#pragma warning restore 612, 618
        }
    }
}
