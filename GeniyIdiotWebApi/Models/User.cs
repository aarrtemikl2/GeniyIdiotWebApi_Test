namespace GeniyIdiotWebApi.Models
{
    public class User
    {
        public string Name { get; set; }
        public List<AnswerAttempt> AnswerAttempts { get; set; }
        public int GameResultId { get; set; }
        public User(string name)
        {
            Name = name;
            AnswerAttempts = new List<AnswerAttempt>();
            GameResultId = 0;
        }
    }
}
