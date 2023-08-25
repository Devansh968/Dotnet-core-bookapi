using System.ComponentModel.DataAnnotations;

namespace FirstWebAPI_March16.Dtos
{
    public record BookDTO
    {
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        [Range(1,1000)]
        public decimal Price { get; set; }

    }
}
