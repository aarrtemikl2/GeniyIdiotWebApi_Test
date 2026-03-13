namespace GeniyIdiotWebApi.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Answer { get; set; }
        public QuestionDTO(int id, string title, int answer)
        {
            Id = id;
            Title = title;
            Answer = answer;
        }
    }
}
