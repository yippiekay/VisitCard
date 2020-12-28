using System;
using System.Threading.Tasks;
using AutoMapper;
using VisitCard.BLL.ModelsDto;
using VisitCard.BLL.Services.Interfaces;
using VisitCard.DAL.Interfaces;
using VisitCard.DAL.Models;

namespace VisitCard.BLL.Services
{
    public class CardService : ICardService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CardService(IRepositoryManager manager, IMapper mapper)
        {
            _repositoryManager = manager;
            _mapper = mapper;
        }

        public async Task<CardDto> FindCardByIdAsync(string id)
        {
            var result = await _repositoryManager.CardRepository.FindOneAsync(c => c.Id == id);

            return _mapper.Map<CardDto>(result);
        }

        public async Task<bool> IsExistCard(string id) => 
            await _repositoryManager.CardRepository.ExistsAsync(card => card.Id == id);
        
        public async Task CreateEmptyCardAsync(string userId)
        {
            await _repositoryManager.CardRepository.CreateAsync(new Card { Id = userId });
            await _repositoryManager.SaveAsync();
        }
        
        public async Task UpdateCardAsync(CardDto cardDto)
        {
            if (cardDto is null)
            {
                throw new NullReferenceException("CardDtp is null");
            }
            
            var card = _mapper.Map<Card>(cardDto);
            _repositoryManager.CardRepository.Update(card);
            await _repositoryManager.SaveAsync();
        }

        public async Task DeleteCardAsync(string id)
        {
            var card =  await _repositoryManager.CardRepository.FindOneAsync(c => c.Id == id);

            if (card is null)
            {
                throw new NullReferenceException($"Card with id = {id} not found.");
            }
            
            _repositoryManager.CardRepository.Delete(card);
            await _repositoryManager.SaveAsync();
        }
    }
}