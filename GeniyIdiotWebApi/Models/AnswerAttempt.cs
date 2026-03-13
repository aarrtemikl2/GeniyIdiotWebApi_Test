namespace GeniyIdiotWebApi.Models
{
    public class AnswerAttempt
    {
        public Question Question { get; set; }
        public int UserAnswer { get; set; }
        public bool IsCorrect { get; set; }

        public AnswerAttempt(Question question, int userAnswer)
        {
            Question = question;
            UserAnswer = userAnswer;
            IsCorrect = userAnswer == question.Answer;
        }
    }
}
