namespace GeniyIdiotWebApi.Models
{
    public class AnswerAttempt
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserAnswer { get; set; }
        public bool IsCorrect { get; set; }

        public AnswerAttempt(int id,int questionId, int userAnswer)
        {
            Id = id;
            QuestionId = questionId;
            UserAnswer = userAnswer;
        }
    }
}
