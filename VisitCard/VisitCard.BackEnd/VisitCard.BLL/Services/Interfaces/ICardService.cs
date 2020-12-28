using System.Threading.Tasks;
using VisitCard.BLL.ModelsDto;

namespace VisitCard.BLL.Services.Interfaces
{
    public interface ICardService
    {
        Task<CardDto> FindCardByIdAsync(string id);
        Task<bool> IsExistCard(string id);
        Task CreateEmptyCardAsync(string userId);
        Task UpdateCardAsync(CardDto cardDto);
        Task DeleteCardAsync(string id);
    }
}