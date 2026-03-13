namespace GeniyIdiotWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> AnswerAttemptIds { get; set; }
        public int GameResultId { get; set; }
        public User(string name)
        {
            Name = name;
            AnswerAttemptIds = new List<int>();
            GameResultId = 0;
        }
    }
}
