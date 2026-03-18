using System.ComponentModel.DataAnnotations;

namespace GeniyIdiotWebApi.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public QuestionDTO() { }
        public QuestionDTO(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
