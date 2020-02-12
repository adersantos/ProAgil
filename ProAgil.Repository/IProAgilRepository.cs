using System.Threading.Tasks;
using ProAgil.Domain.Model;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

        //EVENTOS
         Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
         Task<Evento[]> GetAllEventoAsyncById(int EventoId, bool includePalestrantes);
         Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);

        //PALESTRANTE
         Task<Evento[]> GetPalestranteAsync(int PalestranteId);
         Task<Evento[]> GetAllPalestranteAsyncByName(bool includePalestrantes);

    }
}