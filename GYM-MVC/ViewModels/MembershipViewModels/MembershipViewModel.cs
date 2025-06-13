using GYM_MVC.Core.Entities;

namespace GYM_MVC.ViewModels.MembershipViewModels
{
    public class MembershipViewModel
    {
        public int Id { get; set; }
        public MembershipType Type { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }

        public string Description { get; set; }
    }
}
