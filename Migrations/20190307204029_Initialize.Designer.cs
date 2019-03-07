﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebJackpot.Data;

namespace WebJackpot.Migrations
{
    [DbContext(typeof(WebJackpotContext))]
    [Migration("20190307204029_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebJackpot.Models.Jackpot", b =>
                {
                    b.Property<int>("JackpotID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CurrentTime");

                    b.Property<decimal>("CurrentWin")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("JackpotID");

                    b.ToTable("Jackpot");
                });

            modelBuilder.Entity("WebJackpot.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("PlayerID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("WebJackpot.Models.TriggeredJackpot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CurrentWin")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("JackpotID");

                    b.Property<int>("PlayerID");

                    b.Property<DateTime>("TriggerTime");

                    b.HasKey("ID");

                    b.HasIndex("JackpotID");

                    b.HasIndex("PlayerID");

                    b.ToTable("TriggeredJackpot");
                });

            modelBuilder.Entity("WebJackpot.Models.TriggeredJackpot", b =>
                {
                    b.HasOne("WebJackpot.Models.Jackpot", "Jackpot")
                        .WithMany()
                        .HasForeignKey("JackpotID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebJackpot.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
