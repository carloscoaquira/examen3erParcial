using System.ComponentModel.DataAnnotations;

namespace WebApiNetCoreVideoClub.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required]
        [StringLength(maximumLength:50)]
        public string Nombre { get; set; }
    }
}
