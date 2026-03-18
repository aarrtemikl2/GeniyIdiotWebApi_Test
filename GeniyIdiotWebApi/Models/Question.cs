namespace GeniyIdiotWebApi.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Answer { get; set; }
        public Question() { }
        public Question(int id, string title, int answer)
        {
            Id = id;
            Title = title;
            Answer = answer;
        }

        public Question(int id)
        {
            Id = id;
        }
        public Question(string title, int answer)
        {
            Title = title;
            Answer = answer;
        }
    }
}
