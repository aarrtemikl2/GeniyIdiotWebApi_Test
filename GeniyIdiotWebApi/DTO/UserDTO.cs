using System.ComponentModel.DataAnnotations;

namespace GeniyIdiotWebApi.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public UserDTO(string name)
        {
            Name = name;
        }

        public UserDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
