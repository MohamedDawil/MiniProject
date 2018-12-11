using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MiniProject.Models.Entities
{
    public partial class EventContext : DbContext
    {
        public EventContext()
        {
        }

        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EventDB;Integrated Security=True;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK__Customer__Ticket__29572725");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.EventId)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.PresaleName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });
        }
    }
}
