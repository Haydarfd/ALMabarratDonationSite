using System;
using System.Collections.Generic;
using AlMabarratDonationWebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Infrastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<DonationType> DonationTypes { get; set; }

    public virtual DbSet<Donor> Donors { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Nationality> Nationalities { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<Orphan> Orphans { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Sponsorship> Sponsorships { get; set; }

    public virtual DbSet<SponsorshipRequest> SponsorshipRequests { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasKey(e => e.CampaignID).HasName("PK__Campaign__3F5E8D7964373184");

            entity.ToTable("Campaign", tb => tb.HasTrigger("UpdateCampaignStatus"));

            entity.Property(e => e.Country).HasDefaultValue("Lebanon");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CurrentAmount).HasDefaultValue(0m);
            entity.Property(e => e.IsActive).HasDefaultValue(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK__Donation__C5082EFB23BF2E76");

            entity.HasOne(d => d.DonationType).WithMany(p => p.Donations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donation_DonationType");

            entity.HasOne(d => d.Donor).WithMany(p => p.Donations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donation_Donor");
        });

        modelBuilder.Entity<DonationType>(entity =>
        {
            entity.HasKey(e => e.DonationTypeId).HasName("PK__Donation__39DA5EB4A918DE28");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventID).HasName("PK__Events__7944C87036D1C363");

            entity.Property(e => e.EventID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageID).HasName("PK__Messages__C87C037C0B053754");

            entity.Property(e => e.MessageID).ValueGeneratedNever();
            entity.Property(e => e.Status).HasDefaultValue("Unread");
        });

        modelBuilder.Entity<Nationality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__National__3214EC075C7FF1AB");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E1288116202");

            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_NotificationType");

            entity.HasOne(d => d.Recipient).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_Recipient");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.HasKey(e => e.NotificationTypeId).HasName("PK__Notifica__299002C1F65C2548");
        });

        modelBuilder.Entity<Orphan>(entity =>
        {
            entity.HasKey(e => e.OrphanID).HasName("PK__Orphan__97894C80868955CA");

            entity.Property(e => e.Age).HasComputedColumnSql("(datediff(year,[DateOfBirth],getdate())-case when datepart(month,[DateOfBirth])>datepart(month,getdate()) OR datepart(month,[DateOfBirth])=datepart(month,getdate()) AND datepart(day,[DateOfBirth])>datepart(day,getdate()) then (1) else (0) end)", false);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A3859025656");

            entity.HasOne(d => d.Donor).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Donor");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_PaymentType");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.PaymentTypeId).HasName("PK__PaymentT__BA430B35908096ED");
        });

        modelBuilder.Entity<Sponsorship>(entity =>
        {
            entity.HasKey(e => e.SponsorshipID).HasName("PK__Sponsors__B69FD05131189306");

            entity.ToTable("Sponsorship", tb =>
                {
                    tb.HasTrigger("trg_Sponsorship_Delete");
                    tb.HasTrigger("trg_Sponsorship_InsertUpdate");
                });

            entity.Property(e => e.SponsorshipID).ValueGeneratedNever();
            entity.Property(e => e.DateAssigned).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.Donor).WithMany(p => p.Sponsorships).HasConstraintName("FK__Sponsorsh__Donor__6754599E");

            entity.HasOne(d => d.Orphan).WithMany(p => p.Sponsorships).HasConstraintName("FK_Sponsorship_Orphan");

            entity.HasOne(d => d.SponsorshipRequest).WithMany(p => p.Sponsorships)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Sponsorship_SponsorshipRequests");
        });

        modelBuilder.Entity<SponsorshipRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sponsors__3214EC07863935B2");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JoinDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RequiresPasswordChange).HasDefaultValue(true);

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_AspNetUsers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
