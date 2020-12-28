using System.Threading.Tasks;
using VisitCard.DAL.Context;
using VisitCard.DAL.Interfaces;
using VisitCard.DAL.Repository;

namespace VisitCard.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private ICardRepository _cardRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public ICardRepository CardRepository
        {
            get { return _cardRepository ??= new CardRepository(_repositoryContext); }
        }

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}