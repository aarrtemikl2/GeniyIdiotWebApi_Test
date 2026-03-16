namespace GeniyIdiotWebApi.DTO
{
    public class UserRequestDTO
    {
        public string Name { get; set; }

        public UserRequestDTO(string name)
        {
            Name = name;
        }
    }
}
