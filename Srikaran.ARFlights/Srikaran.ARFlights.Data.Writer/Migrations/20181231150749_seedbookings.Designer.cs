﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Srikaran.ARFlights.Data.Writer;

namespace Srikaran.ARFlights.Data.Writer.Migrations
{
    [DbContext(typeof(FlightsDBContext))]
    [Migration("20181231150749_seedbookings")]
    partial class seedbookings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview.18572.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Srikaran.ARFlights.DomainEntities.Booking", b =>
                {
                    b.Property<long>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<int?>("FlightId");

                    b.Property<string>("FlightNo");

                    b.Property<int>("PassengerId");

                    b.HasKey("BookingId");

                    b.HasIndex("FlightId");

                    b.HasIndex("PassengerId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            BookingId = 1L,
                            BookingDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FlightNo = "QA11",
                            PassengerId = 111
                        },
                        new
                        {
                            BookingId = 2L,
                            BookingDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FlightNo = "VM24",
                            PassengerId = 112
                        },
                        new
                        {
                            BookingId = 3L,
                            BookingDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FlightNo = "QA201",
                            PassengerId = 114
                        });
                });

            modelBuilder.Entity("Srikaran.ARFlights.DomainEntities.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArrivalCity");

                    b.Property<string>("DepartureCity");

                    b.Property<string>("EndTime");

                    b.Property<string>("FlightNo");

                    b.Property<int>("PassengerCapacity");

                    b.Property<string>("StartTime");

                    b.HasKey("FlightId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Srikaran.ARFlights.DomainEntities.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PassengerName");

                    b.HasKey("PassengerId");

                    b.ToTable("Passengers");

                    b.HasData(
                        new
                        {
                            PassengerId = 111,
                            PassengerName = "Steven"
                        },
                        new
                        {
                            PassengerId = 112,
                            PassengerName = "Adrian"
                        },
                        new
                        {
                            PassengerId = 113,
                            PassengerName = "John"
                        },
                        new
                        {
                            PassengerId = 114,
                            PassengerName = "Chris"
                        });
                });

            modelBuilder.Entity("Srikaran.ARFlights.DomainEntities.Booking", b =>
                {
                    b.HasOne("Srikaran.ARFlights.DomainEntities.Flight", "Flight")
                        .WithMany("Bookings")
                        .HasForeignKey("FlightId");

                    b.HasOne("Srikaran.ARFlights.DomainEntities.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
