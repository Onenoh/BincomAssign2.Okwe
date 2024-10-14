namespace BincomAssign2.Okwe.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public byte[] ImageData { get; set; }  
        public string ImageMimeType { get; set; }
    }
}
