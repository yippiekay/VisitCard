using System.Threading.Tasks;

namespace VisitCard.DAL.Interfaces
{
    public interface IRepositoryManager
    {
        ICardRepository CardRepository { get; }
        
        Task SaveAsync();
    }
}