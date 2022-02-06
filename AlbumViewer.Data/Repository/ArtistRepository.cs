using AlbumViewer.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumViewer.Data.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        public Task<bool> DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Album>> GetAlbumsForArtist(int artistId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Artist>> GetAllArtists()
        {
            throw new NotImplementedException();
        }

        public Task<List<Artist>> SearchArtist(string search = null)
        {
            throw new NotImplementedException();
        }
    }
}
