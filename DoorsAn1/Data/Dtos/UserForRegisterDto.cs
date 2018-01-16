using System.ComponentModel.DataAnnotations;

namespace DoorsAn1.Data.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Пароль должен быть от 4 до 8 символов")]
        public string Password { get; set; }
    }
}