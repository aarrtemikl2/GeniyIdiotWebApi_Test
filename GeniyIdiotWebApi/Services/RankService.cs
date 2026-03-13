namespace GeniyIdiotWebApi.Services
{
    public class RankService
    {
        private readonly Dictionary<int, string> _ranks;

        public RankService()
        {
            _ranks = new Dictionary<int, string>
            {
                {0, "идиот" },
                {1, "кретин" },
                {2, "дурак" },
                {3, "нормальный" },
                {4, "талант" },
                {5, "гений" }
            };
        }
        public string CalculateRank(int correctCount, int totalQuestions)
        {
            double percentCorrectCount = (double)correctCount / totalQuestions * 100;
            int userRank = (int)(percentCorrectCount / (100.0 / _ranks.Count));

            return _ranks[Math.Min(userRank, _ranks.Count - 1)];
        }

    }
}
