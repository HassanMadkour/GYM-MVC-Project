using GYM.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace GYM_MVC.ViewModels.MemberViewModels {

    public class MemberViewModel {
        public string Name { get; set; }
        public int Age { get; set; }

        [Display(Name = "Material Status")]
        public MaritalStatus MaritalStatus { get; set; }

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
        public string AvailableDays { get; set; }

        public IFormFile? Image { get; set; }
    }
}