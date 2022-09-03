namespace WebApiNetCoreVideoClub
{
    public class respuestaGeneroGetEstandar
    {
        public int codigo { get; set; } //0=Proceso Satisfactorio , distinto de cero es error
        public String mensaje { get; set; }

        public List<respuestaGeneroGet> lista { get; set; }

        public respuestaGeneroGetEstandar()
        {
            this.lista = new List<respuestaGeneroGet>();
        }

    }
}
