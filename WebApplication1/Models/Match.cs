namespace WebApplication1.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string PlayerOne { get; set; }
        public string PlayerTwo { get; set; }
        public string Score { get; set; }
        public DateTime Date { get; set; }
    }
}
