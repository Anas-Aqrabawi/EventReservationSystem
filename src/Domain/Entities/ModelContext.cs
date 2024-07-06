using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleProject.Core.Entities;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aboutu> Aboutus { get; set; }

    public virtual DbSet<Contactu> Contactus { get; set; }

    public virtual DbSet<Credential> Credentials { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Homepage> Homepages { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visachecker> Visacheckers { get; set; }

    public virtual DbSet<Visainfo> Visainfos { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##AHMED")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Aboutu>(entity =>
        {
            entity.HasKey(e => e.AboutusId).HasName("SYS_C008422");

            entity.ToTable("ABOUTUS");

            entity.Property(e => e.AboutusId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ABOUTUS_ID");
        });

        modelBuilder.Entity<Contactu>(entity =>
        {
            entity.HasKey(e => e.ContactusId).HasName("SYS_C008420");

            entity.ToTable("CONTACTUS");

            entity.Property(e => e.ContactusId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("CONTACTUS_ID");
        });

        modelBuilder.Entity<Credential>(entity =>
        {
            entity.HasKey(e => e.CredentialId).HasName("SYS_C008430");

            entity.ToTable("CREDENTIALS");

            entity.HasIndex(e => e.Email, "SYS_C008431").IsUnique();

            entity.HasIndex(e => e.UserId, "SYS_C008432").IsUnique();

            entity.Property(e => e.CredentialId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("CREDENTIAL_ID");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithOne(p => p.Credential)
                .HasForeignKey<Credential>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("CREDENTIALS_FOREIGN_KEY");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("SYS_C008443");

            entity.ToTable("FEEDBACK");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("FEEDBACK_ID");
            entity.Property(e => e.CreationDate)
                .HasPrecision(6)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.FeedbackContent)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("FEEDBACK_CONTENT");
            entity.Property(e => e.HallId)
                .HasColumnType("NUMBER")
                .HasColumnName("HALL_ID");
            entity.Property(e => e.Rating)
                .HasColumnType("NUMBER")
                .HasColumnName("RATING");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FEEDBACK_USER_FK");
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.HallId).HasName("SYS_C008447");

            entity.ToTable("HALLS");

            entity.Property(e => e.HallId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("HALL_ID");
            entity.Property(e => e.FloorNumber)
                .HasColumnType("NUMBER")
                .HasColumnName("FLOOR_NUMBER");
            entity.Property(e => e.Hall1ImagePath)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("HALL1_IMAGE_PATH");
            entity.Property(e => e.Hall2ImagePath)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("HALL2_IMAGE_PATH");
            entity.Property(e => e.Hall3ImagePath)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("HALL3_IMAGE_PATH");
            entity.Property(e => e.Hall4ImagePath)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("HALL4_IMAGE_PATH");
            entity.Property(e => e.Hall5ImagePath)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("HALL5_IMAGE_PATH");
            entity.Property(e => e.HallAvailabilityDate)
                .HasPrecision(6)
                .HasDefaultValueSql("systimestamp")
                .HasColumnName("HALL_AVAILABILITY_DATE");
            entity.Property(e => e.HallCapacity)
                .HasColumnType("NUMBER")
                .HasColumnName("HALL_CAPACITY");
            entity.Property(e => e.HallIdentity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HALL_IDENTITY");
            entity.Property(e => e.HallLocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HALL_LOCATION");
            entity.Property(e => e.HallNumber)
                .HasColumnType("NUMBER")
                .HasColumnName("HALL_NUMBER");
            entity.Property(e => e.NumberOfChairs)
                .HasColumnType("NUMBER")
                .HasColumnName("NUMBER_OF_CHAIRS");
            entity.Property(e => e.NumberOfTables)
                .HasColumnType("NUMBER")
                .HasColumnName("NUMBER_OF_TABLES");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER")
                .HasColumnName("PRICE");
            entity.Property(e => e.Services)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SERVICES");
            entity.Property(e => e.Statusid)
                .HasColumnType("NUMBER")
                .HasColumnName("STATUSID");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Status).WithMany(p => p.Halls)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("HSFOREIGN_KEY");

            entity.HasOne(d => d.User).WithMany(p => p.Halls)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("HUFOREIGN_KEY");
        });

        modelBuilder.Entity<Homepage>(entity =>
        {
            entity.HasKey(e => e.HomePageid).HasName("SYS_C008418");

            entity.ToTable("HOMEPAGE");

            entity.Property(e => e.HomePageid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("HOME_PAGEID");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("SYS_C008453");

            entity.ToTable("RESERVATIONS");

            entity.Property(e => e.ReservationId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("RESERVATION_ID");
            entity.Property(e => e.ReservationDate)
                .HasPrecision(6)
                .HasDefaultValueSql("systimestamp")
                .HasColumnName("RESERVATION_DATE");
            entity.Property(e => e.ReservationNotes)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("RESERVATION_NOTES");
            entity.Property(e => e.Statusid)
                .HasColumnType("NUMBER")
                .HasColumnName("STATUSID");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Status).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("RSFOREIGN_KEY");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("RUFOREIGN_KEY");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("SYS_C008451");

            entity.ToTable("ROLES");

            entity.Property(e => e.RoleId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ROLE_ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ROLE_NAME");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("SYS_C008410");

            entity.ToTable("STATUS");

            entity.Property(e => e.StatusId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("STATUS_ID");
            entity.Property(e => e.Status1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.TestimonialId).HasName("SYS_C008471");

            entity.ToTable("TESTIMONIAL");

            entity.Property(e => e.TestimonialId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("TESTIMONIAL_ID");
            entity.Property(e => e.CreationDate)
                .HasPrecision(6)
                .HasDefaultValueSql("systimestamp")
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.TestimonialContent)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIAL_CONTENT");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("TESTIMONIAL_FOREIGN_KEY");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("SYS_C008424");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");
            entity.Property(e => e.Firstname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("IMAGE_PATH");
            entity.Property(e => e.Lastname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Statusid)
                .HasColumnType("NUMBER")
                .HasColumnName("STATUSID");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("STATUS_FOREIGN_KEY");
        });

        modelBuilder.Entity<Visachecker>(entity =>
        {
            entity.HasKey(e => e.VisaChecherId).HasName("SYS_C008468");

            entity.ToTable("VISACHECKER");

            entity.HasIndex(e => e.CardNumber, "SYS_C008469").IsUnique();

            entity.Property(e => e.VisaChecherId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("VISA_CHECHER_ID");
            entity.Property(e => e.Balance)
                .HasColumnType("NUMBER")
                .HasColumnName("BALANCE");
            entity.Property(e => e.CardHolderName)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CARD_HOLDER_NAME");
            entity.Property(e => e.CardNumber)
                .HasColumnType("NUMBER")
                .HasColumnName("CARD_NUMBER");
            entity.Property(e => e.Cvc)
                .HasColumnType("NUMBER")
                .HasColumnName("CVC");
        });

        modelBuilder.Entity<Visainfo>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("SYS_C008460");

            entity.ToTable("VISAINFO");

            entity.HasIndex(e => e.CardNumber, "SYS_C008461").IsUnique();

            entity.HasIndex(e => e.UserId, "SYS_C008462").IsUnique();

            entity.Property(e => e.PaymentId)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PAYMENT_ID");
            entity.Property(e => e.CardHolderName)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CARD_HOLDER_NAME");
            entity.Property(e => e.CardNumber)
                .HasColumnType("NUMBER")
                .HasColumnName("CARD_NUMBER");
            entity.Property(e => e.Cvc)
                .HasColumnType("NUMBER")
                .HasColumnName("CVC");
            entity.Property(e => e.UserId)
                .HasColumnType("NUMBER")
                .HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithOne(p => p.Visainfo)
                .HasForeignKey<Visainfo>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("UVFOREIGN_KEY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
