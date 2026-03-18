namespace GeniyIdiotWebApi.DTO
{
    public class QuestionRequestDTO
    {
        public string Title {  get; set; }
        public int Answer {  get; set; }

        public QuestionRequestDTO(string title, int answer)
        {
            Title = title;
            Answer = answer;
        }
    }
}
