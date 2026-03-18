using GeniyIdiotWebApi.DTO;
using GeniyIdiotWebApi.Models;
using GeniyIdiotWebApi.Repository;

namespace GeniyIdiotWebApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> CreateAsync(UserRequestDTO userRequestDTO)
        {
            var user = new User(userRequestDTO.Name);
            var users = await _userRepository.GetAll();

            if (users.Any(u => u.Name == user.Name))
            {
                user = users.First(u => u.Name == user.Name);
                var selectedUserDTO = new UserDTO(user.Id, user.Name);

                return selectedUserDTO;
            }

            try
            {
                await _userRepository.SaveAsync(user);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var userDTO = new UserDTO(user.Id, user.Name);

            return userDTO;
        }

        public async Task<bool> IsExistAsync(UserDTO userDTO)
        {
            var users = await _userRepository.GetAll();

            var isExist = users.Any(u => u.Name == userDTO.Name);

            return isExist;
        }
    }
}
