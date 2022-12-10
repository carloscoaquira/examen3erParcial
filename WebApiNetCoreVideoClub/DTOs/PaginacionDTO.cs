namespace WebApiNetCoreVideoClub.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 10;
        private readonly int cantidadMaximaRecordPorPagina = 50;

        public int RecordsPorPagina
        {
            get { return this.recordsPorPagina; }
            set
            {
                this.recordsPorPagina=(value>this.cantidadMaximaRecordPorPagina)?this.cantidadMaximaRecordPorPagina:value;
            }
        }

    }
}
