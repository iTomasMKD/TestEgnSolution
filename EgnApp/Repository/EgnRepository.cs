using EgnApp.Contract;
using EgnApp.Models;

namespace EgnApp.Repository
{
    public class EgnRepository : IEgnRepository
    {
        private readonly EgnContext _context;
        public EgnRepository(EgnContext context)
        {
            _context = context;
        }
        public void CreateEgn(Egn egn)
        {
            _context.Add(egn);
            _context.SaveChanges();
        }

        public IEnumerable<Egn> GetAll() => _context.Egn.ToList();

        public Egn GetEgn(Guid id) => _context.Egn
            .SingleOrDefault(e => e.Id.Equals(id));
    }
}
