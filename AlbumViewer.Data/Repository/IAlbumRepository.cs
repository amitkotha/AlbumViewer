using AlbumViewer.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumViewer.Data.Repository
{
    public interface IAlbumRepository
    {
        Task<Album> SearchByAlbumId(int albumId);

        Task<List<Album>> GetAllAlbums(int page = 0, int pageSize = 10);

        Task<Album> SaveAlbum(Album postedAlbum);

        Task<bool> DeleteAlbum(int id, bool noSaveChanges = false);
    }
}
