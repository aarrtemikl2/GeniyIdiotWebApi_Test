namespace GeniyIdiotWebApi.DTO
{
    public class GameResultDTO
    {
        public int UserId { get; set; }
        public int Score { get; set; }
        public string Rank { get; set; }
        public GameResultDTO(int userId, int score, string rank)
        {
            UserId = userId; 
            Score = score; 
            Rank = rank;
        }
    }
}
