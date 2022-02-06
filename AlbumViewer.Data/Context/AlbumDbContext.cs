using AlbumViewer.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AlbumViewer.Data.Context
{
    public class AlbumDbContext:DbContext
    {
        public AlbumDbContext(DbContextOptions options) : base(options)
        {
        }

        public AlbumDbContext()
        { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
