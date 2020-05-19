﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senac.Infra.Data.Context;

namespace Senac.Infra.Data.Migrations
{
    [DbContext(typeof(SenacContext))]
    [Migration("20200519150757_RelacionamentoEmpresaFuncPermitirNulo")]
    partial class RelacionamentoEmpresaFuncPermitirNulo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Senac")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senac.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("CompanyName")
                        .HasMaxLength(100);

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasColumnName("FantasyName")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Senac.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("RegisterCode")
                        .HasColumnName("RegisterCode")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Senac.Domain.Entities.EmployeePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(50);

                    b.Property<int>("ReferenceNumber")
                        .HasColumnName("ReferenceNumber");

                    b.Property<decimal>("Salary")
                        .HasColumnName("Salary")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.ToTable("EmployeePosition");
                });

            modelBuilder.Entity("Senac.Domain.Entities.Company", b =>
                {
                    b.OwnsOne("Senac.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CompanyId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("AddressCity")
                                .HasMaxLength(50);

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnName("AddressNeighborhood")
                                .HasMaxLength(50);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("AddressNumber");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnName("AddressState")
                                .HasMaxLength(50);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("AddressStreet")
                                .HasMaxLength(50);

                            b1.HasKey("CompanyId");

                            b1.ToTable("Company","Senac");

                            b1.HasOne("Senac.Domain.Entities.Company")
                                .WithOne("Address")
                                .HasForeignKey("Senac.Domain.ValueObjects.Address", "CompanyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Senac.Domain.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<int>("CompanyId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("DocNumber")
                                .HasMaxLength(50);

                            b1.Property<int>("Type")
                                .HasColumnName("DocType");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Company","Senac");

                            b1.HasOne("Senac.Domain.Entities.Company")
                                .WithOne("Document")
                                .HasForeignKey("Senac.Domain.ValueObjects.Document", "CompanyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Senac.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("CompanyId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnName("EmailAddress")
                                .HasMaxLength(60);

                            b1.HasKey("CompanyId");

                            b1.ToTable("Company","Senac");

                            b1.HasOne("Senac.Domain.Entities.Company")
                                .WithOne("Email")
                                .HasForeignKey("Senac.Domain.ValueObjects.Email", "CompanyId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Senac.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Senac.Domain.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId");

                    b.OwnsOne("Senac.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnName("FirstName")
                                .HasMaxLength(50);

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnName("LastName")
                                .HasMaxLength(50);

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employee","Senac");

                            b1.HasOne("Senac.Domain.Entities.Employee")
                                .WithOne("Name")
                                .HasForeignKey("Senac.Domain.ValueObjects.Name", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Senac.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("AddressCity")
                                .HasMaxLength(50);

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnName("AddressNeighborhood")
                                .HasMaxLength(50);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("AddressNumber");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnName("AddressState")
                                .HasMaxLength(50);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("AddressStreet")
                                .HasMaxLength(50);

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employee","Senac");

                            b1.HasOne("Senac.Domain.Entities.Employee")
                                .WithOne("Address")
                                .HasForeignKey("Senac.Domain.ValueObjects.Address", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Senac.Domain.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnName("DocNumber")
                                .HasMaxLength(50);

                            b1.Property<int>("Type")
                                .HasColumnName("DocType");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employee","Senac");

                            b1.HasOne("Senac.Domain.Entities.Employee")
                                .WithOne("Document")
                                .HasForeignKey("Senac.Domain.ValueObjects.Document", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Senac.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnName("EmailAddress")
                                .HasMaxLength(60);

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employee","Senac");

                            b1.HasOne("Senac.Domain.Entities.Employee")
                                .WithOne("Email")
                                .HasForeignKey("Senac.Domain.ValueObjects.Email", "EmployeeId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
