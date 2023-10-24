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
        modelBuilder.Entity<tblAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAddre__");

            entity.ToTable("tblAddress");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Street)
            .HasMaxLength(50)
            .IsUnicode(false);

        });
    }
}
