using System.ComponentModel.DataAnnotations;

namespace GYM_MVC.ViewModels.ScheduleViewModels {

    public class ScheduleViewModel {

        [Display(Name = "Day of Week")]
        public string DayOfWeek { get; set; }

        public TimeOnly Time { get; set; }

        [Display(Name = "Class Name"), MaxLength(50)]
        public string ClassName { get; set; }
    }
}