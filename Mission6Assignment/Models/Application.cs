using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6Assignment.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        //[Required]
        //public Category CategoryName { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited is required.")]
        [Range(0, 1, ErrorMessage = "Edited must be Yes (1) or No (0).")]
        public int Edited { get; set; } = 0;

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Copied to Plex status is required.")]
        [Range(0, 1, ErrorMessage = "CopiedToPlex must be Yes (1) or No (0).")]
        public int CopiedToPlex { get; set; } = 0;

        [MaxLength(25, ErrorMessage = "Notes must be 25 characters or fewer.")]
        public string? Notes { get; set; }
    }
}
