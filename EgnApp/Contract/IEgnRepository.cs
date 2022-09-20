using EgnApp.Models;

namespace EgnApp.Contract
{
    public interface IEgnRepository
    {
        IEnumerable<Egn> GetAll();
        Egn GetEgn(Guid id);
        void CreateEgn(Egn egn);
    }
}
