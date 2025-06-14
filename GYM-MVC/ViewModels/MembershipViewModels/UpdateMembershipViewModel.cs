using Microsoft.AspNetCore.Mvc.Rendering;

namespace GYM_MVC.ViewModels.MembershipViewModels {

    public class UpdateMembershipViewModel : MembershipViewModel {
        public string SelectedMembershipType { get; set; }

        public int Id { get; set; }

        public SelectList? MembershipTypeList { get; set; }
    }
}