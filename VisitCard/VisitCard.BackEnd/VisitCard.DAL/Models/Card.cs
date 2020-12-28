namespace VisitCard.DAL.Models
{
    public class Card
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public byte [] ImageByteCode { get; set; }
    }
}