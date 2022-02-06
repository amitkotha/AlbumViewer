using System.Collections.Generic;

namespace AlbumViewer.Service.DTO
{
    public class AlbumRequestDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public string AmazonUrl { get; set; }
        public string SpotifyUrl { get; set; }
        public ArtistDTO Artist { get; set; }
        public IList<TrackDTO> Tracks { get; set; }

    }
}
