using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 charactor")]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 charactor")]
        public string Code { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 charactor")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
