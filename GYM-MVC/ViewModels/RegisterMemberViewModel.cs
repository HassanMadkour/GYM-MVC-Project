using System.ComponentModel.DataAnnotations;

namespace GYM_MVC.ViewModels {

    public class RegisterMemberViewModel : RegisterUserViewModel {

        [Display(Name = "Your Name")]
        public string MemberName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Marital Status")]
        public string MaterialStatus { get; set; }

        [Range(30, 300)]
        public decimal Weight { get; set; }

        [Range(100, 250)]
        public decimal Height { get; set; }

        [MaxLength(200)]
        public string? Illnesses { get; set; }

        [MaxLength(200)]
        public string? Injuries { get; set; }

        [Range(0, 24), Display(Name = "Sleep Hours")]
        public int SleepHours { get; set; }

        [Display(Name = "Available Days")]
        public int AvailableDays { get; set; }

        public List<string> materialStatuseLists = new List<string>() { "Single", "Married" };
    }
}