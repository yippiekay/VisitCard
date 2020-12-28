using VisitCard.DAL.Context;
using VisitCard.DAL.Interfaces;
using VisitCard.DAL.Models;

namespace VisitCard.DAL.Repository
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}