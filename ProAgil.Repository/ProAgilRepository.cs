using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Model;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include( p => p.Lotes)
                .Include( r => r.RedesSociais);

                if(includePalestrantes)
                {
                    query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(p => p.Palestrante);
                }

                query = query.OrderByDescending(c => c.DataEvento);

                return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoAsyncById(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include( p => p.Lotes)
                .Include( r => r.RedesSociais);

                if(includePalestrantes)
                {
                    query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(p => p.Palestrante);
                }

                query = query.OrderByDescending(c => c.DataEvento).Where( c => c.Id == eventoId);

                return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include( p => p.Lotes)
                .Include( r => r.RedesSociais);

                if(includePalestrantes)
                {
                    query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(p => p.Palestrante);
                }

                query = query.OrderByDescending(c => c.DataEvento).Where( c => c.Tema.Contains(tema));

                return await query.ToArrayAsync();
        }

        public Task<Evento[]> GetPalestranteAsync(int PalestranteId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Evento[]> GetAllPalestranteAsyncByName(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }
    }
}