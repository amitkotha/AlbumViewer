using AlbumViewer.Data.Model;
using AlbumViewer.Service.DTO;
using AutoMapper;

namespace AlbumViewer.Service.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
           
            CreateMap<AlbumResponseDTO, Album>().ReverseMap().ValidateMemberList(MemberList.None);
            CreateMap<TrackDTO, Track>().ReverseMap().ValidateMemberList(MemberList.None);       
            CreateMap<Artist, ArtistDTO>().ReverseMap().ValidateMemberList(MemberList.None);
            CreateMap<AlbumRequestDTO, Album>().ReverseMap().ValidateMemberList(MemberList.None);
           
        }
        
    }
}
