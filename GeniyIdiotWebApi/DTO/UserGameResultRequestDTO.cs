using System.ComponentModel.DataAnnotations;

namespace GeniyIdiotWebApi.DTO
{
    public class UserGameResultRequestDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public List<UserAnswerDTO> UserAnswerDTOs { get; set; }
        public UserGameResultRequestDTO(string userName, List<UserAnswerDTO> userAnswerDTOs)
        {
            UserName = userName;
            UserAnswerDTOs = userAnswerDTOs;
        }
    }
}
