using AlbumViewer.Data.Model;
using AlbumViewer.Data.Repository;
using AlbumViewer.Service.DTO;
using AlbumViewer.Service.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace AlbumViewer.Service
{
    public class AlbumService : IAlbumService
    {
        IAlbumRepository _albumRepository;
        IMapper _mapper;
        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteAlbum(int id)
        {
            return await _albumRepository.DeleteAlbum(id);
        }

        public async Task<AlbumResponseDTO> GetAllAlbums(int page, int pageSize)
        {
            var albums = await _albumRepository.GetAllAlbums(page, pageSize);
            if (albums != null)
            {
                return _mapper.Map<AlbumResponseDTO>(albums);
            }
            return null;
        }

        public async Task<AlbumResponseDTO> Load(int id)
        {
            var album = await _albumRepository.SearchByAlbumId(id);
            return _mapper.Map<AlbumResponseDTO>(album);
        }

        public async Task<AlbumResponseDTO> SaveAlbum(AlbumRequestDTO postedAlbum)
        {
            var album = _mapper.Map<Album>(postedAlbum);
            var albumResponse = await _albumRepository.SaveAlbum(album);
            return _mapper.Map<AlbumResponseDTO>(albumResponse);
        }
    }
}

