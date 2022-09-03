namespace WebApiNetCoreVideoClub
{
    public class respuestaGeneroGetRegistro
    {
        public int codigo { get; set; } //0=Proceso Satisfactorio , distinto de cero es error
        public String mensaje { get; set; }
        public respuestaGeneroGet data { get; set; }

        public respuestaGeneroGetRegistro()
        {
            this.data = new respuestaGeneroGet();
        }
    }
}
