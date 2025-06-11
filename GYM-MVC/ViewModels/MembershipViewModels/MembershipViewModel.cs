using GYM_MVC.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace GYM_MVC.ViewModels.MembershipViewModels {

    public class MembershipViewModel {
        public MembershipType Type { get; set; }

        [Range(0, 20000)]
        public decimal Price { get; set; }

        [Display(Name = "Number Of Days")]
        public int DurationInDays { get; set; }

        [Display(Name = "Description of Membership")]
        public string Description { get; set; }
    }
}