using App_deck_pokemon.DTOs;
using App_deck_pokemon.Models;
using App_deck_pokemon.Repositories;
using App_deck_pokemon.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_deck_pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository;
        private JWTService _JWTService;
        private PasswordService _passwordService;

        public UserController(UserRepository usersRepository, JWTService jwtService, PasswordService passwordService)
        {
            _userRepository = usersRepository;
            _JWTService = jwtService;
            _passwordService = passwordService;
        }

        
        [HttpPost("register")]
        public IActionResult CreateUser([FromBody] UserRequestDTO userRequestDTO)
        {
            User users = new User()
            {
                FirstName = userRequestDTO.FirstName,
                LastName = userRequestDTO.LastName,
                Email = userRequestDTO.Email,
                Role = userRequestDTO.Role,
                Password = _passwordService.EncryptPassword(userRequestDTO.Password),
            };
            if (_userRepository.Save(users))
            {
                return Ok(new UserResponceDTO() { FirstName = users.FirstName, LastName = users.LastName, Email = users.Email , Role = users.Role});
            }
            return StatusCode(500, new { Message = "Erreur server Users create" });
        }

       
        [HttpPost("login")]
        public IActionResult Login([FromForm] string email, [FromForm] string password)
        {
            password = _passwordService.EncryptPassword(password);

            User user = _userRepository.FindAll().Find(u => u.Email == email && u.Password == password);
            string token = _JWTService.GetJWT(email, password);
            if (token != null)
            {
                return Ok(token);
            }
            return StatusCode(404);
        }

        [Authorize(Policy = "admin")]
        [HttpGet("Read")]
        public IActionResult Read()
        {
            List<User> users = _userRepository.FindAll();
            List<UserResponceDTO> reponseDTO = new List<UserResponceDTO>();
            users.ForEach(u =>
            {
                reponseDTO.Add(new UserResponceDTO()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = u.Role,
                });
            });
            return Ok(reponseDTO);
        }

        [Authorize(Policy = "client")]
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] UserRequestDTO usersRequestDTO)
        {
            User user = _userRepository.FindById(id);

            if (user != null)
            {
                user.FirstName = usersRequestDTO.FirstName;
                user.LastName = usersRequestDTO.LastName;
                user.Email = usersRequestDTO.Email;
                user.Password = _passwordService.EncryptPassword(usersRequestDTO.Password);
                user.Role = usersRequestDTO.Role;

                if (_userRepository.Update())
                    return Ok(user);
                return StatusCode(500, new { Message = " Erreur serveur update " });
            }
            return NotFound();
        }

        [Authorize(Policy = "admin")]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            User user = _userRepository.FindById(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                return StatusCode(200, new { Message = "Delete user Ok " });
            }
            return NotFound();
        }

        [Authorize(Policy = "admin")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _userRepository.FindById(id);
            if (user != null)
                return Ok(user);
            return NotFound();
        }
    }
}
