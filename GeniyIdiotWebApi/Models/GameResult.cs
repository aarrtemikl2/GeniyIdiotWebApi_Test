namespace GeniyIdiotWebApi.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public string Rank { get; set; }

        public GameResult(int userId)
        {
            UserId = userId;
            Score = 0;
            Rank = "";
        }
        public GameResult(int userId, int score, string rank)
        {
            UserId = userId;
            Score = score;
            Rank = rank;
        }
    }
}
