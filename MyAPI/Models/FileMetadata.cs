using System.ComponentModel.DataAnnotations;

public class FileMetadata
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string FileName { get; set; }
    [Required]
    public string FileUrl { get; set; }
    public string[] Tags { get; set; }
    public double Rating { get; set; }
    public int RatingCount { get; set; }
}
