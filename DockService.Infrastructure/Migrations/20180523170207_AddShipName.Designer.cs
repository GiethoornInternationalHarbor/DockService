﻿// <auto-generated />
using DockService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DockService.Infrastructure.Migrations
{
    [DbContext(typeof(DockDbContext))]
    [Migration("20180523170207_AddShipName")]
    partial class AddShipName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DockService.Core.Models.Ship", b =>
                {
                    b.Property<Guid>("DBKey")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<Guid>("Id");

                    b.Property<string>("Name");

                    b.HasKey("DBKey");

                    b.ToTable("Ships");
                });
#pragma warning restore 612, 618
        }
    }
}
