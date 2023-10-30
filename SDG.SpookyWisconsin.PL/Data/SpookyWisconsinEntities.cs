using Microsoft.EntityFrameworkCore;
using SDG.SpookyWisconsin.PL.Entities;

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
    public virtual DbSet<tblCart> tblCarts { get; set; }
    public virtual DbSet<tblCustomer> tblCustomers { get; set; }
    public virtual DbSet<tblHauntedEvent> tblHauntedEvents { get; set; }
    public virtual DbSet<tblHauntedLocation> tblHauntedLocations { get; set; }
    public virtual DbSet<tblMember> tblMemberships { get; set; }
    public virtual DbSet<tblMerch> tblMerches { get; set; }
    public virtual DbSet<tblNewsLetter> tblNewsLetter { get; set; }
    public virtual DbSet<tblOrder> tblOrders { get; set; }
    public virtual DbSet<tblParticipant> tblParticipants { get; set; }
    public virtual DbSet<tblTier> tblTier { get; set; }
    public virtual DbSet<tblTour> tblTours { get; set; }
    public virtual DbSet<tblUser> tblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SDG.SpookyWisconsin.DB;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Addresses -- Guids?
        modelBuilder.Entity<tblAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblAddress_Id");

            entity.ToTable("tblAddress");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Street)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.City)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.County)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.State)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.ZIP)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        //Cart -- Guids? Ints? Fks?
        modelBuilder.Entity<tblCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblCart_Id");

            entity.ToTable("tblCart");

            entity.Property(e => e.Id).ValueGeneratedNever();

        });

        //Customer -- Guids? FKs?
        modelBuilder.Entity<tblCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblCustomer_Id");

            entity.ToTable("tblCustomer");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Firstname)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Lastname)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Address)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false);


        });

        //Haunted Event - Guids? Ints? FKs?
        modelBuilder.Entity<tblHauntedEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblHauntedEvent_Id");

            entity.ToTable("tblHauntedEvent");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Description)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.ImagePath)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        //Huanted Locations - Guids Ints FKs?
        modelBuilder.Entity<tblHauntedLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblHauntedLocation_Id");

            entity.ToTable("tblHauntedLocation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.ImagePath)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        //Member Guids? Ints? Fks?
        modelBuilder.Entity<tblMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblMember_Id");

            entity.ToTable("tblMember");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NewsLetterOpt)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.MemberOpt)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        //Merch Guids? Ints? Fks?
        modelBuilder.Entity<tblMerch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblMerch_Id");

            entity.ToTable("tblMerch");
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MerchName)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Description)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        //NewsLetter Guids? Ints? Fks?
        modelBuilder.Entity<tblNewsLetter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblNewsLetter_Id");

            entity.ToTable("tblNewsLetter");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        //Order Guids? Ints? Fks?
        modelBuilder.Entity<tblOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblOrder_Id");

            entity.ToTable("tblOrder");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        //Participant Guids? Ints? Fks?
        modelBuilder.Entity<tblParticipant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblParticipant_Id");

            entity.ToTable("tblParticipant");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        //Tier Guids? Ints? Fks?
        modelBuilder.Entity<tblTier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblTier_Id");

            entity.ToTable("tblTier");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TierName)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        //Tour Guids? Ints? Fks?
        modelBuilder.Entity<tblTour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblTour_Id");

            entity.ToTable("tblTour");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TourName)
            .HasMaxLength(100)
            .IsUnicode(false);
            entity.Property(e => e.Description)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        //User Guids? Ints? Fks?
        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblUser_Id");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Username)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.Property(e => e.Password)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
