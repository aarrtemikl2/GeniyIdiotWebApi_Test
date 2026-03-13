namespace GeniyIdiotWebApi.Models
{
    public class User
    {
        public string Name { get; set; }
        public List<AnswerAttempt> AnswerAttempts { get; set; }
        public GameResult GameResult { get; set; }
        public User(string name)
        {
            Name = name;
            AnswerAttempts = new List<AnswerAttempt>();
            GameResult = new GameResult(Name);
        }
    }
}
