using GeniyIdiotWebApi.Models;

namespace GeniyIdiotWebApi.Repository
{
    public class QuestionRepository
    {
        public void Add(Question question)
        {
            if (Questions.Contains(question))
            {
                throw new ArgumentException("Вопрос уже есть в коллекции");
            }
            Questions.Add(question);

            FileWriterService.SaveQuestions(_filePath, Questions);
        }

        public void Remove(int questionNumber)
        {
            var questionIndex = questionNumber - 1;

            if (questionIndex >= 0 && questionIndex < Questions.Count)
            {
                Questions.RemoveAt(questionIndex);
            }
            else
            {
                throw new ArgumentException("Номера вопроса не существует!");
            }

            FileWriterService.SaveQuestions(_filePath, Questions);
        }

        public List<Question> Shuffle()
        {
            Random random = new Random();
            return Questions.OrderBy(question => random.Next()).ToList();
        }
    }
}
