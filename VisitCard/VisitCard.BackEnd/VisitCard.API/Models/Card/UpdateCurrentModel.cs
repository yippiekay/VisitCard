using System.ComponentModel.DataAnnotations;

namespace VisitCard.API.Models.Card
{
    public class UpdateCurrentModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(2, ErrorMessage = "Your first name must be longer than 1 letter.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "Your last name must be longer than 1 letter.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Position is required.")]
        [MinLength(3, ErrorMessage = "Your position must be longer than 2 letter.")]
        public string Position { get; set; }
        
        public string ImageByteCode { get; set; }
    }
}