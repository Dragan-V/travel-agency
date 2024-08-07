﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgencyApplication.Domain.Identity;
using TravelAgencyApplication.Domain.Model;

namespace TravelAgencyApplication.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<TAUser>
    {
        public virtual DbSet<TravelPackage> TravelPackages { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Itinerary> Itineraries { get; set; }
        public virtual DbSet<Image> Images{ get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DepartureLocation> DeparatureLocations { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TravelPackageItinerary>()
                .HasOne(tpi => tpi.TravelPackage)
                .WithMany(tp => tp.Itineraries)
                .HasForeignKey(tpi => tpi.TravelPackageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TravelPackageItinerary>()
                .HasOne(tpi => tpi.Itinerary)
                .WithMany(i => i.TravelPackages)
                .HasForeignKey(tpi => tpi.ItineraryId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<TravelPackageAccomodationImage>()
            //    .HasOne(tpai => tpai.TravelPackage)
            //    .WithMany(tp => tp.TravelPackageAccomodationImages)
            //    .HasForeignKey(tpai => tpai.TravelPackageId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<TravelPackageLocationImage>()
            //    .HasOne(tpli => tpli.TravelPackage)
            //    .WithMany(tp => tp.TravelPackageLocationImages)
            //    .HasForeignKey(tpli => tpli.TravelPackageId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
}
}
