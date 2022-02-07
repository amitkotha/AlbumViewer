using AlbumViewer.Data.Context;
using AlbumViewer.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumViewer.Data.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private AlbumDbContext _dbContext;


        public AlbumRepository(AlbumDbContext ctx)
        {
            _dbContext = ctx;
        }
        public async Task<bool> DeleteAlbum(int id, bool noSaveChanges = false)
        {
            var album = await _dbContext.Albums
                .Include(a => a.Tracks)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (album == null)
            {
                return false;
            }

            var tracks = album.Tracks.ToList();
            foreach (var track in tracks)
            {
                album.Tracks.Remove(track);
                _dbContext.Tracks.Remove(track);
            }

            _dbContext.Albums.Remove(album);


            if (!noSaveChanges)
            {
                var result = await _dbContext.SaveChangesAsync();

                return result > 0;
            }

            return true;
        }


        public async Task<List<Album>> GetAllAlbums(int page = 0, int pageSize = 10)
        {
            IQueryable<Album> albums = _dbContext.Albums
               .Include(ctx => ctx.Tracks)
               .Include(ctx => ctx.Artist)
               .OrderBy(alb => alb.Title);

            if (page > 0)
            {
                albums = albums
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize);
            }

            return await albums.ToListAsync();
        }

        public async Task<Album> SaveAlbum(Album postedAlbum)
        {
            _dbContext.Albums.Add(postedAlbum);
            await _dbContext.SaveChangesAsync();
            return postedAlbum;
        }

        public async Task<Album> SearchByAlbumId(int albumId)
        {
            int id = (int)albumId;
            return await _dbContext.Albums
            .Include(ctx => ctx.Tracks)
            .Include(ctx => ctx.Artist)
            .FirstOrDefaultAsync(alb => alb.Id == id);
        }

        public async Task<Album> UpdateAlbum(Album album, int id)
        {
            if (album.Id <= 0)
            {
                album.Id = id;
            }
            var entry = _dbContext.Albums.Find(id);
            _dbContext.Entry(entry).CurrentValues.SetValues(album);

            foreach (var existingTrack in entry.Tracks.ToList())
            {
                if (!album.Tracks.Any(c => c.Id == existingTrack.Id))

                    _dbContext.Tracks.Remove(existingTrack);
            }

            // Update and Insert children
            foreach (var track in album.Tracks)
            {
                var existingChild = entry.Tracks
                    .Where(c => c.Id == track.Id && c.Id != default(int))
                    .SingleOrDefault();

                if (existingChild != null)
                    // Update child
                    _dbContext.Entry(existingChild).CurrentValues.SetValues(track);
                else
                {
                    // Insert child
                    var newTrack = new Track
                    {
                        Id = track.Id,
                        AlbumId = track.AlbumId,
                        SongName = track.SongName,
                        Length = track.Length,
                        Bytes = track.Bytes,
                        UnitPrice = track.UnitPrice

                    };
                    entry.Tracks.Add(newTrack);
                }
            }
            await _dbContext.SaveChangesAsync();
            return album;
        }
    }
}
