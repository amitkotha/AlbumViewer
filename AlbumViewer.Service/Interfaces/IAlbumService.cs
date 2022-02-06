using AlbumViewer.Service.DTO;
using System.Threading.Tasks;

namespace AlbumViewer.Service.Interfaces
{
    public interface IAlbumService
    {
        Task<AlbumResponseDTO> GetAllAlbums(int page, int pageSize);
        Task<AlbumResponseDTO> Load(int id);
        Task<AlbumResponseDTO> SaveAlbum(AlbumRequestDTO album);

        Task<bool> DeleteAlbum(int id);

    }
}
