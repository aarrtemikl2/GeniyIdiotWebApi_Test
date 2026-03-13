namespace GeniyIdiotWebApi.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CorrectCount { get; set; }
        public int IncorrectCount { get; set; }
        public string Rank { get; set; }

        public GameResult(int userId)
        {
            UserId = userId;
            CorrectCount = 0;
            IncorrectCount = 0;
            Rank = "";
        }
        public GameResult(int id, int userId, int correctCount, int incorrectCount, string rank)
        {
            Id = id;
            UserId = userId;
            CorrectCount = correctCount;
            IncorrectCount = incorrectCount;
            Rank = rank;
        }
    }
}
