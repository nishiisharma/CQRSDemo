using System.ComponentModel.DataAnnotations;

namespace CQRSPlayerDemo.Models
{
    public class Player
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Shirt Number is required")]
        [Range(1, 99, ErrorMessage = "Shirt Number must be between 1 and 99")]
        public int? ShirtNo { get; set; }

        [Required(ErrorMessage = "Player name is required")]
        [StringLength(100, ErrorMessage = "Name can't exceed 100 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Appearance is required")]
        [Range(0, 1000, ErrorMessage = "Appearance must be between 0 and 1000")]
        public int? Appearance { get; set; }

        [Required(ErrorMessage = "Goals are required")]
        [Range(0, 1000, ErrorMessage = "Goals must be between 0 and 1000")]
        public int? Goals { get; set; }
    }
}
