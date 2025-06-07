using System.ComponentModel.DataAnnotations;

namespace GYM_MVC.Core.Validation {

    public class UniqueAttribute : ValidationAttribute {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            return ValidationResult.Success;
        }
    }
}