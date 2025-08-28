using Microsoft.EntityFrameworkCore;
using BE.Data.Entities;

namespace BE.Data
{
    /// <summary>
    /// Database context for geographical data operations.
    /// Handles database configuration, mappings, and seeding for Dutch address data.
    /// </summary>
    public class GeographicalDataContext : DbContext
    {
        public GeographicalDataContext() { }

        public GeographicalDataContext(DbContextOptions<GeographicalDataContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Database set representing the GeographicalData table.
        /// Contains Dutch address and building information from BAG (Basisregistratie Adressen en Gebouwen).
        /// </summary>
        public DbSet<GeographicalDataEntity> GeographicalData { get; set; } = null!;

        /// <summary>
        /// Configures the database schema, constraints, indexes, and seed data.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the database schema.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GeographicalDataEntity>(entity =>
            {
                // Table and primary key configuration
                entity.ToTable("GeographicalData");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                // Address fields - core Dutch address components
                entity.Property(e => e.Openbareruimte)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("openbareruimte");

                entity.Property(e => e.Huisnummer)
                    .IsRequired()
                    .HasColumnName("huisnummer");

                entity.Property(e => e.Huisletter)
                    .HasMaxLength(1)
                    .HasColumnName("huisletter");

                entity.Property(e => e.Huisnummertoevoeging)
                    .HasColumnName("huisnummertoevoeging");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("postcode");

                // Geographic location fields
                entity.Property(e => e.Woonplaats)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("woonplaats");

                entity.Property(e => e.Gemeente)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("gemeente");

                entity.Property(e => e.Provincie)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("provincie");

                // BAG (Basisregistratie Adressen en Gebouwen) identifiers
                entity.Property(e => e.Nummeraanduiding)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nummeraanduiding");

                entity.Property(e => e.ObjectId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("objectid");

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("objecttype");

                // Residence/building properties
                entity.Property(e => e.Verblijfsobjectgebruiksdoel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("verblijfsobjectgebruiksdoel");

                entity.Property(e => e.Oppervlakteverblijfsobject)
                    .IsRequired()
                    .HasColumnName("oppervlakteverblijfsobject");

                entity.Property(e => e.Verblijfsobjectstatus)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("verblijfsobjectstatus");

                entity.Property(e => e.Nevenadres)
                    .HasMaxLength(200)
                    .HasColumnName("nevenadres");

                // Building (Pand) information
                entity.Property(e => e.Pandid)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pandid");

                entity.Property(e => e.Pandstatus)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pandstatus");

                entity.Property(e => e.Pandbouwjaar)
                    .IsRequired()
                    .HasColumnName("pandbouwjaar");

                // Coordinate systems - RD New (Netherlands) and WGS84 (Global)
                entity.Property(e => e.X)
                    .IsRequired()
                    .HasColumnName("x"); // RD New X coordinate

                entity.Property(e => e.Y)
                    .IsRequired()
                    .HasColumnName("y"); // RD New Y coordinate

                entity.Property(e => e.Lon)
                    .IsRequired()
                    .HasColumnType("decimal(18,6)")
                    .HasColumnName("lon"); // WGS84 Longitude

                entity.Property(e => e.Lat)
                    .IsRequired()
                    .HasColumnType("decimal(18,6)")
                    .HasColumnName("lat"); // WGS84 Latitude

                // Performance indexes for common query patterns
                entity.HasIndex(e => e.Postcode)
                    .HasDatabaseName("IX_GeographicalData_Postcode");

                entity.HasIndex(e => e.Woonplaats)
                    .HasDatabaseName("IX_GeographicalData_Woonplaats");

                entity.HasIndex(e => e.Gemeente)
                    .HasDatabaseName("IX_GeographicalData_Gemeente");

                // Composite index for full address lookups
                entity.HasIndex(e => new { e.Openbareruimte, e.Huisnummer, e.Postcode })
                    .HasDatabaseName("IX_GeographicalData_Address");
            });
        }
    }
}