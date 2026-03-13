namespace GeniyIdiotWebApi.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Answer { get; set; }
        public Question(int id,string title, int answer)
        {
            Id = id;
            Title = title;
            Answer = answer;
        }
    }
}
