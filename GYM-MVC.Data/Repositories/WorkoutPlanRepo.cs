using GYM.Domain.Entities;
using GYM_MVC.Core.IRepositories;
using GYM_MVC.Data.Data;

namespace GYM_MVC.Data.Repositories {

    public class WorkoutPlanRepo : BaseRepo<WorkoutPlan>, IWorkoutPlanRepo {

        public WorkoutPlanRepo(GYMContext context) : base(context) {
        }

        public List<WorkoutPlan> GetWorkoutPlansByMemberId(int memberId) {
            return context.Workouts
                .Where(wp => wp.MemberId == memberId)
                .ToList();
        }
    }
}