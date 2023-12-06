using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SDG.SpookyWisconsin.PL;

public partial class SpookyWisconsinEntities : DbContext
{
    public SpookyWisconsinEntities()
    {
    }

    public SpookyWisconsinEntities(DbContextOptions<SpookyWisconsinEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblAddress> tblAddresses { get; set; }

    public virtual DbSet<tblCustomer> tblCustomers { get; set; }

    public virtual DbSet<tblHauntedEvent> tblHauntedEvents { get; set; }

    public virtual DbSet<tblHauntedLocation> tblHauntedLocations { get; set; }

    public virtual DbSet<tblMember> tblMembers { get; set; }

    public virtual DbSet<tblMerch> tblMerches { get; set; }

    public virtual DbSet<tblMerchType> tblMerchTypes { get; set; }

    public virtual DbSet<tblMerchTypeMerch> tblMerchTypeMerches { get; set; }

    public virtual DbSet<tblNewsLetter> tblNewsLetters { get; set; }

    public virtual DbSet<tblOrder> tblOrders { get; set; }

    public virtual DbSet<tblOrderItem> tblOrderItems { get; set; }

    public virtual DbSet<tblParticipant> tblParticipants { get; set; }

    public virtual DbSet<tblTier> tblTiers { get; set; }

    public virtual DbSet<tblTour> tblTours { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SDG.SpookyWisconsin.DB;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAddre__3214EC07714A0021");

            entity.ToTable("tblAddress");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.County)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ZIP)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCusto__3214EC072388CF65");

            entity.ToTable("tblCustomer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblHauntedEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblHaunt__3214EC0784F42D91");

            entity.ToTable("tblHauntedEvent");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblHauntedLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblHaunt__3214EC0727B38E58");

            entity.ToTable("tblHauntedLocation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMembe__3214EC07F9A4BE65");

            entity.ToTable("tblMember");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MemberOpt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NewsLetterOpt)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMerch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMerch__3214EC07A3CB4980");

            entity.ToTable("tblMerch");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.MerchName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMerchType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMerch__3214EC07EC2A63FA");

            entity.ToTable("tblMerchType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<tblMerchTypeMerch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMerch__3214EC0720924767");

            entity.ToTable("tblMerchTypeMerch");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblNewsLetter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblNewsL__3214EC07A984C2DF");

            entity.ToTable("tblNewsLetter");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOrder__3214EC07D848A938");

            entity.ToTable("tblOrder");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<tblOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOrder__3214EC078DB4357A");

            entity.ToTable("tblOrderItem");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<tblParticipant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblParti__3214EC075B9432EB");

            entity.ToTable("tblParticipant");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblTier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblTier__3214EC074CF47A8A");

            entity.ToTable("tblTier");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TierName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblTour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblTour__3214EC0727CD5DAA");

            entity.ToTable("tblTour");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TourName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC07B067B143");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
