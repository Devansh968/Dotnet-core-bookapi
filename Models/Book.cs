using System.ComponentModel.DataAnnotations;

namespace FirstWebAPI_March16.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string title { get; set; }
        [Required]

        [Range(1,1000)]
        public decimal price { get; set; }

    }
}