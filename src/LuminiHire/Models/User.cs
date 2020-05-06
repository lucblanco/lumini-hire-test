using System.ComponentModel.DataAnnotations;

namespace CollegeScorecard.Models
{
    public class User
    {
        [Required(ErrorMessage = "O login deve ser inserido.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha deve ser inserida.")]
        public string Senha { get; set; }
    }
}
