using System.ComponentModel.DataAnnotations;

namespace JWHDM.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}