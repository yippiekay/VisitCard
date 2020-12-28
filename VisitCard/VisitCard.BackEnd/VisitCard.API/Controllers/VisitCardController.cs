using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VisitCard.API.Models.Card;
using VisitCard.BLL.ModelsDto;
using VisitCard.BLL.Services.Interfaces;

namespace VisitCard.API.Controllers
{
    [ApiController]
    public class CardController : BaseController
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;
        
        public CardController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCard()
        {
            var cardDto = await _cardService.FindCardByIdAsync(CurrentUserId);
            var viewModel = _mapper.Map<CardViewModel>(cardDto);

            return Ok(viewModel);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCardAsync(UpdateCurrentModel card)
        {
            var updateCard = _mapper.Map<CardDto>(card);
            updateCard.Id = CurrentUserId;
            await _cardService.UpdateCardAsync(updateCard);
            
            return Ok();
        }
    }
}