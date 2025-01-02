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
                      .OnDelete(DeleteBehavior.Cascade);

            });

            
            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(s => s.seat_id);

                entity.Property(s => s.seat_number)
                      .IsRequired();

                entity.Property(s => s.is_reserved)
                      .IsRequired();

                entity.Property(s => s.bus_id)
                      .IsRequired();

                entity.HasOne(s => s.Bus) 
                       .WithMany(b => b.Seats) 
                       .HasForeignKey(s => s.bus_id) 
                       .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.Tickets) 
                      .WithOne(t => t.Seat) 
                      .HasForeignKey(t => t.seat_id) 
                      .OnDelete(DeleteBehavior.Restrict); 
 
            });

            
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


                
                entity.HasOne(b => b.Trip)  
                      .WithMany(t => t.Buses)  
                      .HasForeignKey(b => b.trip_id) 
                      .OnDelete(DeleteBehavior.Cascade); 

                
                entity.HasMany(b => b.Seats) 
                      .WithOne(s => s.Bus) 
                      .HasForeignKey(s => s.bus_id) 
                      .OnDelete(DeleteBehavior.Cascade); 

                
                entity.HasMany(b => b.Tickets) 
                      .WithOne(t => t.Bus) 
                      .HasForeignKey(t => t.bus_id) 
                      .OnDelete(DeleteBehavior.Cascade); 
        });
        
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bus> Buses { get; set; }
    }
}

