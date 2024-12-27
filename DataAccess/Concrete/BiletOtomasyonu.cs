using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BiletOtomasyonu:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=LAPTOP-8F99LGJR\MSSQLSERVER02;Database=BusTicket;Trusted_Connection=true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User Entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.user_id);

                entity.Property(u => u.name)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.surname)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.email)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.password)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.Property(u => u.phone_number)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.Property(u => u.gender)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.Property(u => u.identity_)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.HasMany(u => u.Tickets)
                      .WithOne(t => t.User)
                      .HasForeignKey(t => t.user_id)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Ticket Entity
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.ticket_id);

                entity.Property(t => t.is_cancelled)
                      .IsRequired();

                entity.Property(t => t.trip_id)
                      .IsRequired();

                entity.Property(t => t.user_id)
                      .IsRequired();

                entity.Property(t => t.seat_id)
                      .IsRequired();

                entity.Property(t => t.bus_id)
                      .IsRequired();

                entity.Property(t => t.Status);
                      

                entity.HasOne(t => t.Trip)
                      .WithMany(tr => tr.Tickets)
                      .HasForeignKey(t => t.trip_id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Tickets)
                      .HasForeignKey(t => t.user_id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(t => t.Seat)
                     .WithMany(u => u.Tickets)
                     .HasForeignKey(t => t.seat_id)
                     .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(t => t.Bus)
                  .WithMany(u => u.Tickets)
                  .HasForeignKey(t => t.bus_id)
                  .OnDelete(DeleteBehavior.Cascade);

            });

            // Trip Entity
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(tr => tr.trip_id);

                entity.Property(tr => tr.departure_city)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(tr => tr.arrival_city)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(tr => tr.date_)
                     .IsRequired();

                entity.HasMany(tr => tr.Tickets)
                      .WithOne(t => t.Trip)
                      .HasForeignKey(t => t.trip_id)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(tr => tr.Buses)
                      .WithOne(t => t.Trip)
                      .HasForeignKey(t=>t.trip_id)
                      .OnDelete(DeleteBehavior.SetNull);

            });

            // Seat Entity
            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(s => s.seat_id);

                entity.Property(s => s.seat_number)
                      .IsRequired();

                entity.Property(s => s.is_reserved)
                      .IsRequired();

                entity.Property(s => s.bus_id)
                      .IsRequired();

                entity.HasOne(s => s.Bus)  // Seat bir Bus'a bağlı
                       .WithMany(b => b.Seats) // Bus, birden çok Seat'a sahip olabilir
                       .HasForeignKey(s => s.bus_id) // Seat tablosunda bus_id yabancı anahtar olarak kullanılır
                       .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.Tickets) // Seat'ın birden fazla Ticket'ı olabilir
                      .WithOne(t => t.Seat) // Her Ticket bir Seat'a ait
                      .HasForeignKey(t => t.seat_id) // Ticket tablosunda seat_id yabancı anahtar
                      .OnDelete(DeleteBehavior.Restrict); // Seat silinirse, Ticket'lar etkilenmez
 
            });

            // Bus Entity
            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(b => b.bus_id);

                entity.Property(b => b.plate_number)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(b => b.company)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(b => b.trip_id)
                      .IsRequired();

                entity.Property(tr => tr.price)
                      .IsRequired();

               entity.Property(tr => tr.departure_time)
                     .IsRequired();


                // Bus -> Trip: Her Bus bir Trip'e ait
                entity.HasOne(b => b.Trip)  // Bus bir Trip'e bağlı
                      .WithMany(t => t.Buses)  // Trip, birden fazla Bus'a sahip olabilir
                      .HasForeignKey(b => b.trip_id) // Bus tablosunda trip_id yabancı anahtar olarak kullanılır
                      .OnDelete(DeleteBehavior.Cascade); // Trip silinirse, ilgili Bus'lar da silinir

                // Bus -> Seat: Bir Bus birden çok Seat'a sahip olabilir
                entity.HasMany(b => b.Seats) // Bus birden fazla Seat'a sahip
                      .WithOne(s => s.Bus) // Her Seat bir Bus'a ait
                      .HasForeignKey(s => s.bus_id) // Seat tablosunda bus_id yabancı anahtar
                      .OnDelete(DeleteBehavior.Cascade); // Bus silinirse, ilgili Seat'lar da silinir

                // Bus -> Ticket: Bir Bus birden çok Ticket'a sahip olabilir
                entity.HasMany(b => b.Tickets) // Bus birden fazla Ticket'a sahip
                      .WithOne(t => t.Bus) // Her Ticket bir Bus'a ait
                      .HasForeignKey(t => t.bus_id) // Ticket tablosunda bus_id yabancı anahtar
                      .OnDelete(DeleteBehavior.Cascade); // Bus silinirse, ilgili Ticket'lar da silinir
        });
        
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bus> Buses { get; set; }
    }
}

