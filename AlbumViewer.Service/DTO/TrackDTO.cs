namespace AlbumViewer.Service.DTO
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string SongName { get; set; }
        public string Length { get; set; }
        public int Bytes { get; set; }
        public decimal UnitPrice { get; set; }
    }
}