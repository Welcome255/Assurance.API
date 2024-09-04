﻿// <auto-generated />
using Assurance.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assurance.Infrastructure.Migrations
{
    [DbContext(typeof(AssuranceContext))]
    [Migration("20240904182117_assurance")]
    partial class assurance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Assurance.ApplicationCore.Entites.AssuranceClient", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("EstDiabetique")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstFumeur")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EstHypertendu")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PratiqueActivitePhysique")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Solde")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Assurance");
                });
#pragma warning restore 612, 618
        }
    }
}
