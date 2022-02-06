using AlbumViewer.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumViewer.Data.Repository
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllArtists();

        Task<List<Album>> GetAlbumsForArtist(int artistId);

        Task<List<Artist>> SearchArtist(string search = null);

        Task<bool> DeleteArtist(int id);

    }
}
