using System.ComponentModel.DataAnnotations;

namespace GeniyIdiotWebApi.DTO
{
    public class UserGameResultRequestDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public List<UserAnswerDTO> UserAnswerDTOs { get; set; }
        public UserGameResultRequestDTO(int userId, List<UserAnswerDTO> userAnswerDTOs)
        {
            UserId = userId;
            UserAnswerDTOs = userAnswerDTOs;
        }
    }
}
