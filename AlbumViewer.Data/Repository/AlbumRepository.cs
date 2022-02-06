using AlbumViewer.Data.Context;
using AlbumViewer.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumViewer.Data.Repository
{
    public class AlbumRepository:IAlbumRepository
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

                return result>0;
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

    }
}
