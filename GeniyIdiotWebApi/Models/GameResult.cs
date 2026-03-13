namespace GeniyIdiotWebApi.Models
{
    public class GameResult
    {
        public string UserName { get; set; }
        public int CorrectCount { get; set; }
        public int IncorrectCount { get; set; }
        public string Rank { get; set; }

        public GameResult(string userName)
        {
            UserName = userName;
            CorrectCount = 0;
            IncorrectCount = 0;
            Rank = "";
        }
        public GameResult(string userName, int correctCount, int incorrectCount, string rank)
        {
            UserName = userName;
            CorrectCount = correctCount;
            IncorrectCount = incorrectCount;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{UserName} {CorrectCount} {IncorrectCount} {Rank}";
        }
    }
}
