using System.ComponentModel.DataAnnotations;

namespace WebApiNetCoreVideoClub
{
    public class parametrosGeneroPost
    {
        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        [StringLength(maximumLength:5)]
        [PrimeraLetraMayuscula]
        public String nombre { get; set; }
        public String descripcion { get; set; }
        [Range(18,60)]
        public int edad { get; set; }
        [Url]
        public String url { get; set; }
    }
}
