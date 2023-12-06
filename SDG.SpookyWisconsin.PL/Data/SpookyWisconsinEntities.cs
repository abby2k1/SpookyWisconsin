using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using SDG.SpookyWisconsin.PL.Entities;
using System.IO;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SDG.SpookyWisconsin.PL
{
    public class SpookyWisconsinEntities : DbContext
    {
        Guid[] addressId = new Guid[28];
        Guid[] cartId = new Guid[16];
        Guid[] customerId = new Guid[4];
        Guid[] hauntedEventId = new Guid[4];
        Guid[] hauntedLocationId = new Guid[24];
        Guid[] memberId = new Guid[4];
        Guid[] merchId = new Guid[4];
        Guid[] merchTypeId = new Guid[6]; // added
        Guid[] merchTypeMerchId = new Guid[9]; // added
        Guid[] newsLetterId = new Guid[4];
        Guid[] orderId = new Guid[4];
        Guid[] orderItemId = new Guid[5]; // added
        Guid[] participantId = new Guid[4];
        Guid[] tierId = new Guid[3];
        Guid[] tourId = new Guid[4];
        Guid[] userId = new Guid[4];

        public SpookyWisconsinEntities()
        {

        }

        public SpookyWisconsinEntities(DbContextOptions<SpookyWisconsinEntities> options) : base(options)
        {

        }

        public virtual DbSet<tblAddress> tblAddresses { get; set; }
        public virtual DbSet<tblCart> tblCarts { get; set; }
        public virtual DbSet<tblCustomer> tblCustomers { get; set; }
        public virtual DbSet<tblHauntedEvent> tblHauntedEvents { get; set; }
        public virtual DbSet<tblHauntedLocation> tblHauntedLocations { get; set; }
        public virtual DbSet<tblMember> tblMemberships { get; set; }
        public virtual DbSet<tblMerch> tblMerches { get; set; }
        // public virtual DbSet<tblMerchType> tblmerchTypes { get; set; }
        // public virtual DbSet<tblMerchTypeMerch> tblMerchesTypeMerch { get; set; }
        public virtual DbSet<tblNewsLetter> tblNewLetters { get; set; }
        public virtual DbSet<tblOrder> tblOrders { get; set; }
        // public virtual DbSet<tblOrderItem> tblOrderItems { get; set; }
        public virtual DbSet<tblParticipant> tblParticipants { get; set; }
        public virtual DbSet<tblTier> tblTiers { get; set; }
        public virtual DbSet<tblTour> tblTours { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SDG.SpookyWisconsin.DB;Integrated Security=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            CreateAddresses(modelBuilder);
            CreateCarts(modelBuilder);
            CreateCustomers(modelBuilder);
            CreateHauntedEvents(modelBuilder);
            CreateHauntedLocations(modelBuilder);
            CreateMembers(modelBuilder);
            CreateMerchs(modelBuilder);
            CreateNewsLetters(modelBuilder);
            CreateOrders(modelBuilder);
            CreateParticipants(modelBuilder);
            CreateTiers(modelBuilder);
            CreateTours(modelBuilder);
            CreateUsers(modelBuilder);

        }

        private void CreateAddresses(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < addressId.Length; i++)
                addressId[i] = Guid.NewGuid();

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

            List<tblAddress> addresses = new List<tblAddress>
            {
                new tblAddress { Id = addressId[0], Street = "2308 W Wisconsin Ave", City = "Milwaukee", County = "Milwaukee", State ="WI", ZIP = "53233"},
                new tblAddress { Id = addressId[1], Street = "3310 E Calumet St", City = "Appleton", County = "Calumet", State ="WI", ZIP = "54915"},
                new tblAddress { Id = addressId[2], Street = "100 High Ave", City = "Oshkosh", County = "Winnebago", State ="WI", ZIP = "54901"},
                new tblAddress { Id = addressId[3], Street = "431 North St", City = "Green Lake", County = "Green Lake", State ="WI", ZIP = "54941"},
                new tblAddress { Id = addressId[4], Street = "3420 E Calumet St", City = "Appleton", County = "Calumet", State ="WI", ZIP = "54915"},
                new tblAddress { Id = addressId[5], Street = "714 N Owaissa St", City = "Appleton", County = "Outagamie", State ="WI", ZIP = "54911"},
                new tblAddress { Id = addressId[6], Street = "W4266 County Hwy X", City = "Owen", County = "Clark", State ="WI", ZIP = "54460"},
                new tblAddress { Id = addressId[7], Street = "N6590 5th Ave", City = "Plainfield", County = "Waushara", State ="WI", ZIP = "54966"},
                new tblAddress { Id = addressId[8], Street = "623 Broadway St", City = "Baraboo", County = "Sauk", State ="WI", ZIP = "53913"},
                new tblAddress { Id = addressId[9], Street = "Callan Rd", City = "Ripon", County = "Fond du Lac", State ="WI", ZIP = "54971"},
                new tblAddress { Id = addressId[10], Street = "276 Linden St", City = "Fond du Lac", County = "Fond du Lac", State ="WI", ZIP = "54935"},
                new tblAddress { Id = addressId[11], Street = "Boy Scout Lane", City = "Linwood", County = "Portage", State ="WI", ZIP = "54481"},
                new tblAddress { Id = addressId[12], Street = "321 Main St", City = "Black River Falls", County = "Jackson", State ="WI", ZIP = "54615"},
                new tblAddress { Id = addressId[13], Street = "4100 Treffert Dr", City = "Oshkosh", County = "Winnebago", State ="WI", ZIP = "54901"},
                new tblAddress { Id = addressId[14], Street = "135 Walnut St", City = "Baraboo", County = "Sauk", State ="WI", ZIP = "53913"},
                new tblAddress { Id = addressId[15], Street = "424 E Wisconsin Ave", City = "Milwaukee", County = "Milwaukee", State ="WI", ZIP = "53202"},
                new tblAddress { Id = addressId[16], Street = "1202 Northport Dr", City = "Madison", County = "Dane", State ="WI", ZIP = "53704"},
                new tblAddress { Id = addressId[17], Street = "3330 E Calumet St", City = "Appleton", County = "Calumet", State ="WI", ZIP = "54915"},
                new tblAddress { Id = addressId[18], Street = "Helen Creek Rd", City = "Land O Lakes", County = "Vilas", State ="WI", ZIP = "54540"},
                new tblAddress { Id = addressId[19], Street = "1 Speedway Rd", City = "Madison", County = "Dane", State ="WI", ZIP = "53705"},
                new tblAddress { Id = addressId[20], Street = "11811 W Watertown Plank Rd", City = "Wauwatosa", County = "Milwaukee", State ="WI", ZIP = "53226"},
                new tblAddress { Id = addressId[21], Street = "2304 S Galvin Ave", City = "Marshfield", County = "Wood", State ="WI", ZIP = "54449"},
                new tblAddress { Id = addressId[22], Street = "3400 E Calumet St", City = "Appleton", County = "Calumet", State ="WI", ZIP = "54915"},
                new tblAddress { Id = addressId[23], Street = "W Clark St", City = "Stevens Point", County = "Portage", State ="WI", ZIP = "54481"},
                new tblAddress { Id = addressId[24], Street = "116 W Wisconsin Ave", City = "Milwaukee", County = "Milwaukee", State ="WI", ZIP = "53203"},
                new tblAddress { Id = addressId[25], Street = "1201 Main Rd", City = "Washington", County = "Door", State ="WI", ZIP = "54246"},
                new tblAddress { Id = addressId[26], Street = "15401 County Rd R", City = "Maribel", County = "Manitowoc", State ="WI", ZIP = "54227"},
                new tblAddress { Id = addressId[27], Street = "6517 Lynch Bridge Rd", City = "Siren", County = "Burnett", State ="WI", ZIP = "54872"}
            };

            modelBuilder.Entity<tblAddress>().HasData(addresses);
        }

        private void CreateCarts(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < cartId.Length; i++)
                cartId[i] = Guid.NewGuid();

            modelBuilder.Entity<tblCart>();

            List<tblCart> carts = new List<tblCart>
            {
                new tblCart {Id = cartId[0], CustomerId = customerId[4], MerchId = merchId[3],  Quantity = 1, TotalCost = 21.08},
                new tblCart {Id = cartId[1], CustomerId = customerId[2], MerchId = merchId[1],  Quantity = 10, TotalCost = 31.54},
                new tblCart {Id = cartId[2], CustomerId = customerId[1], MerchId = merchId[2],  Quantity = 2, TotalCost = 18.96},
                new tblCart {Id = cartId[3], CustomerId = customerId[3], MerchId = merchId[4],  Quantity = 3, TotalCost = 52.71},
                new tblCart {Id = cartId[4], CustomerId = customerId[2], MerchId = merchId[1],  Quantity = 10, TotalCost = 31.54},
                new tblCart {Id = cartId[5], CustomerId = customerId[1], MerchId = merchId[2],  Quantity = 2, TotalCost = 18.96},
                new tblCart {Id = cartId[6], CustomerId = customerId[4], MerchId = merchId[3],  Quantity = 1, TotalCost = 21.08},
                new tblCart {Id = cartId[7], CustomerId = customerId[2], MerchId = merchId[1],  Quantity = 10, TotalCost = 31.54},
                new tblCart {Id = cartId[8], CustomerId = customerId[3], MerchId = merchId[4],  Quantity = 3, TotalCost = 52.71},
                new tblCart {Id = cartId[9], CustomerId = customerId[3], MerchId = merchId[4],  Quantity = 3, TotalCost = 52.71},
                new tblCart {Id = cartId[10], CustomerId = customerId[3], MerchId = merchId[4],  Quantity = 3, TotalCost = 52.71},
                new tblCart {Id = cartId[11], CustomerId = customerId[1], MerchId = merchId[2],  Quantity = 2, TotalCost = 18.96},
                new tblCart {Id = cartId[12], CustomerId = customerId[4], MerchId = merchId[3],  Quantity = 1, TotalCost = 21.08},
                new tblCart {Id = cartId[13], CustomerId = customerId[1], MerchId = merchId[2],  Quantity = 2, TotalCost = 18.96},
                new tblCart {Id = cartId[14], CustomerId = customerId[4], MerchId = merchId[3],  Quantity = 1, TotalCost = 21.08},
                new tblCart {Id = cartId[15], CustomerId = customerId[2], MerchId = merchId[1],  Quantity = 10, TotalCost = 31.54}
            };
            modelBuilder.Entity<tblCart>().HasData(carts);
        }

        private void CreateCustomers(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < customerId.Length; i++)
                customerId[i] = Guid.NewGuid();

            //Customer -- Guids? FKs?
            modelBuilder.Entity<tblCustomer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblCustomer_Id");

                entity.ToTable("tblCustomer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Firstname)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Lastname)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);


            });

            modelBuilder.Entity<tblCustomer>().HasData(new tblCustomer
            {
                Id = customerId[0],
                MemberId = memberId[0],
                Firstname = "Morticia",
                Lastname = "Addams",
                AddressId = addressId[15],
                Email = "mortaddams11@gmail.com",
                UserId = userId[3]
            });

            modelBuilder.Entity<tblCustomer>().HasData(new tblCustomer
            {
                Id = customerId[1],
                MemberId = memberId[3],
                Firstname = "Wednesday",
                Lastname = "Addams",
                AddressId = addressId[1],
                Email = "wedaddams.1600@hotmail.com",
                UserId = userId[0]
            });

            modelBuilder.Entity<tblCustomer>().HasData(new tblCustomer
            {
                Id = customerId[2],
                MemberId = memberId[1],
                Firstname = "Michael",
                Lastname = "Jackson",
                AddressId = addressId[22],
                Email = "kingpop1984@yahoo.com",
                UserId = userId[1]
            });

            modelBuilder.Entity<tblCustomer>().HasData(new tblCustomer
            {
                Id = customerId[3],
                MemberId = memberId[2],
                Firstname = "Vincent",
                Lastname = "Price",
                AddressId = addressId[6],
                Email = "pricev31@gmail.com",
                UserId = userId[2]
            });

        }

        private void CreateHauntedEvents(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < hauntedEventId.Length; i++)
                hauntedEventId[i] = Guid.NewGuid();

            //Haunted Event - Guids? Ints? FKs?
            modelBuilder.Entity<tblHauntedEvent>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblHauntedEvent_Id");

                entity.ToTable("tblHauntedEvent");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Date)
                .HasColumnType("datetime");
                entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.ImagePath)
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            List<tblHauntedEvent> hauntedEvents = new List<tblHauntedEvent>()
            {
                new tblHauntedEvent {Id = hauntedEventId[0], HauntedLocationId = hauntedLocationId[0], Name = "Stay the Night for a Fright", Date = new DateTime(2023, 12, 04), Description = "Stay the Night for a Fright", ImagePath =  ""},
                new tblHauntedEvent {Id = hauntedEventId[1], HauntedLocationId = hauntedLocationId[20], Name = "Keeping Up with the Circus", Date = new DateTime(2023, 11, 16), Description = "Keeping Up with the Circus", ImagePath =  ""},
                new tblHauntedEvent {Id = hauntedEventId[2], HauntedLocationId = hauntedLocationId[18], Name = "Veteran Walk-Through in Forest Hill Cemetery", Date = new DateTime(2023, 10, 31), Description = "Veteran Walk-Through in Forest Hill Cemetery", ImagePath =  ""},
                new tblHauntedEvent {Id = hauntedEventId[3], HauntedLocationId = hauntedLocationId[7], Name = "Kate Blood Gravestone Story Time", Date = new DateTime(2023, 11, 05), Description = "Kate Blood Gravestone Story Time", ImagePath =  ""}
            };

            modelBuilder.Entity<tblHauntedEvent>().HasData(hauntedEvents);

        }

        private void CreateHauntedLocations(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < hauntedLocationId.Length; i++)
                hauntedLocationId[i] = Guid.NewGuid();

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

            List<tblHauntedLocation> hauntedLocations = new List<tblHauntedLocation>
            {
                new tblHauntedLocation {Id = hauntedLocationId[0], AddressId = hauntedLocationId[14], Name = "Old Baraboo Inn", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[1], AddressId = hauntedLocationId[21], Name = "Wood County Insane Asylum", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[2], AddressId = hauntedLocationId[3], Name = "Dartford Cemetery", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[3], AddressId = hauntedLocationId[10], Name = "Octagon House", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[4], AddressId = hauntedLocationId[13], Name = "Winnebago Mental Health Institute", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[5], AddressId = hauntedLocationId[25], Name = "Nelsen Hall", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[6], AddressId = hauntedLocationId[9], Name = "Witch Road", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[7], AddressId = hauntedLocationId[5], Name = "Riverside Cemetery", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[8], AddressId = hauntedLocationId[7], Name = "Plainfield Cemetery", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[9], AddressId = hauntedLocationId[2], Name = "The Grand Opera House", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[10], AddressId = hauntedLocationId[0], Name = "Ambassador Hotel", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[11], AddressId = hauntedLocationId[15], Name = "The Pfister Hotel", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[12], AddressId = hauntedLocationId[16], Name = "Sanatorium Hill", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[13], AddressId = hauntedLocationId[23], Name = "Bloody Bride Bridge", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[14], AddressId = hauntedLocationId[18], Name = "Summerwind Mansion", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[15], AddressId = hauntedLocationId[20], Name = "Morris Pratt Institute", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[16], AddressId = hauntedLocationId[11], Name = "Boy Scout Lane", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[17], AddressId = hauntedLocationId[27], Name = "Siren Bridge", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[18], AddressId = hauntedLocationId[19], Name = "Forest Hill Cemetery", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[19], AddressId = hauntedLocationId[12], Name = "City of Black River Falls", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[20], AddressId = hauntedLocationId[8], Name = "Al Ringling Mansion", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[21], AddressId = hauntedLocationId[6], Name = "Clark County Insane Asylum", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[22], AddressId = hauntedLocationId[24], Name = "Riverside Theater", ImagePath = ""},
                new tblHauntedLocation {Id = hauntedLocationId[23], AddressId = hauntedLocationId[26], Name = "Hotel Hell", ImagePath = ""},
            };

            modelBuilder.Entity<tblHauntedLocation>().HasData(hauntedLocations);

        }

        private void CreateMembers(ModelBuilder modelBuilder)
        {
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

            List<tblMember> members = new List<tblMember>
            {
                new tblMember {Id = memberId[0], NewsLetterId = newsLetterId[3], TierId = tierId[0], MemberOpt = "Yes", NewsLetterOpt = "No"},
                new tblMember {Id = memberId[1], NewsLetterId = newsLetterId[2], TierId = tierId[1], MemberOpt = "No", NewsLetterOpt = "Yes"},
                new tblMember {Id = memberId[2], NewsLetterId = newsLetterId[1], TierId = tierId[2], MemberOpt = "Yes", NewsLetterOpt = "Yes"},
                new tblMember {Id = memberId[3], NewsLetterId = newsLetterId[0], TierId = tierId[2], MemberOpt = "No", NewsLetterOpt = "No"}
            };
            modelBuilder.Entity<tblMember>().HasData(members);
        }

        private void CreateMerchs(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < merchId.Length; i++)
                merchId[i] = Guid.NewGuid();

            //Merch Guids? Ints? Fks?
            modelBuilder.Entity<tblMerch>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblMerch_Id");

                entity.ToTable("tblMerch");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.MerchName)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.InStkQty)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Cost)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.ImagePath)
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            List<tblMerch> merchs = new List<tblMerch>
            {
                new tblMerch {Id = merchId[0], MerchName = "Spooky Wisconsin Long Sleeve Shirt", Cost = 20, InStkQty = 4, Description = "Long Sleeve with Spooky Wisconsin Logo", ImagePath = "SWLSS.png"},
                new tblMerch {Id = merchId[1], MerchName = "Haunted House Sticker", Cost = 3, InStkQty = 20, Description = "Image of a Haunted House", ImagePath = "HHS.png"},
                new tblMerch {Id = merchId[2], MerchName = "Spooky Wisconsin Hat", Cost = 15, InStkQty = 10, Description = "Baseball cap with Spooky Wisconsin Logo", ImagePath = "SWH.png"},
                new tblMerch {Id = merchId[3], MerchName = "Ghoul Shirt", Cost = 15, InStkQty = 5, Description = "Short Sleeve with Ghost", ImagePath = "GS.png"}
            };
            modelBuilder.Entity<tblMerch>().HasData(merchs);

        }

        private void CreateNewsLetters(ModelBuilder modelBuilder)
        {
            //NewsLetter Guids? Ints? Fks?
            modelBuilder.Entity<tblNewsLetter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblNewsLetter_Id");

                entity.ToTable("tblNewsLetter");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            List<tblNewsLetter> newsLetters = new List<tblNewsLetter>
            {
                new tblNewsLetter {Id = newsLetterId[0], HauntedEventId = hauntedEventId[0], Description = "Stay the Night for a Fright", Date = new DateTime(2023, 11, 10)},
                new tblNewsLetter {Id = newsLetterId[1], HauntedEventId = hauntedEventId[2], Description = "Veteran Walk-Through in Forest Hill Cemetery", Date = new DateTime(2023, 10, 01)},
                new tblNewsLetter {Id = newsLetterId[2], HauntedEventId = hauntedEventId[1], Description = "Kate Blood Gravestone Story Time", Date = new DateTime(2023, 10, 15)},
                new tblNewsLetter {Id = newsLetterId[3], HauntedEventId = hauntedEventId[3], Description = "Keeping Up with the Circus", Date = new DateTime(2023, 10, 22)},
            };
            modelBuilder.Entity<tblNewsLetter>().HasData(newsLetters);
        }

        private void CreateOrders(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < orderId.Length; i++)
            {
                orderId[i] = Guid.NewGuid();
            }

            //Order Guids? Ints? Fks?
            modelBuilder.Entity<tblOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblOrder_Id");

                entity.ToTable("tblOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.ShipDate).HasColumnType("datetime");

            });

            List<tblOrder> orders = new List<tblOrder>()
            {
                new tblOrder {Id = orderId[0], CustomerId = customerId[3], UserId = userId[2], OrderDate = new DateTime(2023, 11, 02), ShipDate =  new DateTime(2023, 11, 09)},
                new tblOrder {Id = orderId[1], CustomerId = customerId[2], UserId = userId[1], OrderDate = new DateTime(2023, 11, 09), ShipDate =  new DateTime(2023, 11, 16)},
                new tblOrder {Id = orderId[2], CustomerId = customerId[1], UserId = userId[0], OrderDate = new DateTime(2023, 12, 01), ShipDate =  new DateTime(2023, 12, 08)},
                new tblOrder {Id = orderId[3], CustomerId = customerId[0], UserId = userId[3], OrderDate = new DateTime(2023, 16, 16), ShipDate =  new DateTime(2023, 11, 23)}
            };
            modelBuilder.Entity<tblOrder>().HasData(orders);
        }

        private void CreateParticipants(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < participantId.Length; i++)
            {
                participantId[i] = Guid.NewGuid();
            }

            //Participant Guids? Ints? Fks?
            modelBuilder.Entity<tblParticipant>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblParticipant_Id");

                entity.ToTable("tblParticipant");

                entity.Property(e => e.Id).ValueGeneratedNever();

            });

            List<tblParticipant> participants = new List<tblParticipant>
            {
                new tblParticipant {Id = participantId[0], CustomerId = customerId[2], HauntedEventId = hauntedEventId[3] },
                new tblParticipant {Id = participantId[1], CustomerId = customerId[3], HauntedEventId = hauntedEventId[2] },
                new tblParticipant {Id = participantId[2], CustomerId = customerId[1], HauntedEventId = hauntedEventId[0] },
                new tblParticipant {Id = participantId[3], CustomerId = customerId[0], HauntedEventId = hauntedEventId[1] }
            };
            modelBuilder.Entity<tblParticipant>().HasData(participants);


        }

        private void CreateTiers(ModelBuilder modelBuilder) 
        {
            for (int i = 0; i < tierId.Length; i++)
            {
                tierId[i] = Guid.NewGuid();
            }

            //Tier Guids? Ints? Fks?
            modelBuilder.Entity<tblTier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_tblTier_Id");

                entity.ToTable("tblTier");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.TierName)
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.TierLevel)
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            List<tblTier> tiers = new List<tblTier>()
            {
                new tblTier {Id = tierId[0], TierName = "Gold", TierLevel = 3},
                new tblTier {Id = tierId[1], TierName = "Silver", TierLevel = 2},
                new tblTier {Id = tierId[2], TierName = "Bronze", TierLevel = 1}
            };
            modelBuilder.Entity<tblTier>().HasData(tiers);

        }

        private void CreateTours(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < tourId.Length; i++)
            {
                tourId[i] = Guid.NewGuid();
            }

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

            List<tblTour> tours = new List<tblTour>()
            {
                new tblTour {Id = tierId[0], HauntedLocationId = hauntedEventId[18], TourName = "Forest Hill Cemetery Tour", Description = "A guided tour through Forest Hill Cemetery"},
                new tblTour {Id = tierId[1], HauntedLocationId = hauntedEventId[7], TourName = "Riverside Cemetery Tour", Description = "A guided tour through Riverside Cemetery"},
                new tblTour {Id = tierId[2], HauntedLocationId = hauntedEventId[20], TourName = "Al Ringling Mansion Haunted Tour", Description = "A paranormal tour through Al Ringling Mansion"},
                new tblTour {Id = tierId[3], HauntedLocationId = hauntedEventId[0], TourName = "Night at the Old Baraboo Inn", Description = "A night tour in Old Baraboo Inn"}
            };
            modelBuilder.Entity<tblTour>().HasData(tours);


        }

        private void CreateUsers(ModelBuilder modelBuilder)
        {
            for (int i = 0; i < userId.Length; i++)
            {
                userId[i] = Guid.NewGuid();
            }

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

            modelBuilder.Entity<tblUser>().HasData(new tblUser 
            { 
                Id = userId[0], 
                Username = "wedaddams.1600", 
                Password = "password" 
            });
            modelBuilder.Entity<tblUser>().HasData(new tblUser 
            {
                Id = userId[1], 
                Username = "kingpop1984", 
                Password = "password" 
            });
            modelBuilder.Entity<tblUser>().HasData(new tblUser 
            { 
                Id = userId[2], 
                Username = "pricev31",
                Password = "password" 
            });
            modelBuilder.Entity<tblUser>().HasData(new tblUser 
            { 
                Id = userId[3], 
                Username = "mortaddams11", 
                Password = "password" 
            });

        }

    }
}
