namespace ProAgil.Domain.Model
{
    public class PalestranteEvento
    {
        public int PalestsranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}