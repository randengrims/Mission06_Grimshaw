using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DateMe.Models
{
    public class Application
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year is required."), Range(1888, 2026, ErrorMessage = "Year must be between 1888 and 2026.")]
        public int Year { get; set; } = 1888;

        public string? Director { get; set; }

        public string? Rating { get; set; }

        // Optional fields
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Must put whether the movie was copied to Plex or not.")]
        public bool CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}