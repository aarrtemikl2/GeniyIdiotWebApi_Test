namespace GeniyIdiotWebApi.DTO
{
    public class UserGameResultRequestDTO
    {
        public int UserId { get; set; }
        public List<UserAnswerDTO> UserAnswerDTOs { get; set; }
        public UserGameResultRequestDTO(int userId, List<UserAnswerDTO> userAnswerDTOs)
        {
            UserId = userId;
            UserAnswerDTOs = userAnswerDTOs;
        }
    }
}
