using GYM_MVC.Core.Validation;
using System.ComponentModel.DataAnnotations;

namespace GYM_MVC.ViewModels {

    public class ForgotPasswordViewModel {

        [Required]
        [EmailAddress, EmailExists]
        public string Email { get; set; }
    }
}