using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GS.Core.Database.Entities
{
    public partial class SGDbContext : DbContext
    {
        
        public SGDbContext(DbContextOptions<SGDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<ArtistBasicInfo> ArtistBasicInfo { get; set; }
        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<GenreStyles> GenreStyles { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<SubGenres> SubGenres { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Music_DB;Trusted_Connection=False;User ID=sa;Password=Password123!;");
        //            }
        //        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SGDbContext>
        {
            public SGDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../SG.Api/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<SGDbContext>();
                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                builder.UseSqlServer(connectionString);
                return new SGDbContext(builder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            /* Ablum Table */
            modelBuilder.Entity<Albums>(entity =>
            {
                entity.ToTable("TBL_ALBUMS");

                entity.HasIndex(e => e.Albumid)
                    .HasName("UNQKEY_ALBUMID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Album)
                    .HasColumnName("ALBUM")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AlbumUrl)
                    .HasColumnName("ALBUM_URL")
                    .HasMaxLength(500);

                entity.Property(e => e.Albumid)
                    .IsRequired()
                    .HasColumnName("ALBUMID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ArtistId).HasColumnName("ARTIST_ID");

                entity.Property(e => e.ArtistName)
                    .HasColumnName("ARTIST_NAME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .HasColumnName("LABEL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rating)
                    .HasColumnName("RATING")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailL)
                    .HasColumnName("THUMBNAIL_L")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailM)
                    .HasColumnName("THUMBNAIL_M")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThumbnailS)
                    .HasColumnName("THUMBNAIL_S")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserRating)
                    .HasColumnName("USER_RATING")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasColumnName("YEAR")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ALBUMS_MAIN_TBL_ARTISTS");
            });

            /* ArtistBasicInfo Table*/
            modelBuilder.Entity<ArtistBasicInfo>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.ToTable("TBL_ARTIST_BASIC_INFO");

                entity.Property(e => e.ArtistId)
                    .HasColumnName("ARTIST_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aka)
                    .HasColumnName("AKA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Born)
                    .HasColumnName("BORN")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Died)
                    .HasColumnName("DIED")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Artist)
                    .WithOne(p => p.ArtistBasicInfo)
                    .HasForeignKey<ArtistBasicInfo>(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ARTIST_BASIC_INFO_TBL_ARTISTS");
            });

            /* Artist Table */
            modelBuilder.Entity<Artists>(entity =>
            {
                entity.ToTable("TBL_ARTISTS");

                entity.HasIndex(e => e.Artistid)
                    .HasName("UNQKEY_ARTISTID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Artist)
                    .IsRequired()
                    .HasColumnName("ARTIST")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Artistid)
                    .IsRequired()
                    .HasColumnName("ARTISTID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BigThumbnail)
                    .HasColumnName("BIG_THUMBNAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Biography).HasColumnName("BIOGRAPHY");

                entity.Property(e => e.GenreId).HasColumnName("GENRE_ID");

                entity.Property(e => e.SmallThumbnail)
                    .HasColumnName("SMALL_THUMBNAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearsActive)
                    .HasColumnName("YEARS_ACTIVE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_ARTISTS_MAIN_TBL_GENRES");
            });

            /* GenreStyle Table */
            modelBuilder.Entity<GenreStyles>(entity =>
            {
                entity.ToTable("TBL_GENRE_STYLES");

                entity.HasIndex(e => e.Styleid)
                    .HasName("UNQKEY_STYLEID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .IsUnicode(false);

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasColumnName("STYLE")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Styleid)
                    .IsRequired()
                    .HasColumnName("STYLEID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubGenreId).HasColumnName("SUB_GENRE_ID");

                entity.HasOne(d => d.SubGenre)
                    .WithMany(p => p.GenreStyles)
                    .HasForeignKey(d => d.SubGenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_GENRE_STYLES_TBL_SUB_GENRES");
            });

            /* Genres Table */
            modelBuilder.Entity<Genres>(entity =>
            {
                entity.ToTable("TBL_GENRES");

                entity.HasIndex(e => e.Genreid)
                    .HasName("UNQKEY_GENREID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("GENRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Genreid)
                    .IsRequired()
                    .HasColumnName("GENREID")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            /* SubGenres Table */
            modelBuilder.Entity<SubGenres>(entity =>
            {
                entity.ToTable("TBL_SUB_GENRES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

                entity.Property(e => e.GenreId).HasColumnName("GENRE_ID");

                entity.Property(e => e.SubGenre)
                    .IsRequired()
                    .HasColumnName("SUB_GENRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Subgenreid)
                    .IsRequired()
                    .HasColumnName("SUBGENREID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.SubGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_SUB_GENRES_TBL_GENRES");
            });

            /* Tracks Table */
            modelBuilder.Entity<Tracks>(entity =>
            {
                entity.ToTable("TBL_TRACKS");

                entity.HasIndex(e => e.Trackid)
                    .HasName("UNQKEY_TRACKID")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("ALBUM_ID");

                entity.Property(e => e.Composer)
                    .HasColumnName("COMPOSER")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Duration)
                    .HasColumnName("DURATION")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Featuring)
                    .HasColumnName("FEATURING")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Performer)
                    .HasColumnName("PERFORMER")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("TITLE")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Trackid)
                    .IsRequired()
                    .HasColumnName("TRACKID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_TRACKS_TBL_ALBUMS");
            });

            modelBuilder.HasSequence<int>("SequenceObjForAtristTbl").StartsAt(650);
        }
    }
}
