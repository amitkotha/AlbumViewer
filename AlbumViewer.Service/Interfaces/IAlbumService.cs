using AlbumViewer.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlbumViewer.Service.Interfaces
{
    public interface IAlbumService
    {
        Task<List<AlbumResponseDTO>> GetAllAlbums(int page, int pageSize);
        Task<AlbumResponseDTO> Load(int id);
        Task<AlbumResponseDTO> SaveAlbum(AlbumRequestDTO album);

        Task<bool> DeleteAlbum(int id);
        Task<AlbumResponseDTO> UpdateAlbum(AlbumRequestDTO postedAlbum, int id);
    }
}
