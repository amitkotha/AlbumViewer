using AlbumViewer.Data.Model;
using AlbumViewer.Service.DTO;
using AutoMapper;

namespace AlbumViewer.Service.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AlbumResponseDTO, Album>();
            CreateMap<TrackDTO, Track>();
            CreateMap<ArtistDTO, Artist>();
            CreateMap<AlbumResponseDTO, Album>();
        }
        
    }
}
